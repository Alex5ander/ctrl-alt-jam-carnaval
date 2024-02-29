using TMPro;
using UnityEngine;

public class MissionStatus : MonoBehaviour, IMissionEventListener
{
    [SerializeField] TextMeshProUGUI MissionStatusUI;
    [SerializeField] Mission[] Missions;
    [SerializeField] GameEvents gameEvents;
    int totalCompleted = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Mission mission in Missions)
        {
            mission.listeners.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        foreach (Mission mission in Missions)
        {
            mission.listeners.Remove(this);
        }
    }
    public void OnCompleted()
    {
        totalCompleted += 1;
        MissionStatusUI.SetText("Missões: " + totalCompleted + "/" + Missions.Length);
        if (totalCompleted == 5)
        {
            gameEvents.GameOver(true);
        }
    }
}
