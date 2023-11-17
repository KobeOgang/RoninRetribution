using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<float, Vector2> damageableHit;
    public UnityEvent<float, float> healthChanged;
    public UnityEvent playerDied;  // New event for player death

    Animator anim;

    [SerializeField]
    private float _maxHealth = 100;

    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    [SerializeField]
    private float _health = 100;

    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            healthChanged.Invoke(_health, MaxHealth);

            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;

    private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;

    [SerializeField]
    private bool isBlocking = false;

    public bool IsBlocking
    {
        get { return isBlocking; }
        set { isBlocking = value; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            anim.SetBool("isAlive", value);
            Debug.Log("Is alive set " + value);

            if (isPlayer && !_isAlive)
            {
                // Player died, trigger event
                playerDied.Invoke();
            }
        }
    }

    public bool isPlayer = false;  // New flag to indicate if the object is a player

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    public bool Hit(float damage, Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            if (!IsBlocking)
            {
                Health -= damage;
                isInvincible = true;

                anim.SetTrigger("hit");
                damageableHit.Invoke(damage, knockback);
            }
            else
            {
                anim.SetTrigger("blockHit");
            }
        }
        return false;
    }

    public void Heal(float healthRestore)
    {
        if (IsAlive)
        {
            float maxHeal = Mathf.Max(MaxHealth - Health, 0);
            Health += Mathf.Min(maxHeal, healthRestore);
        }
    }
}
