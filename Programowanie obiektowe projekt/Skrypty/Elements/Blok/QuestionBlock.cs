using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
	public GameObject present;
	public Sprite switchSprite;
	public int numberOfPresent=1;
	public bool hidden;

	SpriteRenderer _sr;

	private void Start()
	{
		if(hidden)
		{
			_sr = GetComponent<SpriteRenderer>();
			_sr.enabled = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(numberOfPresent>0)
		{
			numberOfPresent--;
			if(numberOfPresent==0&&switchSprite!=null)
			{
				if(hidden)
				{
					_sr.enabled = true;
				}
				GetComponent<SpriteRenderer>().sprite = switchSprite;
			}
			Instantiate(present, transform.position, Quaternion.identity);
			
		}
	}
}
