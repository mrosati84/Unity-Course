using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.up * this._speed * Time.deltaTime);

        if (transform.position.y > 12.0f)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
