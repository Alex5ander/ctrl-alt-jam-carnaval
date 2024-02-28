using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float Range;
    [SerializeField] Mission mission;
    bool near = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z) && near && !audioSource.enabled)
        {
            audioSource.enabled = true;
            mission.AddScore();
        }
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
            near = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            near = false;
        }
    }
}
