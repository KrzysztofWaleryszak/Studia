using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEngine : MonoBehaviour
{
	public float speed;
	Vector2 toPosition;
	Vector2 defaultvec;
	Vector2 vec;
	bool isReady = false;
	private void Start()
	{
		transform.position.Set(transform.position.x,transform.position.y,1);
		toPosition = new Vector2(transform.position.x, transform.position.y + 0.85f);
		vec = new Vector2(0, speed*Time.deltaTime );
		defaultvec = new Vector2(speed,0);
	}

	private void Update()
	{
		if(transform.position.y >= toPosition.y)
		{
			vec= new Vector2(speed*Time.deltaTime,0);
			GetComponent<CircleCollider2D>().enabled = true;
			GetComponent<Rigidbody2D>().gravityScale = 50;
			isReady = true;
		}

		GetComponent<Rigidbody2D>().velocity = vec;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isReady) return;
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Reactions>().GrowLvl();
			Destroy(gameObject);
		}else
		{
			if(collision.transform.position.y>=transform.position.y-0.40)
			{
				if(transform.position.x>collision.transform.position.x)
				{
					vec.x = defaultvec.x;
				}else
				{
					vec.x = -defaultvec.x;
				}
			}
		}
	}
}
