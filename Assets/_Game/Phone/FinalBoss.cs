using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private int clicksNeeded;
    [SerializeField] private int startLives;
    [SerializeField] private RectTransform progressBar;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private FinalBossBounds button;
    [SerializeField] private FinalBossBounds hoverStart;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;
    [SerializeField] private float recoveryTime;
    [SerializeField] private Button winButton;
    private bool recovering;

    [Header("Enemy")] 
    [SerializeField] private PlaySound music;
    [SerializeField] private PlaySound damageSound;
    [SerializeField] private FinalBossBounds[] enemyPrefabs;
    private int currentLives;
    private int currentClicks;
    private bool playing;


    private void Awake()
    {
        SetLives(startLives);
        button.SetBounds(minBounds, maxBounds);
        hoverStart.oof += GameReady;
        foreach(FinalBossBounds enemy in enemyPrefabs)
        {
            enemy.SetBounds(minBounds, maxBounds);
            enemy.oof += LoseLife;
        }
        Defeat();
        winButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (playing)
        {
            music.PlayFromMiddle();
        }
    }

    private void GameReady()
    {
        hoverStart.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        button.oof += StartGame;
    }

    private void StartGame()
    {
        playing = true;
        music.Play();
        button.move = true;
        button.oof -= StartGame;
        SetLives(startLives);
        SetClicks(0);
        foreach (FinalBossBounds enemy in enemyPrefabs)
        {
            enemy.gameObject.SetActive(true);
        }
    }

    private async void LoseLife()
    {
        if (recovering) return;
        SetLives(currentLives - 1);
        damageSound.Play();
        recovering = true;
        await Awaitable.WaitForSecondsAsync(recoveryTime);
        recovering = false;
    }

    public void Clicked()
    {
        SetClicks(currentClicks + 1);
    }

    private void SetClicks(int clicks)
    {
        currentClicks = Mathf.Clamp(clicks, 0, clicksNeeded);
        progressBar.localScale = new Vector2((float)currentClicks/clicksNeeded, 1);
        if(currentClicks == clicksNeeded)
        {
            Victory();
        }
    }

    private void SetLives(int lives)
    {
        currentLives = Mathf.Clamp(lives, 0, startLives);
        livesText.text = $"Lives: {currentLives}";
        if(currentLives == 0)
        {
            Defeat();
        }
    }

    private void Victory()
    {
        EndGame();
        winButton.gameObject.SetActive(true);
    }

    private void Defeat()
    {
        EndGame();
        hoverStart.gameObject.SetActive(true);
    }

    private void EndGame()
    {
        playing = false;
        music.Stop();
        button.Reset();
        button.move = false;
        button.gameObject.SetActive(false);
        foreach (FinalBossBounds enemy in enemyPrefabs)
        {
            enemy.Reset();
            enemy.gameObject.SetActive(false);
        }
    }
}
