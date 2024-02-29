using UnityEngine;

public class PaintBucket : ThrowableItem
{
    Vector3 direction;
    [SerializeField] float Speed;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite InkSprite;
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
        used = true;
        spriteRenderer.sprite = InkSprite;
        transform.position = position;
        this.direction = direction;
        gameObject.SetActive(true);
    }
}
