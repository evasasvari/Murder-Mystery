using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Dictionary<CollectibleItem.ItemType, bool> collectedItems = new Dictionary<CollectibleItem.ItemType, bool>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ItemCollected(CollectibleItem.ItemType itemType)
    {
        if (!collectedItems.ContainsKey(itemType))
        {
            collectedItems[itemType] = true;  // Mark the item type as collected
        }

        CheckAllItemsCollected();
    }

    public bool AllItemsCollected()
    {
        // Example check for all items
        return collectedItems.ContainsValue(false) == false; // Check if all items have been collected
    }

    private void CheckAllItemsCollected()
    {
        if (AllItemsCollected())
        {
            Debug.Log("All items collected!");
        }
    }
}
