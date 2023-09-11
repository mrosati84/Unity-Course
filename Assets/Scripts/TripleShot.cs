using UnityEngine;

public class TripleShot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            // destroy the parent object when all 3 lasers are gone
            Destroy(this.gameObject);
        }
    }
}
