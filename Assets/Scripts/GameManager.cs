using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float MaxTimeInSeconds;
    [Header("UI Objects")]
    [SerializeField] TextMeshProUGUI TimerUI;
    public static GameManager Instance { get; private set; }
    public float TimeLeft { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        TimeLeft = MaxTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.fixedDeltaTime;
            if (TimeLeft < 0)
            {
                TimeLeft = 0;
            }
            TimerUI.text = Mathf.FloorToInt(TimeLeft).ToString();
        }
    }

    static public void LoadGameScene() => SceneManager.LoadScene(1);
    static public void Exit() => Application.Quit();
}
