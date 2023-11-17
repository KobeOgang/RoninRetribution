using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    // This function is called when the object is clicked
    
    
    private void OnMouseDown()
    {
        Debug.Log("Object clicked.");
        // Add your interaction logic here if needed

        // Deactivate or destroy the object
        gameObject.SetActive(false); // Deactivate the GameObject
        // OR
        // Destroy(gameObject); // Destroy the GameObject
        

    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the range of scenes in Build Settings.
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available. You've reached the end of the build settings scenes.");
        }
    }
}