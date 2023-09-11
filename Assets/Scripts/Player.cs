using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction = Vector3.right;
    [SerializeField]
    private float speed = 10.0f;

    private float horizontalInput;
    private float verticalInput;

    private float upLimit = 5.8f;
    private float downLimit = -3.8f;
    private float leftLimit = -9.0f;
    private float rightLimit = 9.0f;

    private float fireRate = 0.5f;
    private float nextFire = 0.0f;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        // reposition the player
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > this.nextFire)
            {
                this.Fire();
                this.nextFire = Time.time + this.fireRate;
            }
        }
    }

    public void Damage()
    {
        this.lives--;

        if (this.lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public bool isAlive()
    {
        return this.lives > 0;
    }

    private void Fire()
    {
        Vector3 firePosition = new Vector3(transform.position.x, transform.position.y + .8f);
        Instantiate(this.laser, firePosition, Quaternion.identity);
    }

    private void Move()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.verticalInput = Input.GetAxis("Vertical");

        if (transform.position.y >= this.upLimit)
        {
            transform.position = new Vector3(transform.position.x, this.upLimit);
        }

        if (transform.position.y <= this.downLimit)
        {
            transform.position = new Vector3(transform.position.x, this.downLimit);
        }

        if (transform.position.x >= this.rightLimit)
        {
            transform.position = new Vector3(this.rightLimit, transform.position.y);
        }

        if (transform.position.x <= this.leftLimit)
        {
            transform.position = new Vector3(this.leftLimit, transform.position.y);
        }

        transform.Translate(new Vector3(this.horizontalInput, this.verticalInput, 0) * this.speed * Time.deltaTime);
    }
}
