using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] List<PoliceOfficer> policeOfficers;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerStats.position, transform.position) < Range)
        {
            PoliceOfficer nearPoliceOfficer = policeOfficers[0];
            foreach (PoliceOfficer policeOfficer in policeOfficers)
            {
                float d1 = Vector2.Distance(transform.position, nearPoliceOfficer.transform.position);
                float d2 = Vector2.Distance(transform.position, policeOfficer.transform.position);
                if (d2 < d1)
                {
                    nearPoliceOfficer = policeOfficer;
                }
            }
            nearPoliceOfficer.Call();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
