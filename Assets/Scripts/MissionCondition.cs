using UnityEngine;

public class MissionCondition : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float Range;
    [SerializeField] Color RangeColor;
    [SerializeField] Mission mission;
    SpriteRenderer spriteRenderer;
    [SerializeField] PoliceOfficers policeOfficers;
    bool painted = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.mission != null && playerStats.mission.Completed == false && playerStats.mission == mission)
        {
            if (Vector3.Distance(transform.position, playerStats.position) < Range && Input.GetKeyUp(KeyCode.Space) && painted == false)
            {
                policeOfficers.Call(transform.position);
                spriteRenderer.color = Color.green;
                mission.score += 1;
                painted = true;
                if (mission.score == mission.maxScore)
                {
                    mission.CompleteMission();
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = RangeColor;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
