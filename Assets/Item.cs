using UnityEngine;

public class Item : MonoBehaviour
{
    // Enum to represent different types of items in the game.
    public enum ItemType
    {
        Photo,
        WineGlass,
        PregnancyTest,
        WineBottle,
        Knife
    }

    public ItemType itemType;  // This allows you to set the item type in the Unity Inspector.

    // Optional: Any additional item-specific behaviors can be added here.
    // For example, you might want to have a method that responds to the item being collected:
    public void OnCollect()
    {
        // This could trigger animations, sound effects, or other game events.
        Debug.Log($"{itemType} has been collected!");
        // You could also deactivate the item here, or handle it externally in the CollectibleItem script.
    }
}

