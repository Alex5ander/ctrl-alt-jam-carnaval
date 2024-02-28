using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;
    [SerializeField] Player player;
    [SerializeField] GameEvents gameEvents;
    Animator animator;
    Vector3 target;
    bool IsPatrol = true;
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.policeOfficers.Add(this);
        animator = GetComponent<Animator>();
        target = pointA;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (IsPatrol)
        {
            if (transform.position == target)
            {
                target = target == (Vector3)pointA ? pointB : pointA;
            }
        }
        else
        {
            target = player.position;
            if (player.hidde)
            {
                IsPatrol = true;
                target = pointA;
            }
        }
        Vector2 direction = (target - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.fixedDeltaTime);
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
    void OnValidate()
    {
        circleCollider2D.radius = Range;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointA, 0.25f);
        Gizmos.DrawWireSphere(pointB, 0.25f);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player") && !player.hidde)
        {
            gameEvents.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player") && !player.hidde)
        {
            IsPatrol = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            IsPatrol = true;
        }
    }

    public void Call()
    {
        IsPatrol = false;
    }

    void OnDestroy()
    {
        gameEvents.policeOfficers.Remove(this);
    }
}
