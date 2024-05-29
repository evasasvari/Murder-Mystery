using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [System.Serializable]
    public struct ItemPolaroidPair
    {
        public CollectibleItem.ItemType itemType;
        public GameObject blankPolaroid;  // GameObject for the blank polaroid
        public GameObject foundPolaroid;  // GameObject for the polaroid that appears when the item is found
    }

    public ItemPolaroidPair[] itemPolaroidMappings;

    void Start()
    {
        // Initially show the blank polaroids and hide the found ones
        foreach (var pair in itemPolaroidMappings)
        {
            if (pair.blankPolaroid != null)
                pair.blankPolaroid.SetActive(true);
            if (pair.foundPolaroid != null)
                pair.foundPolaroid.SetActive(false);
        }
    }

    public void ShowPolaroid(CollectibleItem.ItemType collectedItemType)
    {
        foreach (var pair in itemPolaroidMappings)
        {
            if (pair.itemType == collectedItemType)
            {
                if (pair.blankPolaroid != null)
                    pair.blankPolaroid.SetActive(false);
                if (pair.foundPolaroid != null)
                    pair.foundPolaroid.SetActive(true);
                break;
            }
        }
    }
}
