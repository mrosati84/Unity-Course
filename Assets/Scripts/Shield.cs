using UnityEngine;

public class Shield : MonoBehaviour
{
    private Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // set the shield as player's child
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.parent = player.transform;

        // get the player script
        this.playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // move along with the parent
        transform.position = transform.parent.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            // trigger enemy explosion animation
            collision.GetComponent<Animator>().SetTrigger("OnEnemyDestroy");

            // disable the enemy box collider
            collision.GetComponent<BoxCollider2D>().enabled = false;

            // destroy the enemy
            Destroy(collision.gameObject, 2.8f);

            // destroy the shield
            Destroy(this.gameObject);

            // unset the shield on the player
            this.playerScript.SetShield(false);
        }
    }
}
