using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<Mission> Missions;
    public int TotalCompleted = 0;
    public static MissionManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        foreach (Mission mission in Missions)
        {
            mission.Completed = false;
        }
        PauseDialog.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Missions[0].Completed && House.totalPainted >= 3)
        {
            TotalCompleted += 1;
            Missions[0].Completed = true;
            CheckMissions();
        }
        if (!Missions[1].Completed && Trash.totalBroken >= 5)
        {
            TotalCompleted += 1;
            Missions[1].Completed = true;
            CheckMissions();
        }
        if (!Missions[2].Completed && CentralSquare.dirty)
        {
            TotalCompleted += 1;
            Missions[2].Completed = true;
            CheckMissions();
        }
        if (!Missions[3].Completed && Hydrant.totalBroken >= 5)
        {
            TotalCompleted += 1;
            Missions[3].Completed = true;
            CheckMissions();
        }
        if (!Missions[4].Completed && Alarm.alarmRinging)
        {
            TotalCompleted += 1;
            Missions[4].Completed = true;
            CheckMissions();
        }
    }

    void CheckMissions()
    {
        if (Missions.Find(e => e.Completed == false) == null)
        {
            GameManager.Instance.GameOver(win: true);
        }
    }
}
