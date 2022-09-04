using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeValue : MonoBehaviour {
    public string s;

	// Use this for initialization
	void Start () {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(s)*10;
		
	}

}
