using TMPro;
using UnityEngine;

public class MissionDialog : MonoBehaviour
{
    [SerializeField] CanvasGroup MissionDialogUI;
    [SerializeField] TextMeshProUGUI MissionTitleUI;
    [SerializeField] TextMeshProUGUI MissionDescriptionUI;
    [SerializeField] TextMeshProUGUI MissionProgressText;
    public static MissionDialog Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle(Mission mission)
    {
        if (MissionDialogUI != null)
        {
            MissionDialogUI.alpha = (int)MissionDialogUI.alpha ^ 1;
            MissionTitleUI.text = mission.Title;
            MissionDescriptionUI.text = mission.Description;
        }
    }
}
