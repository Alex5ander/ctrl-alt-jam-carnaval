using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDialog : MonoBehaviour, IGameOverListener
{
    [SerializeField] Color GameOverColor;
    [SerializeField] Color GameWinColor;
    [SerializeField] CanvasGroup GameOverCanvasGroup;
    [SerializeField] Image GameOverDialogImage;
    [SerializeField] TextMeshProUGUI GameOverMessage;
    [SerializeField] GameEvents gameEvents;
    string[] GameWinMessages =
    {
        "Missão cumprida! Você deixou sua marca e Greenville nunca mais será a mesma.",
        "Vitória! Você é o rei da travessura, e Greenville é seu reino de diversão e caos!",
        "Você conseguiu! Que maneira perfeita de encerrar o dia, Greenville está em caos.",
        "Você venceu! E mostrou que é o verdadeiro rei das travessuras, deixando Greenville de cabeça para baixo."
    };
    string[] GameLostMessages =
    {
        "Ops! Você foi pego pelas autoridades. Melhor sorte na próxima vez!",
        "Game over! Você não conseguiu evitar a captura e agora está em apuros.",
        "Você falhou em sua missão de causar caos e Greenville ainda permanece intacta.",
        "Oops! Parece que o sol se pôs sobre suas travessuras. Mas não se preocupe, amanhã é outro dia e você poderá causar o caos em Greenville!"
    };
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.gameOverListeners.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show(bool win)
    {
        Time.timeScale = 0;
        GameOverCanvasGroup.alpha = 1;
        GameOverCanvasGroup.blocksRaycasts = true;
        GameOverCanvasGroup.interactable = true;
        string message = GameLostMessages[Random.Range(0, GameLostMessages.Length)];
        Color color = GameOverColor;
        if (win)
        {
            message = GameWinMessages[Random.Range(0, GameWinMessages.Length)];
            color = GameWinColor;
        }
        GameOverMessage.text = message;
        GameOverDialogImage.color = color;
    }

    static public void LoadMainScene() => SceneManager.LoadScene(0);

    public void OnEmit(bool win)
    {
        Show(win);
    }

    void OnDestroy()
    {
        gameEvents.gameOverListeners.Remove(this);
    }
}
