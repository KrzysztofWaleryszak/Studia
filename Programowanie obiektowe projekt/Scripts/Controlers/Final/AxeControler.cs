using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeControler : MonoBehaviour
{
	bool _start=false;
	bool _stop = false;
	public Transform pivot;
	public GameObject[] bridges;
	private void Update()
	{
		if(_start&&!_stop)
		{
			pivot.Rotate(0, 0, 10);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			_start = true;
		}else
			if(collision.name== "bridge_rope")
		{
			_stop = true;
			StartCoroutine(DestroyBridge());
			Destroy(collision.gameObject);
		}
	}

	IEnumerator DestroyBridge()
	{
		for (int i = 0; i < bridges.Length; i++)
		{
			bridges[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
