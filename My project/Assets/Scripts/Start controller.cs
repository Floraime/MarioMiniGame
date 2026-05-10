using UnityEngine;
using System.Collections;

public class StartSequenceController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject startText;

    public Animator[] characterAnimators;
    public MonoBehaviour[] movingObjects;
    public AudioSource backgroundMusic;
    public AudioSource startSound;

    public AudioSource[] boxSounds;

    public bool gameStarted = false;

    private bool sequenceStarted = false;

    void Start()
    {
        gameStarted = false;

        // Show instructions panel and hide start text
        startPanel.SetActive(true);
        startText.SetActive(false);

        // Pause the game
        Time.timeScale = 0f;

        // Disable character animations
        foreach (Animator anim in characterAnimators)
        {
            if (anim != null)
                anim.enabled = false;
        }

        // Disable moving objects (e.g., boxes)
        foreach (MonoBehaviour script in movingObjects)
        {
            if (script != null)
                script.enabled = false;
        }

        // Stop background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        // Stop box sounds
        foreach (AudioSource audio in boxSounds)
        {
            if (audio != null)
                audio.Stop();
        }
    }

    void Update()
    {
        // Start sequence when Space is pressed
        if (!sequenceStarted && Input.GetKeyDown(KeyCode.Space))
        {
            sequenceStarted = true;
            StartCoroutine(BeginSequence());
        }
    }

    IEnumerator BeginSequence()
    {
        // Hide instructions and show "START" text
        startPanel.SetActive(false);
        startText.SetActive(true);
        if (startSound != null)
        {
    startSound.Play();
        }

        // Wait while game is paused
        yield return new WaitForSecondsRealtime(2f);

        // Hide "START" text
        startText.SetActive(false);
        if (startSound != null)
        {
    startSound.Stop();
        }

        // Enable character animations
        foreach (Animator anim in characterAnimators)
        {
            if (anim != null)
                anim.enabled = true;
        }

        // Enable moving objects
        foreach (MonoBehaviour script in movingObjects)
        {
            if (script != null)
                script.enabled = true;
        }

        // Play background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }

        // Play box sounds
        foreach (AudioSource audio in boxSounds)
        {
            if (audio != null)
                audio.Play();
        }

        // Mark game as started (this enables the timer)
        gameStarted = true;

        // Resume game time
        Time.timeScale = 1f;
    }
}