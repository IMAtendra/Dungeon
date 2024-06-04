using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text countText;
    private readonly int duration = 120;
    public float timeRemaining;
    public bool timerIsRunning = false;

    void Start() => Init();

    void Init()
    {
        if (!timerIsRunning)
        {
            // Starts the timer automatically
            timerIsRunning = true;
            timeRemaining = duration;
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // Debug.Log("Time has run out!");
                FindAnyObjectByType<StatusText>().StatusTextDisplay(StringHandler.Text_Lose, true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (countText == null) countText = GameObject.Find("CountText").GetComponent<TMP_Text>();

        countText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
