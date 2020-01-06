using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
	private LevelManager t_LevelManager;

	private Transform flag;
	private Transform flagStop;
	private bool moveFlag;

	private float flagVelocityY = -.08f;

	// Use this for initialization
	void Start()
	{
		t_LevelManager = FindObjectOfType<LevelManager>();
		flag = transform.Find("Flag");
		flagStop = transform.Find("Flag Stop");
	}

	void FixedUpdate()
	{
		if (moveFlag && flag.position.y > flagStop.position.y)
		{
			flag.position = new Vector2(flag.position.x, flag.position.y + flagVelocityY);
		}else
		{
			if (moveFlag)
			{
				FindObjectOfType<Reactions>().FlagPole(false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !moveFlag)
		{
			moveFlag = true;
			FindObjectOfType<Reactions>().FlagPole(true);
			FindObjectOfType<Reactions>().gameObject.transform.position = new Vector3(transform.position.x - 0.36f, FindObjectOfType<Reactions>().transform.position.y);
			t_LevelManager.SetCastleMusic();
		}
	}
}
