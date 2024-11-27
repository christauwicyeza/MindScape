using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float remainingTime;
    private bool isRunning = false;
    private bool isPaused = false;

    void Update()
    {
        if (isRunning && !isPaused)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                isRunning = false;
                remainingTime = 0; 
                UpdateTimerDisplay();
                EndSession();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"{minutes:00} : {seconds:00}"; 
    }

    public void StartTimer(float sessionDuration)
    {
        remainingTime = sessionDuration;
        isRunning = true;
        isPaused = false;
    }

    public void PauseTimer()
    {
        if (isRunning)
        {
            isPaused = true;
        }
    }

    public void ResumeTimer()
    {
        if (isRunning && isPaused)
        {
            isPaused = false;
        }
    }

    void EndSession()
    {
        timerText.text = "Session Done"; 
        Debug.Log("Session Complete!");
        Invoke("ReturnToStartScene", 3f);
    }

    void ReturnToStartScene()
    {
        SceneManager.LoadScene(0); 
    }
}
