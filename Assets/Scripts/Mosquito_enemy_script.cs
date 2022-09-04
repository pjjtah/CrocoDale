using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito_enemy_script : MonoBehaviour {



    Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    public Transform player;
    private Transform enemy;
    public float force = 0.1f;
    public float speed = 0.5f;
    public float rotateSpeed = 200;
    private bool stuck;

    // Use this for initialization
    void Start()
    {
        stuck = true;
        enemy = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate() { 
        if (!stuck){


            if (enemy.rotation.eulerAngles.z > 90 && enemy.rotation.eulerAngles.z < 180)
            {
                spriteRenderer.flipY = true;
            }
            else
            {
                spriteRenderer.flipY = false;
            }

            Vector2 direction = (Vector2)player.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, -transform.right).z;

            rb.angularVelocity = -rotateAmount* rotateSpeed;


            Vector3.Cross(direction, -transform.right);

            rb.velocity = -transform.right* 10;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            stuck = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject,1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.transform.CompareTag("enemy"))
        {
            stuck = true;
            rb.velocity = new Vector3(0, 0, 0);

            rb.freezeRotation = true;
        }
        else
        {
            stuck = true;
        }

    }
}