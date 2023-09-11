using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * this.speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            // destroy the laser
            Destroy(collision.gameObject);

            // add score
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                player.GetComponent<Player>().SetScore(10);
            }
            

            // trigger explosion animation
            GetComponent<Animator>().SetTrigger("OnEnemyDestroy");

            // disable the box collider
            GetComponent<BoxCollider2D>().enabled = false;

            // destroy the enemy
            Destroy(this.gameObject, 2.8f);
        }
        
        else if (collision.tag == "Player")
        {
            // get the player script
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();

                // trigger explosion animation
                GetComponent<Animator>().SetTrigger("OnEnemyDestroy");

                // disable the box collider
                GetComponent<BoxCollider2D>().enabled = false;

                // destroy the enemy
                Destroy(this.gameObject, 2.8f);
            }
        }
    }
}
