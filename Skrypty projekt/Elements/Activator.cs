using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
	public GameObject targer;
	public Transform activator;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name==activator.name)
		{
			targer.GetComponent<IActivable>().Activate();
		}
	}
}
