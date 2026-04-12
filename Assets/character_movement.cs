using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Jump")]
    public float jumpForce = 5f;
    public int maxJumps = 2;
    public float airSpeed = 1f;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSFX;

    private AudioSource audioSource;

    private Rigidbody2D rb;
    private float moveInput_x;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        // Horizontal movement
        moveInput_x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveInput_x * speed, rb.linearVelocity.y);

        // Jump (limited)
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
        {

            audioSource.PlayOneShot(jumpSFX);

            // Reset vertical velocity for consistent jumps
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // Apply jump force
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            jumpCount++;
        }

    }



    //ground collisions

    //-Reset jump count when touching ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;

        }
    }

}