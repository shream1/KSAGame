using UnityEngine;
using UnityEngine.UI; // For UI elements
using UnityEngine.SceneManagement; // For scene management

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // Total time for the game in seconds
    private float timeRemaining;
    public Text timerText; // UI Text element to display the timer
    public GameObject reatart;

    void Start()
    {
        timeRemaining = totalTime; // Initialize time remaining
    }

    void Update()
    {
        // Decrease time remaining
        timeRemaining -= Time.deltaTime;

        // Update the timer UI
        timerText.text = "Time: " + Mathf.Max(0, Mathf.Ceil(timeRemaining)).ToString();

        // Check if the time has run out
        if (timeRemaining <= 0)
        {
            timeRemaining = 0; // Ensure it doesn't go negative
            EndGame(); // Call the EndGame method
        }
    }

    void EndGame()
    {
        Debug.Log("Time's up! You lose!");
        reatart.SetActive(true);
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current scene
    }
}