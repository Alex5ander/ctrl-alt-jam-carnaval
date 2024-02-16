using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PoliceOfficers : ScriptableObject
{
    public List<PoliceOfficer> list = new();

    public void Call(Vector3 position)
    {
        PoliceOfficer nearPoliceOfficer = list[0];
        foreach (PoliceOfficer policeOfficer in list)
        {
            float d1 = Vector2.Distance(position, nearPoliceOfficer.transform.position);
            float d2 = Vector2.Distance(position, policeOfficer.transform.position);
            if (d2 < d1)
            {
                nearPoliceOfficer = policeOfficer;
            }
        }
        nearPoliceOfficer.Call();
    }
}
