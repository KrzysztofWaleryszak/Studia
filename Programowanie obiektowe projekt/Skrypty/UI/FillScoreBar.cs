using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillScoreBar : MonoBehaviour
{
	public Transform StartPosition;
	public Text textPrefab;
	private void OnEnable()
	{
		GameObject[] remove = GameObject.FindGameObjectsWithTag("Score");
		for (int i = 0; i < remove.Length; i++)
		{
			Destroy(remove[i]);
		}
		Saver sv = new Saver(5);
		int[] tab = sv.ReadTab();
		for (int i = tab.Length - 1; i >= 0; i--)
		{
			Text gm = Instantiate(textPrefab);
			gm.transform.parent = gameObject.transform;
			gm.transform.position = new Vector2(StartPosition.position.x, StartPosition.position.y - (30 * i));
			gm.text = $"{i+1}.  {tab[i].ToString()}";

		}

	}
}
