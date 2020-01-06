using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public bool spawnFromPoint;
	public int spawnPipeIdx;

	// Start is called before the first frame update
	void Start()
    {
		DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ResetSpawnPosition()
	{
		
	}
}
