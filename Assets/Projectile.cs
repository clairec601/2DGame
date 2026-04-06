using UnityEngine;

public class Projectile : MonoBehaviour
{

    //vars
    [SerializeField] private float speed = 10f;
    

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * Time.deltaTime * speed; 
        
    }

    //collision method
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
        {

            projectileKill();

        }
        
    }

    //method for any onDeath behavior
    void projectileKill()
    {

        //destroy the object
        Destroy(gameObject);

    }
}
