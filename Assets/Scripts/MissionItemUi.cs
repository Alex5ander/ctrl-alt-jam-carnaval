using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI : MonoBehaviour, IMissionEventListener
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    public Mission mission;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Init(Mission mission)
    {
        this.mission = mission;
        mission.listeners.Add(this);
        title.SetText(mission.Title);
        description.SetText(mission.Description);
    }
    public void OnCompleted()
    {
        image.color = Color.green;
    }
    void OnDestroy()
    {
        mission.listeners.Remove(this);
    }
}
