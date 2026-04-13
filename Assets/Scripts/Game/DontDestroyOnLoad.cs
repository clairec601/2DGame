using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{

    [SerializeField] private AudioClip mainTheme;
    [SerializeField] private AudioClip winTheme;

    private AudioSource src;
    private bool playedWin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        src = GetComponent<AudioSource>();

        src.loop = true;

        src.clip = mainTheme;

        src.Play();

    }

    // Update is called once per frame
    void Update()
    {

        // on the last scene, play the win theme and stop there
        if (SceneManager.GetActiveScene().buildIndex == 3 && !playedWin)
        {

            src.loop = false;

            src.Stop();

            src.PlayOneShot(winTheme);

            playedWin = true;
        }

    }
}
