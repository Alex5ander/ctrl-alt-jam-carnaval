using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] PlayerStats playerStats;
    Vector3 startPosition;
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Vector3.Distance(playerStats.position, transform.position) < Range && hit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerStats.position, Time.deltaTime * Speed);
        }
        else if (transform.position != startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * Speed);
        }
        else if (transform.position == startPosition && hit == true)
        {
            hit = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player") && hit == false)
        {
            hit = true;
            playerStats.TimeLeft -= 5;
        }
    }
}
