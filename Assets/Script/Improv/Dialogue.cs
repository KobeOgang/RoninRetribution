using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private Action onDialogueEnd; // Callback for when the dialogue ends

    // Start is called before the first frame update
    void Start()
    {
        // Disable the dialogue at the start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue(Action onEndCallback = null)
    {
        index = 0;
        // Enable the dialogue when starting
        gameObject.SetActive(true);
        onDialogueEnd = onEndCallback; // Set the callback
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Disable the dialogue when reaching the end
            gameObject.SetActive(false);
            onDialogueEnd?.Invoke(); // Invoke the callback if it's not null
        }
    }
}
