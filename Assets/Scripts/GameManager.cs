using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] TextMeshProUGUI TimerUI;
    [SerializeField] CanvasGroup GameOverDialog;
    public static GameManager Instance { get; private set; }
    [SerializeField] PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        GameOverDialog.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (playerStats.TimeLeft > 0)
        {
            playerStats.TimeLeft -= Time.fixedDeltaTime;
        }
        if (playerStats.TimeLeft < 0)
        {
            playerStats.TimeLeft = 0;
            GameOver();
        }
        TimerUI.text = TimeSpan.FromSeconds(playerStats.TimeLeft).ToString(@"m\:ss");
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverDialog.alpha = 1;
    }
    static public void LoadMainScene() => SceneManager.LoadScene(0);
}
