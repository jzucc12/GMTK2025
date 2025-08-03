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
    [SerializeField] private FinalBossBounds[] enemyPrefabs;
    private int currentLives;
    private int currentClicks;


    private void Awake()
    {
        SetLives(startLives);
        button.SetBounds(minBounds, maxBounds);
        foreach(FinalBossBounds enemy in enemyPrefabs)
        {
            enemy.SetBounds(minBounds, maxBounds);
            enemy.oof += LoseLife;
        }
    }

    public void StartGame()
    {
        SetLives(startLives);
        SetClicks(0);
        foreach (FinalBossBounds enemy in enemyPrefabs)
        {
            enemy.gameObject.SetActive(true);
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
            Defeat();
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
    }

    private void Defeat()
    {
        EndGame();
    }

    private void EndGame()
    {
        foreach (FinalBossBounds enemy in enemyPrefabs)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
