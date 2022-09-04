using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelButton : MonoBehaviour {

    public int i;
    

    // Use this for initialization
    void Start()
    {
        HideIfNotCompleted(i);
    }

    public void HideIfNotCompleted(int i)
    {
        if (GlobalObject.data.completedLevels[i])
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
