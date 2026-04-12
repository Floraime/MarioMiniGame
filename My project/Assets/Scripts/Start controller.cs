using UnityEngine;
using System.Collections;

public class StartSequenceController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject startText;

    private bool sequenceStarted = false;

    void Start()
    {
        startPanel.SetActive(true);
        startText.SetActive(false);
    }

    void Update()
    {
        if (!sequenceStarted && Input.GetKeyDown(KeyCode.Space))
        {
            sequenceStarted = true;
            StartCoroutine(BeginSequence());
        }
    }

    IEnumerator BeginSequence()
    {
        startPanel.SetActive(false);
        startText.SetActive(true);

        yield return new WaitForSeconds(2f);

        startText.SetActive(false);
    }
}