using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    [SerializeField] string Description;
    [SerializeField] float Range;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Mission MissionRequired;
    [SerializeField] MissionData missionData;
    [SerializeField] public int maxScore;
    [SerializeField] public int score;
    [SerializeField] Image MissionUI;
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
        Completed = true;
        playerStats.missionsCompleted.Add(playerStats.mission);
        playerStats.mission = null;
        playerStats.TimeLeft = playerStats.MaxTimeLeft;
        MissionUI.color = Color.green;
        missionData.Complete();
        if (playerStats.missionsCompleted.Count == 5)
        {
            GameManager.Instance.GameOver();
        }
    }

    void ShowDialog()
    {
        IsVisible = true;
        if (IsAvailable())
        {
            missionData.Set(name, Description);
        }
        else if (Completed)
        {
            missionData.Set(name, "Missão completada");
        }
        else if (MissionRequired != null)
        {
            missionData.Set("Missão bloqueada", MissionRequired.name + " deve ser completada antes.");
        }
        missionData.Open();
    }

    void HideDialog()
    {
        IsVisible = false;
        missionData.Close();
    }

    bool IsAvailable() => !Completed && (playerStats.missionsCompleted.Contains(MissionRequired) || MissionRequired == null);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
