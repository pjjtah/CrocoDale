using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShroom : MonoBehaviour
{

    private Animator animator;
    public int up;
    public int forward;
    private AudioSource shroomAudio;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        shroomAudio = GetComponent<AudioSource>();
        shroomAudio.volume = PlayerPrefs.GetFloat("effects");
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("shroom_trigger");
            shroomAudio.Play();
            collision.GetComponent<Rigidbody2D>().velocity += new Vector2(forward, up);
        }
    }
}