using UnityEngine;

public class PoliceOfficers : MonoBehaviour
{
    PoliceOfficer[] policeOfficers;
    public PlayerController playerController;
    static public PoliceOfficers Instance;
    void Start()
    {
        Instance = this;
        policeOfficers = (PoliceOfficer[])FindObjectsByType(typeof(PoliceOfficer), FindObjectsSortMode.None);
    }
    public static void Call(Vector3 position)
    {

        PoliceOfficer nearPoliceOfficer = Instance.policeOfficers[0];
        foreach (PoliceOfficer policeOfficer in Instance.policeOfficers)
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
