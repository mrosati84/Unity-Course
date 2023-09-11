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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetScore(10);

            // destroy the enemy
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            // get the player script
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }

            // destroy the enemy
            Destroy(this.gameObject);
        }
    }
}
