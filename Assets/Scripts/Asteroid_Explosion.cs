using UnityEngine;

public class Asteroid_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // self destruct after 2.8 seconds from creation
        Invoke("SelfDestruct", 2.8f);
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
