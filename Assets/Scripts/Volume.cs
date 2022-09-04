using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        AudioSource[] s = GetComponents<AudioSource>();
            s[0].volume = PlayerPrefs.GetFloat("music");
            s[1].volume = PlayerPrefs.GetFloat("effects");
    }
}
