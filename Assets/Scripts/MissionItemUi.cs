using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    public Mission mission;
    void Update()
    {
        if (mission.Completed && image.color != Color.green)
        {
            image.color = Color.green;
        }
    }
    public void Init(Mission mission)
    {
        this.mission = mission;
        title.SetText(mission.Title);
        description.SetText(mission.Description);
    }
}
