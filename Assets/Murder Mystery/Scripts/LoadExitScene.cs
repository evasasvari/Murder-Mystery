using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadExitScene : MonoBehaviour
{
    public AudioSource audioSource;
    public string nextSceneName;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Start playing the audio
        audioSource.Play();

        // Call the method to change the scene after the clip duration
        Invoke("ChangeScene", audioSource.clip.length);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("ExitScene");
    }
}