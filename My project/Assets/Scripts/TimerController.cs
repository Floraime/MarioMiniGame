using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 30f;
    public StartSequenceController startSequence;

    private bool finished = false;

    void Update()
    {
        if (finished) return;
        if (startSequence == null) return;
        if (!startSequence.gameStarted) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "0";
            finished = true;
        }
    }
}
