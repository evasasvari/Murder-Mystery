using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ItemCollected(tag);  // Notify GameManager that an item was collected
            gameObject.SetActive(false);  // disable the item
        }
    }
}
