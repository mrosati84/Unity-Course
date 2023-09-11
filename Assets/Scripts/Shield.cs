using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // set the shield as player's child
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.parent = player.transform;
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
            // destroy the enemy
            Destroy(collision.gameObject);

            // destroy the shield
            Destroy(this.gameObject);
        }
    }
}
