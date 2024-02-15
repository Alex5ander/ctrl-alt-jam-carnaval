using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] PlayerStats playerStats;
    float horizontal = 0;
    float vertical = 0;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(horizontal, vertical).normalized, Time.fixedDeltaTime * Speed);
        playerStats.position = transform.position;
    }
}
