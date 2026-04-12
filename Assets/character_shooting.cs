using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class character_shooting : MonoBehaviour
{

    [Header("ProjectileInfo")]

    public Projectile projectilePrefab;

    public Transform launchOffset;

    public float cooldown = 2f;

    private float moveInput_x;

    private bool can_shoot = true;

    private float direction = -1f;

    [Header("SFX")]
    [SerializeField] private AudioClip SFX;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        // Horizontal movement
        moveInput_x = Input.GetAxisRaw("Horizontal");

        // Flip direction
        if (moveInput_x != 0)
        {

            direction = moveInput_x;

            //rotate the direction of spawning bullets
            launchOffset.localPosition = new Vector3(moveInput_x, launchOffset.localPosition.y, 0);

            //rotate the launch direction depending on the movement input
            launchOffset.rotation = new Quaternion(0, 0, moveInput_x > 0 ? 0 : 180, 0);

        }

        // Shoot
        if (can_shoot && Input.GetKeyDown(KeyCode.U))
        {

            Instantiate(projectilePrefab, launchOffset.position, launchOffset.rotation);

            audioSource.PlayOneShot(SFX);

            StartCoroutine(ShootCooldown());

        }

    }

    //cooldown coroutine
    IEnumerator ShootCooldown()
    {
        can_shoot  = false;

        //waits "cooldown" seconds to turn shooting back on
        yield return new WaitForSeconds(cooldown); // cooldown time

        can_shoot = true;
    }

}
