using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

    public int world;
    public int[] maxScores = new int[6];

    void Start () {
        UpdateScores();
	}

    public void UpdateScores()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        //add scores and max scores
        for (int i =  0; i < maxScores.Length; i++)
        {
            Text level = texts[i];
            level.text = GlobalObject.data.levelScores[i+world*6+2].ToString() + "/" + maxScores[i].ToString();

        }

    }

}
