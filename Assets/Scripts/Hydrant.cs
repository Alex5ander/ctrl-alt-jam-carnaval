using UnityEngine;

public class Hydrant : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] ParticleSystem particles;
    [SerializeField] float Range;
    bool broken = false;
    bool near = false;
    public static int totalBroken = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (near && Input.GetKeyUp(KeyCode.Z) && broken == false)
        {
            totalBroken += 1;
            particles.gameObject.SetActive(true);
            broken = true;
            PoliceOfficers.Call(transform.position);
        }
    }

    void OnValidate()
    {
        circleCollider2D.radius = Range;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            near = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            near = false;
        }
    }
}
