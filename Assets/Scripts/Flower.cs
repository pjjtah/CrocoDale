using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    Animator a;
	// Use this for initialization
	void Start () {
        a = GetComponent<Animator>();
        a.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnBecameVisible()
    {
        a.enabled = true;
    }
}
