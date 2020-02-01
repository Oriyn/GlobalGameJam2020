using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float velocity;
    public float jump;
    public Rigidbody2D rdb2d;
    private bool isMoving;
    private bool isGrounded;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rdb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        isMoving = false;
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            isMoving = true;
            rdb2d.velocity = new Vector2(rdb2d.velocity.x, jump);
            animator.SetFloat("Speed", jump);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            mySpriteRenderer.flipX = false;
            animator.SetFloat("Speed", velocity);
            rdb2d.velocity = new Vector2(velocity, rdb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            mySpriteRenderer.flipX = true;
            animator.SetFloat("Speed", velocity);
            rdb2d.velocity = new Vector2(-velocity, rdb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
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
    }
}
