using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI bestTimeText;
    public string playerTag = "Player";
    private float timer = 0f;
    private bool isRunning = true;
    private bool gameEnded = false;
    private float bestTime;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        if (bestTime < float.MaxValue)
            bestTimeText.text = "Best: " + bestTime.ToString("F2") + "s";
        else
            bestTimeText.text = "Best: --";
    }

    private void Update()
    {
        if (isRunning && !gameEnded)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2") + "s";
        }
    }
    public void GameOver()
    {
        if (gameEnded) return;
        isRunning = false;
        gameEnded = true;
        messageText.text = "GAME OVER!";
    }
    public void FinishRace()
    {
        if (gameEnded) return;
        isRunning = false;
        gameEnded = true;
        messageText.text = "Finish! \n Time: " + timer.ToString("F2") + "s";
        if (timer < bestTime)
        {
            bestTime = timer;
            PlayerPrefs.SetFloat("Best Time", bestTime);
            PlayerPrefs.Save();
            messageText.text += "\n NEW BEST TIME!";
        }
        bestTimeText.text = "Best: " + bestTime.ToString("F2") + "s";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return ;
        if (gameObject.CompareTag("Finish"))
        {
            FinishRace();
        }
        else if (gameObject.CompareTag("OffTrack"))
        {
            GameOver();
        }
    }
}
