using UnityEngine;

public class House : MonoBehaviour
{
    bool painted = false;
    public static int totalPainted = 0;
    [SerializeField] SpriteMask spriteMask;
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
        if (collider2D.gameObject.TryGetComponent(out PaintBucket paintBucket) && !painted)
        {
            spriteMask.enabled = true;
            totalPainted += 1;
            painted = true;
            PoliceOfficers.Call(transform.position);
            Destroy(paintBucket.gameObject);
        }
    }
}
