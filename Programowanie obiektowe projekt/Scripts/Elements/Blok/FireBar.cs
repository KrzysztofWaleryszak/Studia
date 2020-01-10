using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBar : MonoBehaviour
{
	public float speed;
	public GameObject pivot;
    void Update()
    {
		pivot.transform.Rotate(0,0,speed);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			collision.GetComponent<Reactions>().DownLvl(-1);
		}
	}
}
