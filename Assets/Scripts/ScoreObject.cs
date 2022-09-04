using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreObject : MonoBehaviour {


    public Image[] collectiblesSprites;
    Color collectedColor = new Color(1,1,1);
    Color unCollectedColor = new Color(0.5f,0.5f,0.5f);
    // Use this for initialization
    void Start () {
		foreach(Image i in collectiblesSprites)
        {
            i.color = unCollectedColor;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Collect(int i)
    {
        collectiblesSprites[i].color = collectedColor;
    }
}
