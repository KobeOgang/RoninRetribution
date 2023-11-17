using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    public Dialogue dialogueManager;
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Stop the player from moving
            playerController.SetCanMove(false);

            // Trigger the dialogue with a callback to resume movement when the dialogue ends
            dialogueManager.StartDialogue(() => playerController.SetCanMove(true));

            // Optionally, disable the collider to prevent continuous triggering
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
