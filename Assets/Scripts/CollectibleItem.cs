using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CollectibleItem : XRGrabInteractable
{
    public enum ItemType
    {
        Photo,
        WineGlass,
        PregnancyTest,
        WineBottle,
        Knife
    }

    public ItemType itemType;  // Set in the Unity Inspector.
    private bool isCollected = false;  // Flag to track if the item has been collected

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);  // Important to call the base method to handle the interaction properly
        if (!isCollected)
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        GameManager.instance.ItemCollected(itemType);  // Notify GameManager
        OnCollect();
        isCollected = true;  // Prevent future collection
    }

    public void OnCollect()
    {
        // Trigger animations, sound effects, etc. Here using Debug.Log as a placeholder
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
