using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float Range;
    [SerializeField] Mission mission;
    [SerializeField] List<PoliceOfficer> policeOfficers;
    SpriteRenderer spriteRenderer;
    bool painted = false;
    static int score = 0;
    static int maxScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxScore += 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool InRange = Vector3.Distance(transform.position, playerStats.position) < Range;
        if (InRange)
        {
            foreach (PoliceOfficer policeOfficer in policeOfficers)
            {
                policeOfficer.Call();
            }
        }
        if (playerStats.mission != null && playerStats.mission.Completed == false && playerStats.mission == mission)
        {
            if (InRange && Input.GetKeyUp(KeyCode.Space) && painted == false)
            {
                spriteRenderer.color = Color.green;
                score += 1;
                painted = true;
                if (score == maxScore)
                {
                    playerStats.mission.CompleteMission();
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
