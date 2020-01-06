using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
	public Color Default;
	public Color Hover;

	public void SetColorHover()
	{
		GetComponentInChildren<Text>().color = Hover;
	}
	public void SetColorDefault()
	{
		GetComponentInChildren<Text>().color = Default;
	}
	public void StartGame()
	{
		SceneManager.LoadScene("World 1-1");
	}
	public void Exit()
	{
		Application.Quit();
	}
	public void Switch(GameObject on)
	{
		GameObject.Find("MainMenu").SetActive(false);
		on.SetActive(true);
	}
	public void BckMenu(GameObject on)
	{
		GameObject.Find("Score").SetActive(false);
		on.SetActive(true);
	}
}
