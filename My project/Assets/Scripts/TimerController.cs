using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 30f;
    public StartSequenceController startSequence;

    public GameObject finishText;
    public FinishLeaderboardController finishLeaderboardController;

    public Animator[] characterAnimators;
    public MonoBehaviour[] movingObjects;
    public AudioSource backgroundMusic;
    public AudioSource[] boxSounds;
    public AudioSource finishSound;

    private bool finished = false;

    void Update()
    {
        if (finished) return;
        if (startSequence == null) return;
        if (!startSequence.gameStarted) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0)
                timeRemaining = 0;

            timerText.text = Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "0";
            finished = true;

            startSequence.gameStarted = false;

            // Stop character animations
            foreach (Animator anim in characterAnimators)
            {
                if (anim != null)
                    anim.enabled = false;
            }

            // Stop moving objects
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

            // Show finish and leaderboard sequence
            if (finishLeaderboardController != null)
            {
                finishLeaderboardController.ShowFinalSequence();
            }
            else if (finishText != null)
            {
                finishText.SetActive(true);
            }

            // Play finish sound
            if (finishSound != null)
            {
                finishSound.Play();
            }
        }
    }
}