using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] GameEvents gameEvents;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnValidate()
    {
        circleCollider2D.radius = Range;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            gameEvents.CallPolice(transform.position);
        }
    }
}
