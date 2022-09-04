using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {
    bool animate;

    Transform t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (animate)
        {
            t.position = new Vector2(t.position.x + 6 * Time.deltaTime, t.position.y);
        }
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animate = true;
        }
    }
}
