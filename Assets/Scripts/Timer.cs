using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (PlayerPrefs.GetInt("timer") == 1)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
