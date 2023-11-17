using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
            
        }
    }

    void InteractWithObject()
    {
        Vector2 playerPosition = transform.position;
        Vector3 playerPosition3D = new Vector3(playerPosition.x, playerPosition.y, 0f); // Convert player position to 3D
        Vector3 direction = Vector3.forward; // Use the forward direction in 3D space

        RaycastHit hit;
        if (Physics.Raycast(playerPosition3D, direction, out hit, interactionRange))
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
               
            }
        }
    }
}