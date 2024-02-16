using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] PlayerStats playerStats;
    float horizontal = 0;
    float vertical = 0;
    Animator animator;
    Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerStats.Reset();
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
    }

    void FixedUpdate()
    {
        Vector2 newPos = transform.position + Speed * Time.fixedDeltaTime * new Vector3(horizontal, vertical).normalized;
        rigidBody2D.MovePosition(newPos);
        playerStats.position = transform.position;
    }
}
