using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Dictionary<CollectibleItem.ItemType, bool> collectedItems = new Dictionary<CollectibleItem.ItemType, bool>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeCollectedItems();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeCollectedItems()
    {
        foreach (CollectibleItem.ItemType itemType in System.Enum.GetValues(typeof(CollectibleItem.ItemType)))
        {
            collectedItems[itemType] = false;
        }
    }


    public void ItemCollected(CollectibleItem.ItemType itemType)
    {
        if (!collectedItems.ContainsKey(itemType))
        {
            collectedItems[itemType] = true;  // mark the item type as collected
        }

        CheckAllItemsCollected();
    }

    public bool AllItemsCollected()
    {
        // Example check for all items
        return collectedItems.ContainsValue(false) == false; // check if all items have been collected
    }

    private void CheckAllItemsCollected()
    {
        if (AllItemsCollected())
        {
            Debug.Log("All items collected!");
        }
    }
}
