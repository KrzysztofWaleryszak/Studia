using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenu;
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale==1)
		{
			Cursor.visible = true;
			Time.timeScale = 0;
			pauseMenu.SetActive(true);
		}else
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Cursor.visible = false;
				Time.timeScale = 1;
				pauseMenu.SetActive(false);
			}
		}
	}
	public void Resume()
	{
		Cursor.visible = false;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
	}
	public void BackToMainMenu()
	{
		FindObjectOfType<LevelManager>().BackToMenu();
	}

}
