using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leftgun : MonoBehaviour
{
    public bool isLeft = false;
    public bool isRight = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isLeft = false;
            isRight = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true;
            isRight = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // Shoot Left
            if (isLeft && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                var bulletInstance = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                var bullRB = bulletInstance.GetComponent<Rigidbody2D>();
                bullRB.AddForce(-transform.right * bulletSpeed);
            }
        }
    }
}
