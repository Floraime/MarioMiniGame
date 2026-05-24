using System.Collections;
using UnityEngine;

public class FinishLeaderboardController : MonoBehaviour
{
    public GameObject finishText;
    public GameObject leaderboardText;

    public GameObject winnerPlayer;
    public GameObject winnerAuto1;
    public GameObject winnerAuto2;
    public AudioSource leaderboardSound;

    public float leaderboardDelay = 2f;

    private bool hasShownLeaderboard = false;

    public void ShowFinalSequence()
    {
        if (hasShownLeaderboard) return;

        hasShownLeaderboard = true;
        StartCoroutine(ShowLeaderboardAfterFinish());
    }

    private IEnumerator ShowLeaderboardAfterFinish()
    {
        if (finishText != null)
        {
            finishText.SetActive(true);
        }

        yield return new WaitForSeconds(leaderboardDelay);
        finishText.SetActive(false);
        if (leaderboardSound != null)
        {
        leaderboardSound.Play();
        }

        if (leaderboardText != null)
        {
            leaderboardText.SetActive(true);
        }

        if (winnerPlayer != null)
        {
            winnerPlayer.SetActive(true);
        }

        if (winnerAuto1 != null)
        {
            winnerAuto1.SetActive(true);
        }

        if (winnerAuto2 != null)
        {
            winnerAuto2.SetActive(true);
        }
    }
}