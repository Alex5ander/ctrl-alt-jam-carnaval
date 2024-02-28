using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] SpriteMask spriteMask;
    [SerializeField] Mission mission;
    [SerializeField] GameEvents gameEvents;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent(out PaintBucket _) && !spriteMask.enabled)
        {
            mission.AddScore();
            spriteMask.enabled = true;
            gameEvents.CallPolice(transform.position);
            Destroy(collider2D.gameObject);
        }
    }
}
