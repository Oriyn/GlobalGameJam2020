using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool isWin;
    public Sprite takeOff;
    public Sprite fixedRocket;
    public Animator anim;
    public SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rdb2d;
    public bool isRocketReady;
    public bool isRocketRepairing;
    private float countDown = 4.0f;
    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        rdb2d = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isWin = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScript>().win;
        if (isRocketRepairing)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                isRocketReady = true;
                mySpriteRenderer.sprite = fixedRocket;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isWin)
        {
            isRocketRepairing = true;
        }
        if (collision.gameObject.tag == "Player" && isRocketReady)
        {
            Destroy(collision.gameObject);
            mySpriteRenderer.sprite = takeOff;
            rdb2d.AddForce(Vector2.up * 250f);
            win = true;
        }
    }
}
