using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [System.Serializable]
    public struct ItemPolaroidPair
    {
        public CollectibleItem.ItemType itemType;
        public GameObject polaroid;
    }

    public ItemPolaroidPair[] itemPolaroidMappings;

    void Start()
    {
        HideAllPolaroids();  // Optionally hide all on start
    }

    public void ShowPolaroid(CollectibleItem.ItemType collectedItemType)
    {
        foreach (var pair in itemPolaroidMappings)
        {
            if (pair.itemType == collectedItemType)
            {
                pair.polaroid.SetActive(true);
                break;
            }
        }
    }

    private void HideAllPolaroids()
    {
        foreach (var pair in itemPolaroidMappings)
        {
            pair.polaroid.SetActive(false);
        }
    }
}

