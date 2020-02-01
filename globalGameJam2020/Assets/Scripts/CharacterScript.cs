using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public static bool win;
    public float velocity;
    public float jump;
    public Rigidbody2D rdb2d;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;

    private int itemCount;
    private ArrayList itemArray = new ArrayList();
    private bool isMoving;
    private bool isGrounded;
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
        Debug.Log(win);
        if (itemCount >= 3)
        {
            win = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if(collision.gameObject.tag == "Item")
        {
            //itemArray.Add(collision.gameObject.tag);
            itemCount++;
            Destroy(collision.gameObject);
            Debug.Log(itemCount);
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
