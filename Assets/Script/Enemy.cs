using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator anim;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
            GetComponent<PolygonCollider2D>().enabled = false;
            //this.enabled = false;
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);

        // Set the gravityScale of the Rigidbody2D to 0
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.gravityScale = 0f;
        }
    }
    
}
