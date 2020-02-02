using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	private float timer = 1.0f;
	private GameObject target;
	public Animator anim;
    public float speed;
    private int enemyHealth = 4;
	float dirX;
	[SerializeField]
	float moveSpeed = 3f;
	Rigidbody2D rb;
	bool facingRight = false;
	Vector3 localScale;
	private float enemyDecay = 12.0f;

	void Start()
	{
		anim = GetComponent<Animator>();
		//target = GameObject.FindGameObjectWithTag("Player");
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();
		dirX = -1f;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x < -9f)
			dirX = 1f;
		else if (transform.position.x > 9f)
			dirX = -1f;

		if (enemyHealth <= 0)
		{
			moveSpeed = 0;
			anim.SetBool("IsEnemyDead", true);
			timer -= Time.deltaTime;
		}
		if (timer <= 0)
		{
			GameObject.FindGameObjectWithTag("KillCounter").GetComponent<KillCounter>().addKill();
			Destroy(gameObject);
		}

		/*enemyDecay -= Time.deltaTime;
		if (enemyDecay >= 0)
		{
			Destroy(gameObject);
		}*/
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
	}

	void LateUpdate()
	{
		CheckWhereToFace();
	}

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		switch (col.tag)
		{

			case "Item":
				rb.AddForce(Vector2.up * 250f);
				break;

			case "bullet":
				enemyHealth -= 1;
				Destroy(col.gameObject);
				break;

			case "Edge":
				rb.AddForce(Vector2.up * 250f);
				break;

		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag != "ground" && 
			 collision.gameObject.tag != "Edge"   &&
			 collision.gameObject.tag != "bullet")|| 
			 collision.gameObject.tag == "Enemy" ||
			 (collision.gameObject.tag == "Enemy" &&
			  collision.gameObject.tag == "ground") &&
			  (collision.gameObject.tag == "ground" &&
			  collision.gameObject.tag == "ground"))    
		{
			dirX *= -1;
		}
		if(collision.gameObject.tag == "bullet")
		{
			enemyHealth--;
			Destroy(collision.gameObject);
		}
	}
}

