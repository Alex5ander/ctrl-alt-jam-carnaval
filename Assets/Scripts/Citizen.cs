using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] Transform target;
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
        float targetDistance = Vector2.Distance(target.position, transform.position);
        if (targetDistance < Range)
        {
            foreach (PoliceOfficer policeOfficer in policeOfficers)
            {
                policeOfficer.Call();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
