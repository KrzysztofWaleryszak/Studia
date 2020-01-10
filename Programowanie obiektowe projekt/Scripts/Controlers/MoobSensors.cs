using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoobSensors : MonoBehaviour
{
	public bool setBool;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player"))
		{
			GetComponentInParent<MoobEngine>().SetBool(setBool);
		}
	}
}
