using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private HashSet<string> collectedItems = new HashSet<string>();
    public GameObject[] fridgeImages; // Assign images in the inspector corresponding to each item

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ItemCollected(string itemTag)
    {
        collectedItems.Add(itemTag);
        UpdateFridge(itemTag);
        CheckAllItemsCollected();
    }

    void UpdateFridge(string itemTag)
    {
        // Activate the corresponding image on the fridge
        foreach (GameObject image in fridgeImages)
        {
            if (image.tag == itemTag)
            {
                image.SetActive(true);
                break;
            }
        }
    }

    void CheckAllItemsCollected()
    {
        // Here you could check the count of collected items against the total number of collectible items
        if (collectedItems.Count == fridgeImages.Length)
        {
            Debug.Log("All items collected!");
            // Optionally set some flag here or notify the fridge
        }
    }

    public bool AllItemsCollected()
    {
        return collectedItems.Count == fridgeImages.Length;
    }

}
