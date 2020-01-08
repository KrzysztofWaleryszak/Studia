using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoveType {UL,UR,DL,DR }

public class ElementMotor : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;

	void Update()
    {
		transform.Rotate(new Vector3(0,0,rotationSpeed));
	}

	public void Run(MoveType type)
	{
	 	Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
		switch (type)
		{
			case MoveType.UL:
				_rigid.velocity = new Vector2(-1,1)*speed;
				break;
			case MoveType.UR:
				_rigid.velocity = new Vector2(1, 1) * speed * Time.deltaTime;
				break;
			case MoveType.DL:
				_rigid.velocity = new Vector2(-1, -1) * speed * Time.deltaTime;
				break;
			case MoveType.DR:
				_rigid.velocity = new Vector2(1, -1) * speed * Time.deltaTime;
				break;
		}
		Destroy(gameObject, 0.2f);
	}
}
