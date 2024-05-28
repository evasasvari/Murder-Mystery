using UnityEngine;

public class Fridge : MonoBehaviour
{
    private SceneTransitions sceneTransitions;

    private void Start()
    {
        // Find the SceneTransitions component in the scene
        sceneTransitions = FindObjectOfType<SceneTransitions>();
        if (sceneTransitions == null)
        {
            Debug.LogError("SceneTransitions component not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has interacted with the fridge.");
            if (GameManager.instance.AllItemsCollected())
            {
                Debug.Log("All items collected, attempting to load the end scene.");
                // Use SceneTransitions to load the closing scene
                if (sceneTransitions != null)
                {
                    sceneTransitions.LoadScene(); // Make sure this method in SceneTransitions is setup to load the intended scene
                }
            }
            else
            {
                Debug.Log("Not all items collected yet.");
            }
        }
    }
}
