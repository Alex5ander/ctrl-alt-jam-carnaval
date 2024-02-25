using UnityEngine;

public class CentralSquare : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] GameObject particles;
    [SerializeField] float Range;
    public static bool dirty = false;
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
        if (collider2D.TryGetComponent(out Egg egg) && !dirty)
        {
            dirty = true;
            particles.transform.position = egg.transform.position;
            particles.SetActive(true);
            Destroy(egg.gameObject);
        }
    }
}
