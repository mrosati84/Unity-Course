using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30.0f;

    [SerializeField]
    private GameObject explosion;

    // Update is called once per frame
    void Update()
    {   
        transform.Rotate(Vector3.forward * this.rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collide with laser
        if (collision.tag == "Laser")
        {
            // save current position
            Vector3 curPos = transform.position;

            // Instanciate the explosion
            Instantiate(this.explosion, curPos, Quaternion.identity);

            // destroy self
            Destroy(transform.gameObject, .25f);

            // destroy laser
            Destroy(collision.gameObject);
        }
    }
}
