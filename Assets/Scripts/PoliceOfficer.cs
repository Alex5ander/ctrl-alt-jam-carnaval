using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;
    Animator animator;
    Vector2 target;
    bool IsPatrol = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pointA += (Vector2)transform.position;
        pointB += (Vector2)transform.position;
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
            if (transform.position == (Vector3)target)
            {
                target = target == pointA ? pointB : pointA;
            }
        }
        else if (!PoliceOfficers.Instance.playerController.hidde)
        {
            target = PoliceOfficers.Instance.playerController.transform.position;
        }
        else
        {
            IsPatrol = true;
            target = pointA;
        }
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, (Vector3)target, Speed * Time.fixedDeltaTime);
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
    public void Call()
    {
        IsPatrol = false;
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
        Gizmos.DrawWireSphere(transform.position + (Vector3)pointA, 0.25f);
        Gizmos.DrawWireSphere(transform.position + (Vector3)pointB, 0.25f);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player") && !PoliceOfficers.Instance.playerController.hidde)
        {
            GameManager.Instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player") && !PoliceOfficers.Instance.playerController.hidde)
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
}
