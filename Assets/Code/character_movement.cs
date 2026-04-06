using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Jump")]
    public float jumpForce = 5f;
    public int maxJumps = 2;
    public float airSpeed = 2f;

    private Rigidbody2D rb;
    private float moveInput_x;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        moveInput_x = Input.GetAxisRaw("Horizontal");
      
        rb.linearVelocity = new Vector2(moveInput_x * speed, rb.linearVelocity.y);

        // apply extra gravity to jump faster
        if (rb.linearVelocity.y < 0)
        {
            //falling
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * airSpeed * 1.25f * Time.deltaTime;

        }else if (rb.linearVelocity.y > 0){
            // rising
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * airSpeed * Time.deltaTime;
        }

        // Jump (limited)
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
        {
            // Reset vertical velocity for consistent jumps
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // Apply jump force
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            jumpCount++;
        }

    }

    // Reset jump count when touching ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}