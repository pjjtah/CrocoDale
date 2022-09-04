using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutMonkey : MonoBehaviour {

    Animator animator;
    Transform t;
    bool start;

    public Transform coconut;

    void Start () {
        animator = GetComponent<Animator>();
        t = GetComponent<Transform>();
	}


    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            animator.SetTrigger("Roll");
        }
    }

    public void LaunchCoconut()
    {
        GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(-10, 0);
        GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        coconut.parent = null;
        start = false;
    }
}
