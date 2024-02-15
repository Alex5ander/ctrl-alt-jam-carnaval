using System.Linq;
using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] Transform patrolArea;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] PlayerStats playerStats;
    Vector3 target;
    public bool IsPatrol = false;
    bool IgnoreRange = false;
    [SerializeField] AStar aStar;
    Node next;
    // Start is called before the first frame update
    void Start()
    {
        target = pointA.position;
        // transform.position = new(5, 5);
        // aStar.LoadNodes();
        // aStar.FindPath(aStar.nodes[5, 5], aStar.nodes[0, 5]);
        // next = aStar.path[0];
    }

    // Update is called once per frame
    void Update()
    {
        // FollowPath();
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

        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.fixedDeltaTime);
    }
    public void Call()
    {
        IgnoreRange = true;
    }
    public void FollowPath()
    {
        if (transform.position != new Vector3(next.x, next.y, transform.position.z))
        {
            transform.position = Vector3.MoveTowards(transform.position, new(next.x, next.y, transform.position.z), Time.deltaTime);
        }
        else
        {
            aStar.path.Remove(next);
            if (aStar.path.Count > 0)
            {
                next = aStar.path[0];
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
