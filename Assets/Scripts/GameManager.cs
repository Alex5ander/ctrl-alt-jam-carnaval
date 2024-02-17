using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] TextMeshProUGUI TimerUI;
    [SerializeField] Color GameOverDialogColor;
    [SerializeField] Color GameWinDialogColor;
    [SerializeField] CanvasGroup GameOverDialog;
    [SerializeField] Image GameOverDialogImage;
    [SerializeField] TextMeshProUGUI GameOverMessage;
    [SerializeField] CanvasGroup PauseDialog;
    public static GameManager Instance { get; private set; }
    bool IsGameOver = false;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PoliceOfficers policeOfficers;
    [SerializeField] ParticleSystem particles;
    List<string> GameWinMessages = new(){
        "Missão cumprida! Você deixou sua marca e Greenville nunca mais será a mesma.",
        "Vitória! Você é o rei da travessura, e Greenville é seu reino de diversão e caos!",
        "Você conseguiu! Que maneira perfeita de encerrar o dia, Greenville está em caos.",
        "Você venceu! E mostrou que é o verdadeiro rei das travessuras, deixando Greenville de cabeça para baixo."
    };
    List<string> GameLostMessages = new()
    {
        "Ops! Você foi pego pelas autoridades. Melhor sorte na próxima vez!",
        "Game over! Você não conseguiu evitar a captura e agora está em apuros.",
        "Você falhou em sua missão de causar caos e Greenville ainda permanece intacta.",
        "Oops! Parece que o sol se pôs sobre suas travessuras. Mas não se preocupe, amanhã é outro dia e você poderá causar o caos em Greenville!"
    };
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        policeOfficers.list.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && !IsGameOver)
        {
            Pause();
        }
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
    void Pause()
    {
        PauseDialog.alpha = PauseDialog.alpha == 1 ? 0 : 1;
        PauseDialog.blocksRaycasts = !PauseDialog.blocksRaycasts;
        PauseDialog.interactable = !PauseDialog.interactable;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0;
        GameOverDialog.alpha = 1;
        GameOverDialog.blocksRaycasts = true;
        GameOverDialog.interactable = true;
        string message = GameLostMessages[UnityEngine.Random.Range(0, GameLostMessages.Count)];
        Color color = GameOverDialogColor;
        if (playerStats.missionsCompleted.Count == 5)
        {
            message = GameWinMessages[UnityEngine.Random.Range(0, GameWinMessages.Count)];
            color = GameWinDialogColor;
        }
        GameOverMessage.text = message;
        GameOverDialogImage.color = color;
        policeOfficers.list.Clear();
    }
    public void StartParticles()
    {
        particles.Play();
    }
    static public void LoadMainScene() => SceneManager.LoadScene(0);
}
