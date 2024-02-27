using UnityEngine;

public interface ThrowableItem
{
    public void Use(Vector2 position, Vector2 direction);
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed;
    float horizontal = 0;
    float vertical = 0;
    Animator animator;
    Rigidbody2D rigidBody2D;
    public bool hidde = false;
    public ThrowableItem collectible;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * Time.timeScale;
        vertical = Input.GetAxisRaw("Vertical") * Time.timeScale;

        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("LastMoveX", horizontal);
            animator.SetFloat("LastMoveY", vertical);
        }

        if (Input.GetKeyUp(KeyCode.X) && !hidde)
        {
            if (collectible != null)
            {
                collectible.Use(transform.position, new(animator.GetFloat("LastMoveX"), animator.GetFloat("LastMoveY")));
                collectible = null;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 newPos = transform.position + Speed * Time.fixedDeltaTime * new Vector3(horizontal, vertical).normalized;
        rigidBody2D.MovePosition(newPos);
    }

    public void SetHidde(bool hidde)
    {
        this.hidde = hidde;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = hidde ? 0.5f : 1;
        spriteRenderer.color = color;
    }
}
