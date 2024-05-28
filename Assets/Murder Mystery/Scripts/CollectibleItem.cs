using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
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
    public ParticleSystem glowEffect;  // Reference to the ParticleSystem

    [Range(0f, 1f)] public float audioVolume = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if not already attached
            audioSource.volume = audioVolume;
            Debug.LogWarning("AudioSource component not found, adding one.");
        }
        if (glowEffect == null)
        {
            glowEffect = GetComponentInChildren<ParticleSystem>();
            if (glowEffect == null)
            {
                Debug.LogWarning("ParticleSystem not found on the collectible item.");
            }
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
        // Stop the particle system when the item is collected
        if (glowEffect != null)
        {
            glowEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
