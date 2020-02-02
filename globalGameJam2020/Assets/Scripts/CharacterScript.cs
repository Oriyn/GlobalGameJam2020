using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public bool win;
    public static bool dead;
    public bool dying;
    public float velocity;
    public float jump;
    public Rigidbody2D rdb2d;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;
    public int playerHealth = 4;
    public int itemCount;
    public AudioClip walking;
    public AudioClip jumping;
    public AudioClip lazer;
    private AudioSource audio;
    private ArrayList itemArray = new ArrayList();
    private bool isMoving;
    private bool isGrounded;
    private float timeLeft = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rdb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(win);
        if (itemCount >= 2)
        {
            win = true;
        }
        if (Input.GetKey(KeyCode.R) && dead)
        {
            Time.timeScale = 1;
            Application.LoadLevel(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Edge")
        {
            isGrounded = true;
        }
        if(collision.gameObject.tag == "Item")
        {
            //itemArray.Add(collision.gameObject.tag);
            itemCount++;
            Destroy(collision.gameObject);
            //Debug.Log(itemCount);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth -= 1;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && collision.gameObject.tag != "Edge")
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        isMoving = false;
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            audio.clip = jumping;
            audio.Play();
            isMoving = true;
            rdb2d.velocity = new Vector2(rdb2d.velocity.x, jump);
            animator.SetFloat("Speed", jump);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            audio.clip = walking;
            audio.Play();
            isMoving = true;
            mySpriteRenderer.flipX = false;
            animator.SetFloat("Speed", velocity);
            rdb2d.velocity = new Vector2(velocity, rdb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            audio.clip = walking;
            audio.Play();
            isMoving = true;
            mySpriteRenderer.flipX = true;
            animator.SetFloat("Speed", velocity);
            rdb2d.velocity = new Vector2(-velocity, rdb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            audio.clip = lazer;
            audio.Play();
            animator.SetBool("isShooting", true);
        } else
        {
            animator.SetBool("isShooting", false);
        }
        if (isMoving == false)
        {
            animator.SetFloat("Speed", 0);
            rdb2d.velocity = new Vector2(0, rdb2d.velocity.y);
        }
        if (playerHealth <= 0)
        {
            Debug.Log(playerHealth);
            // add loadlevel logic
            dying = true;
            dead = true;
            animator.SetBool("Isdead", true);
            timeLeft -= Time.deltaTime;
            velocity = 0;
            jump = 0;
            mySpriteRenderer = null;
            if (timeLeft <= 0.0f)
            {
                Time.timeScale = 0;
            }
        }
    }
}
