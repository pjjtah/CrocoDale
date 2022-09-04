using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaf : MonoBehaviour {

    FixedJoint2D joint;
    BoxCollider2D c;
    

	// Use this for initialization
	void Start () {
        joint = GetComponent<FixedJoint2D>();
        c = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(joint, 0.02f);
            Destroy(c, 2);
            Destroy(this.gameObject, 5);
        }
    }
}
