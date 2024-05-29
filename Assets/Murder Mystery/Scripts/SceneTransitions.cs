using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitions : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource for scheduled scene transitions
    public string nextSceneName;  // Default scene name for transitions
    public FadeScreen fadeScreen;  // Reference to the FadeScreen script


    private void Start()
    {
        if (audioSource != null && audioSource.clip != null && audioSource.playOnAwake)
        {
            StartTransitionAfterAudio();  // Automatically start transition if configured to play on awake
        }
    }

    public void LoadScene(string sceneName = "")
    {
        StartCoroutine(TransitionScene(string.IsNullOrEmpty(sceneName) ? nextSceneName : sceneName));
    }

    private IEnumerator TransitionScene(string sceneName)
    {
        fadeScreen.FadeOut();  // Use FadeScreen to fade out
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
                async.allowSceneActivation = true;
            yield return null;
        }
        fadeScreen.FadeIn();  // Use FadeScreen to fade in
    }

    public void StartTransitionAfterAudio()
    {
        StartCoroutine(TransitionAfterAudio(nextSceneName));
    }

    private IEnumerator TransitionAfterAudio(string sceneName)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        yield return StartCoroutine(TransitionScene(sceneName));
    }
}
