using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System;

public class MoobEngine : MonoBehaviour
{
	public CircleCollider2D toOff;
	Rigidbody2D _rigid;
	public float speed;
	Vector2 vec;
	Vector2 actualVec;
	bool _start = false;
	bool _left = true;
	public void SetBool(bool var)
	{
		_left = var;
	}
	void Start()
	{
		_rigid = GetComponent<Rigidbody2D>();
		vec = new Vector2(speed * Time.deltaTime, 0);
		actualVec = new Vector2(-vec.x, 0);
		_rigid.velocity = vec;
	}


	private void Update()
	{
		if (DistanceFromMario() < 25)
		{
			_start = true;
		}
		else
		{
			_start = false;
		}
		if (_start)
		{

			if (_left)
			{
				actualVec.x = -vec.x;
			}
			else
			{
				actualVec.x = vec.x;
			}

			if (GetComponent<Animator>().GetBool("Dead"))
			{
				actualVec = Vector2.zero;
			}
			_rigid.velocity = actualVec;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Reactions mario = FindObjectOfType<Reactions>();
			if (mario.transform.position.y - transform.position.y >= 0.2)
			{
				mario.CounterJump();
				Die(5);
			}
			else
			{
				if (mario.transform.position.x > transform.position.x)
				{
					mario.DownLvl(1);
				}
				else
				{
					mario.DownLvl(-1);
				}
			}
		}
	}

	public void Die(float deadTimer)
	{
		GetComponent<Animator>().SetBool("Dead", true);
		actualVec = Vector2.zero;
		_rigid.gravityScale = 0;
		toOff.enabled = false;
		Destroy(gameObject, deadTimer);
	}







	float DistanceFromMario()
	{
		Vector2 moob = transform.position;
		Vector2 mario;
		try
		{
			mario = FindObjectOfType<Walking>().transform.position;
		}
		catch (Exception)
		{
			return 26;
		}
		return Mathf.Sqrt(Mathf.Pow(moob.x - mario.x, 2) + Mathf.Pow(moob.y - mario.y, 2));
	}
}
