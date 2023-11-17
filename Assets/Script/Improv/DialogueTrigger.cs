using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Trigger the dialogue
            dialogueManager.StartDialogue();
            // Optionally, disable the collider to prevent continuous triggering
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
