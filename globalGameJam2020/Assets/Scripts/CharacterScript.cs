using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float bulletSpeed;
    public float velocity;
    public float jump;
    public Rigidbody2D rdb2d;
    private bool isMoving;
    private bool isGrounded;
    public GameObject bullet;
    public bool isLeft = false;
    public bool isRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rdb2d = gameObject.GetComponent<Rigidbody2D>();
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
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isLeft = false;
            isRight = true;
            isMoving = true;
            rdb2d.velocity = new Vector2(velocity, rdb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true;
            isRight = false;
            isMoving = true;
            rdb2d.velocity = new Vector2(-velocity, rdb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // Shoot
            if (isLeft)
            {
                var bulletInstance = (GameObject)Instantiate(bullet, new Vector2(-3,-3), transform.rotation) as GameObject;
                var bullRB = bulletInstance.GetComponent<Rigidbody2D>();
                bullRB.AddForce(-transform.right * bulletSpeed);
            }
            if (isRight)
            {
                var bulletInstance = (GameObject)Instantiate(bullet, new Vector2(0,-3), transform.rotation) as GameObject;
                var bullRB = bulletInstance.GetComponent<Rigidbody2D>();
                bullRB.AddForce(transform.right * bulletSpeed);
            }
            
        } 
        if (isMoving == false)
        {
            rdb2d.velocity = new Vector2(0, rdb2d.velocity.y);
        }
    }
}
