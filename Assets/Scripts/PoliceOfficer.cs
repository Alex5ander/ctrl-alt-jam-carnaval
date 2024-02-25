using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] public Transform patrolArea;
    [SerializeField] PoliceOfficers policeOfficers;
    Animator animator;
    Vector3 target;
    PlayerController playerController;
    bool IsPatrol = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        policeOfficers.list.Add(this);
        target = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (transform.position == target && IsPatrol)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
        if (IsPatrol == false)
        {
            target = playerController.transform.position;
        }
        Vector2 direction = (target - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.fixedDeltaTime);
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
    public void Call()
    {

    }
    void OnValidate()
    {
        circleCollider2D.radius = Range;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            IsPatrol = false;
            playerController = collider2D.gameObject.GetComponent<PlayerController>();
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            IsPatrol = true;
            target = patrolArea.position;
        }
    }
}
