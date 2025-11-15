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
        if (!FirstButton.instance.gameStarted)
            return;

        if (isRunning && !gameEnded)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2") + "s";
        }
    }
    public void StartRace()
    {
            timer = 0f;
            isRunning = true;
            gameEnded = false;
            messageText.text = "";
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
        if (gameEnded || !isRunning) return;
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
        if (other.CompareTag("Finish"))
        {
            FinishRace();
        }
        else if (other.CompareTag("OffTrack"))
        {
            GameOver();
        }
    }
    public void SubtractTime(float amount)
    {
        timer = Mathf.Max(0, timer - amount);
        StartCoroutine(ShowTimeReducedMessage(amount));
    }

    private System.Collections.IEnumerator ShowTimeReducedMessage(float amount)
    {
        string oldMessage = messageText.text;
        messageText.text = $"-{amount:F1}s!";
        yield return new WaitForSeconds(1.5f);
        messageText.text = oldMessage;
    }

}
