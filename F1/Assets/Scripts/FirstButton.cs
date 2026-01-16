using UnityEngine;

public class FirstButton : MonoBehaviour
{
    public static FirstButton instance;
    public bool gameStarted = false;
    public GameObject startButton;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f; 

        if (startButton != null)
            startButton.SetActive(false);
        if (Timer.instance != null)
            Timer.instance.StartRace();

        Debug.Log("Jocul a început!");
    }
}
