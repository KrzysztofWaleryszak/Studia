using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColiderControler : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Moob"))
		{
			collision.gameObject.GetComponent<MoobEngine>().Die(0);
		}else
		{
			if(collision.gameObject.CompareTag("Bowser"))
			{
				collision.gameObject.GetComponent<BossControler>().Hit();
			}
		}
	}
}
