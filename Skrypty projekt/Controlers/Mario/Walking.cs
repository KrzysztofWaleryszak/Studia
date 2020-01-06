using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
	public Rigidbody2D _rigid { get; private set; }
	public Animator _animator { get; private set; }
	Camera _camera;
	Reactions _reactions;
	
	
	public float levelEntryWalkSpeedX;
	public float jumpForce;
	public Transform sensor1;
	public Transform sensor2;
	public LayerMask layer;


	public bool isCrouching = false;
	public bool switchingLvl = false;
	public bool _canMoving = true;
	public bool _canJump = false;
	void Awake()
	{
		_rigid = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_camera = FindObjectOfType<Camera>();
		_reactions = GetComponent<Reactions>();
	}

	private void FixedUpdate()
	{
		if (Physics2D.OverlapCircle(sensor1.position, 0.3f, layer) != null|| Physics2D.OverlapCircle(sensor2.position, 0.3f, layer)!=null)
		{
			_canJump = true;
		}
		else
		{
			_canJump = false;
		}

		_animator.SetBool("IsAir",!_canJump);

		if (_canMoving)
		{
			Vector3 vec = transform.position;
			vec.z = -10;
			_camera.transform.position = vec;
		}

	}

	void Update()
	{
		Inputs();
	}

	Vector2 vec = Vector2.zero;
	private void Inputs()
	{

		if (_canMoving)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) && _canJump) Jump();
			if (Input.GetKeyDown(KeyCode.Space)) _reactions.Attack();

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				vec.x = Move(-1);
			}
			else
			{
				if (Input.GetKey(KeyCode.RightArrow))
				{
					vec.x = Move(1);
				}
				else
				{
					vec.x = Move(0);
				}
			}
			_rigid.velocity = vec;
		}
	}

	private float Move(int var)
	{
		if (var != 0)
		{
			_animator.SetBool("Move", true);
			transform.localScale = new Vector3(var, 1, 1);
		}
		else
		{
			_animator.SetBool("Move", false);
		}
		return var * levelEntryWalkSpeedX * Time.deltaTime;
	}

	public void Jump()
	{
		vec.y = jumpForce;
		StartCoroutine("EnumJump");
	}

	IEnumerator EnumJump()
	{
		yield return new WaitForSeconds(0.1f);

		vec.y = 0;
	}

	
}
