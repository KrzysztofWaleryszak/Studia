using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayLoadNextLvl : MonoBehaviour
{
	public string scene;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			LevelManager lm = FindObjectOfType<LevelManager>();
			lm.CountPoints();
			lm.LoadSceneCurrentLevel(scene);
		}
	}
}
