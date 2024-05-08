using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Item item = GetComponent<Item>();
            if (item != null)
            {
                GameManager.instance.ItemCollected(item.itemType);  // Notify GameManager
                item.OnCollect();  // Trigger any specific behaviors associated with the item being collected.
                gameObject.SetActive(false);  // Optionally, deactivate the item here or within Item.OnCollect()
            }
        }
    }
}
