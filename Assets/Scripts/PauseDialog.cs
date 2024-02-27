using UnityEngine;
using UnityEngine.UI;

public class PauseDialog : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] MissionItemUI missionItemUIPrefab;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    [SerializeField] MissionManager missionManager;
    public static PauseDialog Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        canvasGroup.alpha = (int)canvasGroup.alpha ^ 1;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        canvasGroup.interactable = !canvasGroup.interactable;
        Time.timeScale = (uint)Time.timeScale ^ 1;
    }

    public void Init()
    {
        foreach (Mission mission in MissionManager.Instance.Missions)
        {
            MissionItemUI missionItemUI = Instantiate(missionItemUIPrefab);
            missionItemUI.Init(mission);
            missionItemUI.transform.SetParent(verticalLayoutGroup.transform, false);
        }
    }
}
