using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float Range;
    [SerializeField] Mission mission;
    [SerializeField] PoliceOfficer policeOfficer;
    SpriteRenderer spriteRenderer;
    bool painted = false;
    static int amountPinted = 0;
    static int maxPinted = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxPinted += 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.mission != null && playerStats.mission.Completed == false && playerStats.mission == mission)
        {
            if (Vector3.Distance(transform.position, playerStats.position) < Range && Input.GetKeyUp(KeyCode.Z) && painted == false)
            {
                policeOfficer.Call();
                spriteRenderer.color = Color.red;
                amountPinted += 1;
                if (amountPinted == maxPinted)
                {
                    playerStats.mission.CompleteMission();
                }
                painted = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
