using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float Range;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerStats.position) < Range)
        {
            active = true;
            playerStats.hidden = true;
        }
        else if (active == true)
        {
            active = false;
            playerStats.hidden = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
