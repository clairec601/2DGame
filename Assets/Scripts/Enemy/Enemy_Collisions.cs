using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy_Collisions : MonoBehaviour
{

    [SerializeField] private AudioClip SFX;

    private AudioSource src;
    
    private void Start()
    {

        src = GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile")){

            StartCoroutine(Die());

        }

    }

    // wait until audio finishes
    IEnumerator Die()
    {
        src.PlayOneShot(SFX);
        yield return new WaitWhile(() => src.isPlaying);

        yield return new WaitForEndOfFrame();
        // do your thing here
        gameObject.SetActive(false);
    }

}
