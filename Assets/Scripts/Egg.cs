using UnityEngine;

public class Egg : ThrowableItem
{
    Vector3 direction;
    [SerializeField] float Speed;
    [SerializeField] ParticleSystem particles;
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
        if (used && !particles.gameObject.activeSelf)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, Time.fixedDeltaTime * Speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.TryGetComponent(out PlayerController _) && used)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            particles.gameObject.SetActive(true);
        }
    }

    public override void Use(Vector2 position, Vector2 direction)
    {
        transform.position = position;
        this.direction = direction;
        used = true;
        gameObject.SetActive(true);
    }
}
