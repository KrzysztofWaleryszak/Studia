using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Princess : MonoBehaviour ,IActivable
{
	public GameObject ThankYouMario;
	public GameObject Welp;

	private LevelManager t_LevelManager;
	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
	}


	IEnumerator DisplayMessageCo() {
		t_LevelManager.TimerStop();
		t_LevelManager.SetCastleMusic();
		ThankYouMario.SetActive (true);
		yield return new WaitForSecondsRealtime (.75f);
		Welp.SetActive (true);
		yield return new WaitForSecondsRealtime (.75f);
		t_LevelManager.CountPoints();
		t_LevelManager.BackToMenu();
	}

	public void Activate()
	{
		FindObjectOfType<Reactions>().FreezeUserInput();
		StartCoroutine(DisplayMessageCo());
	}
}
