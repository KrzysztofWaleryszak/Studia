using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour
{
	public Transform left;
	public Transform right;
	bool _right = true;

	void Update()
	{
		if (transform.position.x >= right.position.x)
		{
			_right = false;
		}
		else
		{
			if (transform.position.x <= left.position.x)
			{
				_right = true;
			}
		}

		if (_right)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.transform.parent = gameObject.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.transform.parent = null;
		}
	}
}
