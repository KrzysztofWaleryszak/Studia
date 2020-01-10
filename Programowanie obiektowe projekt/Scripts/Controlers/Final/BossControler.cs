using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControler : MonoBehaviour, IActivable
{
	Rigidbody2D _rigid;
	Animator _animator;
	Transform mario;

	public float minDistance;
	public float speed;
	public float jumpForce;
	public LayerMask layer;

	public Transform FirePos;
	public GameObject prefab;
	public float speedPrefab;
	public GameObject barrier;



	

	bool _start = false;
	bool _canJump = true;

	public float speedAttack;
	bool _canAttack = true;

	int _HP = 10;
	public void Activate()
	{
		_start = true;
		_rigid = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		mario = FindObjectOfType<Walking>().transform;
	}

	// Update is called once per frame
	Vector2 vec=Vector2.zero;
	void Update()
	{
		if (_start)
		{
			float vectorx = VectorX(mario,true);
			if (VectorX(mario,false)>minDistance)
			{
				if(vectorx!=0)
				{
					transform.localScale = new Vector3(vectorx,1,1);
				}
				vec.x=speed*vectorx*Time.deltaTime;
			}else
			{
				vec.x = 0;
			}
			if(mario.position.y>transform.position.y&&_canJump)
			{
				Jump();
			}
			if(_canAttack && Beetwen(mario.position.y,transform.position.y-1.0f,transform.position.y+0.5f))
			{
				Attack();
			}

			_rigid.velocity = vec;
		}
	}
	private void FixedUpdate()
	{
		if (Physics2D.OverlapCircle(transform.position, 1.5f, layer)!=null)
		{
			_canJump = true;
		}
		else
		{
			_canJump = false;
		}
	}
	public void Hit()
	{
		if(_HP>0)
		{
			_HP -= UnityEngine.Random.Range(1,2);
		}else
		{
			_start = false;
			transform.Rotate(0,0,90);
			StartCoroutine(EnumHit());
		}
	}

	IEnumerator EnumHit()
	{
		yield return new WaitForSeconds(5);
		_HP = 10;
		transform.rotation = new Quaternion(0, 0, 0, 0);
		_start = true;
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

	void Attack()
	{
		_canAttack = false;
		GameObject gm=Instantiate(prefab,FirePos.position,Quaternion.identity);
		gm.transform.localScale = transform.localScale;
		gm.GetComponent<Rigidbody2D>().velocity = new Vector2(speedPrefab*VectorX(mario,true),0)*Time.deltaTime;
		_animator.SetTrigger("Fire");
		StartCoroutine(EnumAttack());
	}

	IEnumerator EnumAttack()
	{
		yield return new WaitForSeconds(speedAttack);
		_canAttack = true;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Reactions>().DownLvl((int)VectorX(mario, true));
		}
	}

	private void OnDestroy()
	{
		Destroy(barrier);
	}

	/// <summary>
	/// if true return -1,0,1
	/// if false return distance 
	/// </summary>
	/// <param name="returnVelocity"></param>
	/// <returns></returns>
	float VectorX(Transform target,bool returnVelocity)
	{
		float result =target.position.x -transform.position.x;
		if (returnVelocity)
		{
			return Mathf.Abs(result) / result;
		}
		else
		{
			return Mathf.Abs(result);
		}

	}

	bool Beetwen(float x,float min,float max)
	{
		return (x >= min && x <= max);
	}
}
