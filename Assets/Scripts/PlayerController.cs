using UnityEngine;

public abstract class ThrowableItem : MonoBehaviour
{
    public bool used = false;
    public abstract void Use(Vector2 position, Vector2 direction);
}

public class PlayerController : MonoBehaviour, IDpadListener
{
    [SerializeField] float Speed;
    [SerializeField] Player player;
    [SerializeField] GameEvents gameEvents;
    float horizontal = 0;
    float vertical = 0;
    Animator animator;
    Rigidbody2D rigidBody2D;
    bool hidde = false;
    public ThrowableItem item;
    readonly KeyCode[] keyCodes = {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.UpArrow,
        KeyCode.RightArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow
    };
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        gameEvents.dpadListeners.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode) || Input.GetKeyUp(keyCode))
            {
                horizontal = Input.GetAxisRaw("Horizontal") * Time.timeScale;
                vertical = Input.GetAxisRaw("Vertical") * Time.timeScale;
            }
        }

        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("LastMoveX", horizontal);
            animator.SetFloat("LastMoveY", vertical);
        }

        if (Input.GetKeyUp(KeyCode.X) && !hidde)
        {
            UseItem();
        }
        player.position = transform.position;
        player.hidde = hidde;
    }

    void FixedUpdate()
    {
        Vector2 newPos = transform.position + Speed * Time.fixedDeltaTime * new Vector3(horizontal, vertical).normalized;
        rigidBody2D.MovePosition(newPos);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out ThrowableItem item))
        {
            if (!item.used && this.item == null)
            {
                gameEvents.SetItemSprite(collider2D.gameObject.GetComponent<SpriteRenderer>().sprite);
                collider2D.gameObject.SetActive(false);
                this.item = item;
            }
        }
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use(transform.position, new(animator.GetFloat("LastMoveX"), animator.GetFloat("LastMoveY")));
            item = null;
            gameEvents.SetItemSprite(null);
        }
    }
    public void SetHidde(bool hidde)
    {
        this.hidde = hidde;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = hidde ? 0.5f : 1;
        spriteRenderer.color = color;
    }

    public void OnTouchChange(Vector2 direction)
    {
        horizontal = direction.x;
        vertical = direction.y;
    }
}
