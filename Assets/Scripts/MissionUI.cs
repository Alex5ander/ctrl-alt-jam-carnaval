using TMPro;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] CanvasGroup MissionDialogUI;
    [SerializeField] TextMeshProUGUI MissionTitleUI;
    [SerializeField] TextMeshProUGUI MissionDescriptionUI;
    [SerializeField] MissionData missionData;
    // Start is called before the first frame update
    void Start()
    {
        missionData.Listener = OnChange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnChange()
    {
        MissionDialogUI.alpha = missionData.IsVisible ? 1 : 0;
        MissionTitleUI.text = missionData.Title;
        MissionDescriptionUI.text = missionData.Description;
    }
}
