using UnityEngine;
using UnityEngine.SceneManagement;

public class Fridge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has interacted with the fridge.");
            if (GameManager.instance.AllItemsCollected())
            {
                Debug.Log("All items collected, attempting to load the end scene.");
                SceneManager.LoadScene("ClosingGameScene");
            }
            else
            {
                Debug.Log("Not all items collected yet.");
            }
        }
    }
}

