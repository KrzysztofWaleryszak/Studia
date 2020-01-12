using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactions : MonoBehaviour
{
	public GameObject bullet;
	public Transform firePos;
	public AudioClip shotSource;
	public float fireShot;

	LevelManager _lm;
	CapsuleCollider2D _capsule;
	Walking _walking;
	private bool _canAttack=true;
	bool _FlagPole = false;
	void Awake()
    {
		_walking = GetComponent<Walking>();
		_capsule = GetComponent<CapsuleCollider2D>();
		_lm = FindObjectOfType<LevelManager>();
		SetLvl(_lm.marioLvl);
		_lm.StartLevel();
    }

	public void FreezeUserInput()
	{
		_walking._canMoving = false;
	}
	public void UnfreezeUserInput()
	{
		_walking._canMoving = true;
	}

	public void FlagPole(bool var)
	{
		_walking._canMoving = !var;

		if (var)
		{
			_walking._animator.SetTrigger("Slide");
			_walking._rigid.velocity = new Vector2(0, 0);
			StartCoroutine("EnumFlagPole");
		}
		else
		{
			_walking._animator.SetTrigger("EndKeep");
		}
	}

	IEnumerator EnumFlagPole()
	{
		while (!_FlagPole)
		{
			yield return new WaitForSeconds(0.1f);
		}
		_walking._animator.SetTrigger("Keep");
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Bottom")
		{
			_FlagPole = true;
		}
	}


	public void GrowLvl()
	{
		if (_walking._animator.GetInteger("Lvl") < 2)
			SetLvl(_walking._animator.GetInteger("Lvl") + 1);
	}


	public void DownLvl(int velocity)
	{
		if (_walking._animator.GetInteger("Lvl") >= 1)
		{
			SetLvl(_walking._animator.GetInteger("Lvl") - 1);
			Hurt(velocity);
		}
		else
		{
			if (_walking._animator.GetInteger("Lvl") == 0)
			{
				Die();
			}
		}
	}

	public void SetLvl(int var)
	{
		GetComponent<Animator>().SetInteger("Lvl", var);
		FindObjectOfType<LevelManager>().marioLvl = var;
		GetComponent<Animator>().SetTrigger("newLvl");
		if(var==0)
		{
			_capsule.offset = new Vector2(0, 0.5f);
			_capsule.size = new Vector2(1, 1);
		}
		else
		{
			_capsule.offset = new Vector2(0,1);
			_capsule.size = new Vector2(1, 1.9f);
		}
	}

	public void CounterJump()
	{
		_walking.Jump();
	}

	void Hurt(int velocity)
	{
		StartCoroutine("EnumHurt", velocity);
	}

	IEnumerator EnumHurt(int velocity)
	{
		Renderer render = GetComponent<Renderer>();
		_walking._canMoving = false;
		_walking._rigid.AddForce(new Vector2( velocity*_walking.levelEntryWalkSpeedX*Time.deltaTime,_walking.jumpForce));
		for (int i = 0; i < 3; i++)
		{
			render.enabled = false;
			yield return new WaitForSeconds(0.1f);
			render.enabled = true;
			yield return new WaitForSeconds(0.1f);
		}
		_walking._canMoving = true;
	} 

	public void Die()
	{
		_lm.timerFinish();
		_walking._animator.SetTrigger("Die");
		_walking._canMoving = false;
		_capsule.enabled = false;
		_walking.Jump();
		Destroy(gameObject, 3f);
	}

	public void AutomaticCrouch(bool var = true)
	{
		_walking._animator.SetBool("Crouch", var);
		_walking.isCrouching = var;
		_walking._canMoving = !var;
	}


	internal void Attack()
	{
		if (_canAttack&&_walking._animator.GetInteger("Lvl")==2)
		{ StartCoroutine("EnumAttack"); }
	}

	IEnumerator EnumAttack()
	{
		_walking._canMoving = false;
		_canAttack = false;
		_walking._animator.SetBool("Shot", true);

		
		GameObject bulletBuf = Instantiate(bullet,firePos.position,Quaternion.identity);
		FindObjectOfType<LevelManager>().PlaySound(shotSource);
		bulletBuf.GetComponent<Rigidbody2D>().AddForce ( new Vector2(fireShot * transform.localScale.x, 0));
		Destroy(bulletBuf, 5f);

		yield return new WaitForSeconds(0.1f);
		_walking._canMoving = true;
		_canAttack = true;
		_walking._animator.SetBool("Shot", false);
	}

	private void OnDestroy()
	{
		if (!_capsule.enabled)
		{
			_lm.CountPoints();
		}

	}
}
