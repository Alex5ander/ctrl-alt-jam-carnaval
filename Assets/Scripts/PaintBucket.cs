using UnityEngine;

public class PaintBucket : ThrowableItem
{
    Vector3 direction;
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (used)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, Time.fixedDeltaTime * Speed);
        }
    }

    public override void Use(Vector2 position, Vector2 direction)
    {
        transform.position = position;
        gameObject.SetActive(true);
        used = true;
        this.direction = direction;
    }
}
