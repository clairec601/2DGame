using UnityEngine;
using System.Collections;

public class character_collisions : MonoBehaviour
{
    [SerializeField] private float respawnTimer = 2f;
    [SerializeField] private Transform respawnPoint;

    [Header("SFX")]
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip resSFX;

    private AudioSource audioSource;

    private Vector3 spawnPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = respawnPoint != null ? respawnPoint.position : transform.position;
        transform.position = spawnPosition;
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Kill")) && !isDead)
            StartCoroutine(Respawn());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kill") && !isDead)
            StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        isDead = true;

        // Hide without deactivating
        spriteRenderer.enabled = false;
        col.enabled = false;
        rb.simulated = false;
        rb.linearVelocity = Vector2.zero;

        audioSource.PlayOneShot(deathSFX);

        yield return new WaitForSeconds(respawnTimer);

        // Respawn
        transform.position = spawnPosition;
        spriteRenderer.enabled = true;
        col.enabled = true;
        rb.simulated = true;
        isDead = false;

        audioSource.PlayOneShot(resSFX);
    }

    public bool IsDead()
    {
        return isDead;
    }
}