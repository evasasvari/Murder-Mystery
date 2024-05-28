using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitions : MonoBehaviour
{
    public Renderer fadeRenderer;
    public AudioSource audioSource;  // AudioSource for scheduled scene transitions
    public float fadeDuration = 2f;
    public string nextSceneName;  // Default scene name for transitions

    private Material fadeMaterial;

    private void Awake()
    {
        fadeMaterial = fadeRenderer.material;  // Initialize the material from the renderer
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();  // Ensure AudioSource is assigned
        }
    }

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
        yield return StartCoroutine(Fade(1));  // Fade out
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine(Fade(0));  // Fade in
    }

    public void StartTransitionAfterAudio()
    {
        StartCoroutine(TransitionAfterAudio(nextSceneName));
    }

    private IEnumerator TransitionAfterAudio(string sceneName)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);  // Wait until the clip finishes playing
        yield return StartCoroutine(Fade(1));  // Fade out
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine(Fade(0));  // Fade in
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeMaterial.color.a;
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            Color newColor = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, alpha);
            fadeMaterial.color = newColor;
            timer += Time.deltaTime;
            yield return null;
        }

        fadeMaterial.color = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, targetAlpha);
    }
}
