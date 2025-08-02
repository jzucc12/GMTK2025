using System;
using TMPro;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private int clicksNeeded;
    [SerializeField] private int startLives;
    [SerializeField] private Transform container;
    [SerializeField] private RectTransform progressBar;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private FinalBossBounds button;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    [Header("Enemy")]
    [SerializeField] private int startEnemies;
    [SerializeField] private int clicksPerEnemy;
    [SerializeField] private FinalBossBounds enemyPrefab;
    private int currentLives;
    private int currentClicks;


    private void Awake()
    {
        SetLives(startLives);
        button.SetBounds(minBounds, maxBounds);
    }

    private void OnEnable()
    {
        FinalBossEnemy.oof += LoseLife;
    }

    private void OnDisable()
    {
        FinalBossEnemy.oof -= LoseLife;
    }

    public void StartGame()
    {
        SetLives(startLives);
        SetClicks(0);
        currentLives = startLives;
        for(int ii = 0; ii < startEnemies; ii++)
        {
            FinalBossBounds enemy = Instantiate(enemyPrefab, container);
            enemy.transform.localPosition = new Vector2(UnityEngine.Random.Range(minBounds.x, maxBounds.x), UnityEngine.Random.Range(minBounds.y, maxBounds.y));
            enemy.SetBounds(minBounds, maxBounds);
        }
    }
    public void LoseLife()
    {
        SetLives(currentLives - 1);
    }

    public void Clicked()
    {
        SetClicks(currentClicks + 1);
    }

    private void SetClicks(int clicks)
    {
        currentClicks = Mathf.Clamp(clicks, 0, clicksNeeded);
        if(currentClicks == clicksNeeded)
        {
            //You win
        }
    }

    private void SetLives(int lives)
    {
        currentLives = Mathf.Clamp(lives, 0, startLives);
        livesText.text = $"Lives: {currentLives}";
        if(currentLives == 0)
        {
            //Game Over
        }
    }
}
