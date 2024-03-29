using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] CircleCollider2D circleCollider2D;
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
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.gameObject.GetComponent<PlayerController>().SetHidde(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.gameObject.GetComponent<PlayerController>().SetHidde(false);
        }
    }
}
