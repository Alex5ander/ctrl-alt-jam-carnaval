using TMPro;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] string Title;
    [SerializeField] string Description;
    [SerializeField] CanvasGroup MissionDialog;
    [SerializeField] TextMeshProUGUI MissionTitleUI;
    [SerializeField] TextMeshProUGUI MissionDescriptionUI;
    [SerializeField] float Range;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Mission MissionRequired;
    public bool Completed = false;
    bool IsVisible = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerStats.position);
        if (distance < Range)
        {
            ShowDialog();
            if (playerStats.mission == null && IsAvailable())
            {
                playerStats.mission = this;
            }
        }
        else if (distance > Range && IsVisible)
        {
            HideDialog();
        }
    }

    public void CompleteMission()
    {
        Debug.Log("Mission Completed");
        playerStats.missionsCompleted.Add(playerStats.mission);
        playerStats.mission = null;
    }

    void ShowDialog()
    {
        IsVisible = true;
        if (IsAvailable())
        {
            MissionTitleUI.text = Title;
            MissionDescriptionUI.text = Description;
        }
        else
        {
            MissionTitleUI.text = "Missão bloqueada";
            MissionDescriptionUI.text = MissionRequired.Title + " deve ser completada antes.";
        }
        MissionDialog.alpha = 1;
    }

    void HideDialog()
    {
        IsVisible = false;
        MissionDialog.alpha = 0;
    }

    bool IsAvailable() => !Completed && (playerStats.missionsCompleted.Contains(MissionRequired) || MissionRequired == null);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
