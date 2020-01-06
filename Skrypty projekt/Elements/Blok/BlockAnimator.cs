using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimator : MonoBehaviour
{
	public GameObject element;

	Vector2 _mainPosition;
	Vector2 _jumpPosition;

	private void Start()
	{
		_mainPosition = transform.position;
		_jumpPosition = transform.position;
		_jumpPosition.x = _mainPosition.x + 0.1f;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			LevelManager lm = FindObjectOfType<LevelManager>();
			if (lm.marioLvl >= 1)
			{
				QuestionBlock qb;
				if(TryGetComponent(out qb))
				{
					if(qb.numberOfPresent<=0)
					{
						OnDestroyed();
						Destroy(gameObject);
					}
				}
				else
				{
					OnDestroyed();
					Destroy(gameObject);
				}

				Collider2D[] colider= Physics2D.OverlapCircleAll(transform.position, 1);
				for (int i = 0; i < colider.Length; i++)
				{
					if (colider[i].TryGetComponent(out MoobEngine mb))
					{
						mb.Die(0.5f);
					}
				}
			}
		}
	}

	private void OnDestroyed()
	{
		for (int i = 0; i <= 3; i++)
		{
			ElementMotor eM = Instantiate(element, transform.position, Quaternion.identity).GetComponent<ElementMotor>();
			eM.Run((MoveType)i);
		}
	}

}
