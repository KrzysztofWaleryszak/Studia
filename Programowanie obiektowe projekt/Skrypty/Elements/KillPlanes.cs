using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlanes : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			Reactions r = collision.GetComponent<Reactions>();
			r.SetLvl(0);
			r.Die();
		}else
		{
			Destroy(collision.gameObject);
		}
	}
}
