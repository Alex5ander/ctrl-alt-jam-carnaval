using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseDialog : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] MissionItemUI missionItemUIPrefab;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    [SerializeField] List<Mission> Missions;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Mission mission in Missions)
        {
            MissionItemUI missionItemUI = Instantiate(missionItemUIPrefab);
            mission.score = 0;
            missionItemUI.Init(mission);
            missionItemUI.transform.SetParent(verticalLayoutGroup.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        canvasGroup.alpha = (int)canvasGroup.alpha ^ 1;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        canvasGroup.interactable = !canvasGroup.interactable;
        Time.timeScale = (uint)Time.timeScale ^ 1;
    }
}
