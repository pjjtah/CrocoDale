using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour {

    public int hat = 0;
    public Sprite[] hatSprites;

	void Start () {
        hat = GlobalObject.data.selectedHat;
        if (hat == 0)
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = hatSprites[hat-1];
        }

    }
	
}
