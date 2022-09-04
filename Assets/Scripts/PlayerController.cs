using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    private Animator animator;

    public Button tryAgain;
    public Button levelSelect;
    public Button nextlevel;

    private LayerMask ground;

    public bool stoppedJumping;

    bool canJump;
    bool finish;

    ParticleSystem dust;

    AudioSource audioSource;
    AudioSource music;

    public AudioClip jumpSound;
    public AudioClip collectibleSound;
    public AudioClip enemyHitSound;
    public AudioClip finishSound;



    private int score;
    public ScoreObject scoreObject;


    // Use this for initialization
    void Start()
    {
        score = 0;
        animator = GetComponent<Animator>();

        ground =  LayerMask.GetMask("Ground");

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);


        tryAgain.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(false);
        nextlevel.gameObject.SetActive(false);
        stoppedJumping = true;

        audioSource = GetComponents<AudioSource>()[0];
        audioSource.volume = PlayerPrefs.GetFloat("effects");
        music = GetComponents<AudioSource>()[1];
        music.volume = PlayerPrefs.GetFloat("music");

        dust = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (rb != null)
        {
            //change animation depending how fast croko is moving
            if (rb.velocity.x < 2)
            {
                animator.enabled = false;
            }
            else
            {
                animator.enabled = true;
            }
            //make sure croko keeps moving
            if (rb.velocity.x < speed)
            {
                rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
            }

            //check if croko is grounded and playing right animation
            canJump = (Physics2D.Raycast(rb.position + Vector2.left * 0.5f, Vector2.down, 0.7f, ground));
            animator.SetBool("croco_jump2", !canJump);

            if (canJump)
            {
                if(dust.isEmitting != true)
                {

                    dust.Play();
                }
                jumpTimeCounter = jumpTime;
            }
            else
            {
                if (dust.isEmitting != false)
                {
                    dust.Stop();
                }
            }


            //try jumping
            if ((Input.GetMouseButton(0)) && canJump && !finish)
            {
                animator.SetTrigger("croco_jump");
                audioSource.clip = jumpSound;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stoppedJumping = false;
            }
            if ((Input.GetMouseButton(0)) && !stoppedJumping)
            {
                //jump higher if counter hasnt reached zero
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                //stop jumping and set counter to zero
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy"))
        {

            audioSource.clip = enemyHitSound;
            audioSource.Play();

            Destroy(rb);
            Destroy(gameObject, 1);
            ShowTryAgainCanvas();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("snow"))
        {
            speed = 2.5f;
            rb.velocity = new Vector2(2.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.transform.CompareTag("death"))
        {
            CameraController.finish = true;
            finish = true;

            ShowTryAgainCanvas();
        }
        else if (collision.transform.CompareTag("Finish"))
        {
            audioSource.clip = finishSound;
            audioSource.Play();
            GetComponents<AudioSource>()[1].Stop();


            levelSelect.gameObject.SetActive(true);
            levelSelect.GetComponent<Animation>().Play("quit_button");
            nextlevel.gameObject.SetActive(true);
            nextlevel.GetComponent<Animation>().Play("play_again_button");
            CameraController.finish = true;
            finish = true;


            //save score and level completion 
            GlobalObject.data.completedLevels[SceneManager.GetActiveScene().buildIndex] = true;
            if(GlobalObject.data.levelScores[SceneManager.GetActiveScene().buildIndex] < score)
            {
                GlobalObject.data.levelScores[SceneManager.GetActiveScene().buildIndex] = score;
                GlobalObject.Instance.SaveData();
            }
        }
        else if (collision.transform.CompareTag("collectible"))
        {
            audioSource.clip = collectibleSound;
            audioSource.Play();
            Destroy(collision.gameObject);
            score++;
            scoreObject.Collect(score - 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("snow"))
        {
            speed = 6;
        }
    }

    public void ShowTryAgainCanvas()
    {
        Destroy(gameObject, 1f);
        tryAgain.gameObject.SetActive(true);
        tryAgain.GetComponent<Animation>().Play("play_again_button");
        levelSelect.gameObject.SetActive(true);
        levelSelect.GetComponent<Animation>().Play("quit_button");
        tryAgain.onClick.AddListener(TryAgain);
    }

    public void TryAgain()
    {
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public bool IsGrounded()
    {
        return canJump;
    }




}
