using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemCollector itemCollector;
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
        if (collectedItems.ContainsKey(itemType))
        {
            collectedItems[itemType] = true;  // Ensure it's marked true
            Debug.Log($"Item {itemType} collected and updated.");
            // Find the ItemCollector script and call ShowPolaroid
            FindObjectOfType<ItemCollector>().ShowPolaroid(itemType);
            itemCollector.ShowPolaroid(itemType);

        }
        else
        {
            Debug.LogWarning($"Item {itemType} not found in dictionary.");  // This should not happen
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

