using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
	Vector2 _startPosition;
	Vector2 _toPosition;
	Rigidbody2D _rigid;
	bool _doUp = true;
	public void Start()
	{
		_startPosition = transform.position;
		_rigid = GetComponent<Rigidbody2D>();
		_toPosition = new Vector2(_startPosition.x, _startPosition.y + 2);
	}

	void Update()
	{
		if (_doUp)
		{
			_rigid.velocity = new Vector2(0, 500) * Time.deltaTime;
		}
		else
		{
			_rigid.velocity = new Vector2(0, -500) * Time.deltaTime;
		}

		if(transform.position.y>=_toPosition.y)
		{
			_doUp = false;
		}

		if(transform.position.y<=_startPosition.y&&!_doUp)
		{
			FindObjectOfType<LevelManager>().AddPoints(10);
			Destroy(gameObject);
		}
	}


}
