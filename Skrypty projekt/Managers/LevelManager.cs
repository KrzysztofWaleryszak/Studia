using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
	AudioSource musicSource;
	AudioSource soundSource;
	public AudioClip music;
	public AudioClip castleCompleteMusic;

	public GameObject UI;
	public Text timerText;
	public Text pointsText;
	public int marioLvl = 0;
	int timer = 300;
	int points = 0;

	private void Update()
	{
		if(!musicSource.isPlaying&&!soundSource.isPlaying)
		{
			musicSource.Play();
		}
	}
	public void StartLevel()
	{
		Cursor.visible = false;
		if (musicSource.isPlaying)
		{
			musicSource.Stop();
		}
		musicSource.clip = music;
		musicSource.Play();
		SetTimer();
		TimerStart();
		AddPoints(0);
	}
	public void AddPoints(int var)
	{
		points += var;
		pointsText.text = points.ToString();
	}

	bool _timer = false;
	public void SetTimer()
	{
		timer = 300;
	}
	public void timerFinish()
	{
		timer = 0;
	}
	public void TimerStart()
	{
		if (!_timer)
		{
			_timer = true;
			StartCoroutine("TimerUpdate");
		}
	}

	public void TimerStop()
	{
		if (_timer)
		{
			_timer = false;
			StopCoroutine("TimerUpdate");
		}
	}

	IEnumerator TimerUpdate()
	{
		while (timer > 0)
		{
			yield return new WaitForSeconds(1);
			timer--;
			timerText.text = timer.ToString();
		}

	}

	public void PlaySound(AudioClip clip)
	{
		if (soundSource.isPlaying)
		{
			soundSource.Stop();
		}
		soundSource.PlayOneShot(clip);
	}
	private void Start()
	{
		musicSource=GetComponents<AudioSource>()[0];
		soundSource= GetComponents<AudioSource>()[1];
		musicSource.Play();

	}

	public void SetCastleMusic()
	{
		if (soundSource.isPlaying)
		{
			soundSource.Stop();
		}

		musicSource.Stop();
		soundSource.clip = castleCompleteMusic;
		soundSource.Play();
	}


	public void LoadSceneCurrentLevel(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	public void CountPoints()
	{
		TimerStop();
		Saver saver = new Saver(5);
		saver.Read();
		saver.Add(points+10*timer);
		saver.Save();
	}

	public void BackToMenu()
	{
		LoadSceneCurrentLevel("Main Menu");
		Cursor.visible = true;
		Destroy(UI);
		Destroy(gameObject);
	}
}
