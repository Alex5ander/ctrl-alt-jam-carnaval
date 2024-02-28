using UnityEngine;

public class CentralSquare : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] Mission mission;
    [SerializeField] GameEvents gameEvents;
    bool dirty = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, boxCollider2D.size);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Egg _) && !dirty)
        {
            dirty = true;
            mission.AddScore();
            gameEvents.CallPolice(transform.position);
        }
    }
}
