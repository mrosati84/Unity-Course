using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private GameObject shieldPrefab;

    public GameObject getShield()
    {
        return this.shieldPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * this.speed * Time.deltaTime);

        // destroy powerup when off-screen
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
}
