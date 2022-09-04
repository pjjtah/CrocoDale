using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


    float spawnTime;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
        void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime == 0)
        {
            Destroy(gameObject, -1);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "death")
        {
            Destroy(gameObject, 1);
        }
    }

    private void OnBecameVisible()
    {
        rb.simulated = true;
        spawnTime = 2;
    }
    private void OnBecameInvisible()
    {
        if (spawnTime <0)
        {
            Destroy(gameObject, -1);
        }
   
    }
}
