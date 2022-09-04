using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant_script : MonoBehaviour {


    private Animator animator;
    public int up;
    public int forward;
    private AudioSource elephantAudio;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        elephantAudio = GetComponent<AudioSource>();
        elephantAudio.volume = PlayerPrefs.GetFloat("effects");
    }
	
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("elephant_trigger");
            elephantAudio.Play();
            collision.GetComponent<Rigidbody2D>().velocity += new Vector2(forward, up);
        }
    }
}
