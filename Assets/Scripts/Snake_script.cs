using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_script : MonoBehaviour {

    Rigidbody2D rb;
    bool stuck;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        stuck = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!stuck)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
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
            Destroy(gameObject, 1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "death")
        {
            Destroy(gameObject, 1);
        }
    }

}
