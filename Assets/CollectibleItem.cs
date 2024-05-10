using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    // types of items
    public enum ItemType
    {
        Photo,
        WineGlass,
        PregnancyTest,
        WineBottle,
        Knife
    }

    public ItemType itemType;  // set the item type in the Unity Inspector.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        GameManager.instance.ItemCollected(itemType);  // Notify GameManager
        OnCollect();
        gameObject.SetActive(false);  // Deactivate the item and remove it from the scene (for now)
    }

    public void OnCollect()
    {
        // trigger animations, sound effects etc instead of Debug.Log     
        Debug.Log($"{itemType} has been collected!");

        // Update UI Text to show that the item has been collected
        Text uiText = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        if (uiText != null)
        {
            uiText.text = "You have collected the " + itemType;
        }
        else
        {
            Debug.LogWarning("UI Text component not found. Make sure your UI Text is set up correctly.");
        }
    }
}
