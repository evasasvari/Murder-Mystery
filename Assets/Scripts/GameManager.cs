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
        // Ensure that each type of item has been collected
        foreach (var item in collectedItems.Values)
        {
            if (!item)  // If any item is not collected (false)
                return false;  // Not all items are collected
        }
        return true;  // All items are collected
    }


    private void CheckAllItemsCollected()
    {
        if (AllItemsCollected())
        {
            Debug.Log("All items collected!");
        }
    }
}
