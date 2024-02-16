using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] public Transform patrolArea;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PoliceOfficers policeOfficers;
    Animator animator;
    Vector3 target;
    public bool IsPatrol = false;
    bool IgnoreRange = false;
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
        float targetDistance = Vector2.Distance(playerStats.position, transform.position);
        if ((targetDistance < Range || IgnoreRange) && !playerStats.hidden)
        {
            IsPatrol = false;
            target = playerStats.position;
        }
        else if (transform.position != patrolArea.position && IsPatrol == false)
        {
            target = patrolArea.position;
        }
        else if (transform.position == patrolArea.position)
        {
            IsPatrol = true;
            IgnoreRange = false;
        }

        if (IsPatrol)
        {
            if (transform.position == target)
            {
                target = target == pointA.position ? pointB.position : pointA.position;
            }
        }

        Vector2 direction = (target - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.fixedDeltaTime);
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
    public void Call()
    {
        IgnoreRange = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player") && playerStats.hidden == false)
        {
            GameManager.Instance.GameOver();
        }
    }
}
