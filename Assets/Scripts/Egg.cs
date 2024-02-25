using UnityEngine;

public class Egg : MonoBehaviour, ThrowableItem
{
    Vector3 direction;
    bool used = false;
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

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out PlayerController playerController) && !used)
        {
            if (playerController.collectible == null)
            {
                playerController.collectible = this;
                gameObject.SetActive(false);
            }
        }
    }

    public void Use(Vector2 position, Vector2 direction)
    {
        transform.position = position;
        this.direction = direction;
        used = true;
        gameObject.SetActive(true);
    }
}
