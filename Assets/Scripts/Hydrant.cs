using UnityEngine;

public class Hydrant : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] ParticleSystem particles;
    [SerializeField] float Range;
    [SerializeField] Mission mission;
    [SerializeField] GameEvents gameEvents;
    bool broken = false;
    bool near = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (near && Input.GetKeyUp(KeyCode.Z) && !broken)
        {
            broken = true;
            particles.gameObject.SetActive(true);
            mission.AddScore();
            gameEvents.CallPolice(transform.position);
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
            gameEvents.SetHint("Precione Z para interagir");
            near = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            gameEvents.SetHint("");
            near = false;
        }
    }
}
