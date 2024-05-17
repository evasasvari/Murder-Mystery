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
    public AudioClip collectionSound;  // Public AudioClip to assign different sounds in the Inspector
    private AudioSource audioSource;  // Reference to the AudioSource component


    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found, adding one.");
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if not already attached
        }
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log($"Item {itemType} has been picked");
        base.OnSelectEntered(args);  // Important to call the base method
        if (!isCollected)
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        Debug.Log($"Collecting {itemType}");  // Confirm this function is called
        GameManager.instance.ItemCollected(itemType);  // Notify GameManager
        OnCollect();
        isCollected = true;  // Prevent future collection
    }

    public void OnCollect()
    {
        if (collectionSound != null)
        {
            audioSource.clip = collectionSound;
            audioSource.Play();  // Play the audio clip assigned in the AudioSource component
        }
        else
        {
            Debug.LogWarning("No AudioClip is assigned to collectionSound.");
        }
    }
}

