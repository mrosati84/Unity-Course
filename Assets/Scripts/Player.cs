using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    private float horizontalInput;
    private float verticalInput;

    private float upLimit = 5.8f;
    private float downLimit = -3.8f;
    private float leftLimit = -9.0f;
    private float rightLimit = 9.0f;

    [SerializeField]
    private float fireRate = 0.2f;
    private float nextFire = 0.0f;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private GameObject laser;

    [SerializeField]
    private GameObject tripleLaser;

    [SerializeField]
    private bool tripleShotActive = false;

    [SerializeField]
    private bool shieldActive = false;

    [SerializeField]
    private GameObject UIManager;

    [SerializeField]
    private int score = 0;

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
                // set cooldown
                this.nextFire = Time.time + this.fireRate;
            }
        }
    }

    public void Damage()
    {
        this.lives--;

        // set lives in the UI
        this.UIManager.GetComponent<UIManager>().setLives(this.lives);

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
        Vector3 firePosition = new Vector3(transform.position.x, transform.position.y + 1.05f);

        if (this.tripleShotActive)
        {
            Instantiate(this.tripleLaser, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(this.laser, firePosition, Quaternion.identity);
        }
        
    }

    public void setScore(int amount)
    {
        this.score += amount;

        // update the score UI
        this.UIManager.GetComponent<UIManager>().setScoreText(this.score);
    }

    public void setShield(bool value)
    {
        this.shieldActive = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collect powerups
        if (collision.tag == "TripleShot" && !this.tripleShotActive)
        {
            Destroy(collision.gameObject);
            this.tripleShotActive = true;

            // disable triple shot after X seconds
            StartCoroutine(DisableTripleLaser());
        }
        if (collision.tag == "ShieldPowerup" && !this.shieldActive)
        {
            // Instantiate the shield
            ShieldPowerup shieldPowerupScript = collision.GetComponent<ShieldPowerup>();
            GameObject shieldPrefab = shieldPowerupScript.getShield();

            this.setShield(true);

            // instantiate the shield
            Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DisableTripleLaser()
    {
        yield return new WaitForSeconds(5);
        this.tripleShotActive = false;
    }

    private void Move()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.verticalInput = Input.GetAxis("Vertical");

        // prevent moving off screen limits
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
