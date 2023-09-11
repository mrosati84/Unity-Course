using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject[] powerUps = new GameObject[10];

    [SerializeField]
    private bool spawnEnemies = true;

    [SerializeField]
    private bool spawnPowerups = true;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 1.0f);
        InvokeRepeating("SpawnPowerUp", 2.0f, 2.0f);
    }

    void SpawnPowerUp()
    {
        if (this.isPlayerAlive() && this.spawnPowerups)
        {
            // pick a random powerup
            int randomIndex = Random.Range(0, this.powerUps.Length);

            // random x position for the powerup
            float randomX = transform.position.x + Random.Range(-5.0f, 5.0f);

            Vector3 position = new Vector3(randomX, transform.position.y, 0);

            Instantiate(this.powerUps[randomIndex], position, Quaternion.identity);
        }
    }

    void SpawnEnemy()
    {
        if (this.isPlayerAlive() && this.spawnEnemies)
        {
            float randomX = transform.position.x + Random.Range(-5.0f, 5.0f);
            Vector3 position = new Vector3(randomX, transform.position.y, 0);

            Instantiate(this.enemy, position, Quaternion.identity);
        }
    }

    bool isPlayerAlive()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Player playerScript = player.GetComponent<Player>();

            return playerScript.isAlive();
        }

        return false;
    }
}
