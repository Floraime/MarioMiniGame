using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void GoToMinigame()
    {
        SceneManager.LoadScene("MinigameScene");
    }
}