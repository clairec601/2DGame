 using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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

            StartCoroutine(ProgressAfterAudio());

        }
    }

    // wait until audio finishes
    IEnumerator ProgressAfterAudio()
    {
        audioSource.PlayOneShot(SFX);
        yield return new WaitWhile(() => audioSource.isPlaying);
        // do your thing here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}