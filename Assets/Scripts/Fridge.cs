using UnityEngine;
using UnityEngine.SceneManagement;

public class Fridge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.AllItemsCollected())
        {
            SceneManager.LoadScene("EndScene");  // Load the ending scene
        }
    }
}
