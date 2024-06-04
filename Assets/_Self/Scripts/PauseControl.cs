using TMPro;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField] private static bool gameIsPaused = false;
    public TMP_Text pausedText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
            PauseGame();
        else
            ResumeGame();
    }

    void PauseGame()
    {
        pausedText.text = StringHandler.Text_Paused;
        LeanTween.scale(pausedText.gameObject, Vector2.one, 0);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        // Debug.Log($"Game Paused");
    }

    void ResumeGame()
    {
        pausedText.text = "";
        LeanTween.scale(pausedText.gameObject, Vector3.zero, 0);
        Time.timeScale = 0.9f;
        AudioListener.pause = false;
        // Debug.Log($"Game Resume");
    }
}