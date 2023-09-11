﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * this.speed * Time.deltaTime);

        if (transform.position.y < -5.2f)
        {
            // bottom reached, respawn
            //float randomX = Random.Range(-9.0f, 9.0f);
            //transform.position = new Vector3(randomX, 7.25f);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            // destroy the laser
            Destroy(other.gameObject);

            // destroy the enemy
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            // get the player script
            Player player = other.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }

            // destroy the enemy
            Destroy(this.gameObject);
        }
    }
}