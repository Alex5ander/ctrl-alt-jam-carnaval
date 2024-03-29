using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] float Range;
    [SerializeField] Mission mission;
    [SerializeField] GameEvents gameEvents;
    [SerializeField] GameObject TouchIcon;
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
            Brake();
        }

        if (!broken && near)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction);
                if (raycastHit2D)
                {
                    if (raycastHit2D.collider.gameObject == gameObject)
                    {
                        Brake();
                    }
                }
            }
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
        if (collider2D.CompareTag("Player") && !broken)
        {
            gameEvents.SetHint("Precione Z para interagir");
            TouchIcon.SetActive(true);
            near = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            gameEvents.SetHint("");
            TouchIcon.SetActive(false);
            near = false;
        }
    }

    void Brake()
    {
        transform.rotation = Quaternion.AngleAxis(45f, Vector3.forward);
        broken = true;
        mission.AddScore();
        gameEvents.CallPolice(transform.position);
    }
}
