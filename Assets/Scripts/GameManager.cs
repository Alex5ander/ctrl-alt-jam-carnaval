using System;
using System.Collections;
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
    public static GameManager Instance { get; private set; }
    bool IsGameOver = false;
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
    float seconds = 120;
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
        Hydrant.totalBroken = 0;
        Trash.totalBroken = 0;
        House.totalPainted = 0;
        Alarm.alarmRinging = false;
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && !IsGameOver)
        {
            PauseDialog.Instance.Pause();
        }
    }

    IEnumerator StartTimer()
    {
        while (seconds != 0)
        {
            seconds -= 1;
            TimerUI.SetText(TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss"));
            yield return new WaitForSeconds(1);
        }
        GameOver();
    }
    public void GameOver(bool win = false)
    {
        IsGameOver = true;
        Time.timeScale = 0;
        GameOverDialog.alpha = 1;
        GameOverDialog.blocksRaycasts = true;
        GameOverDialog.interactable = true;
        string message = GameLostMessages[UnityEngine.Random.Range(0, GameLostMessages.Count)];
        Color color = GameOverDialogColor;
        if (win)
        {
            message = GameWinMessages[UnityEngine.Random.Range(0, GameWinMessages.Count)];
            color = GameWinDialogColor;
        }
        GameOverMessage.text = message;
        GameOverDialogImage.color = color;
    }
    static public void LoadMainScene() => SceneManager.LoadScene(0);
}
