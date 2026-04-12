using UnityEngine;
using UnityEngine.SceneManagement;

public class progress_level : MonoBehaviour
{

    [Header("SFX")]
    [SerializeField] private AudioClip SFX;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            audioSource.PlayOneShot(SFX);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}