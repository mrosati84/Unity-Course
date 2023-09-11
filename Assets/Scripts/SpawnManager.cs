using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 1.0f);
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        // check if the player is alive
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Player playerScript = player.GetComponent<Player>();
            
            if (playerScript.isAlive())
            {
                float randomX = transform.position.x + Random.Range(-5.0f, 5.0f);
                Vector3 position = new Vector3(randomX, transform.position.y, 0);

                Instantiate(this.enemy, position, Quaternion.identity);
            }
        }
    }
}
