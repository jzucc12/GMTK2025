using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    private Canvas canvas;
    private bool isPaused;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        SetPause(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SetPause(!isPaused);
        }
    }

    public void SetPause(bool pause)
    {
        isPaused = pause;
        canvas.enabled = pause;
        Time.timeScale = pause ? 0 : 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
