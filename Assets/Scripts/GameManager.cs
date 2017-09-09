using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
	public event Action OnStart;
	public event Action OnGameOver;

	public bool IsPlaying
	{
		get; private set;
	}

	public void StartGame ()
	{
		if (OnStart != null)
			OnStart ();
		IsPlaying = true;
		Debug.Log ("Game Started");
	}

	public void EndGame ()
	{
		if (OnGameOver != null)
			OnGameOver ();
		IsPlaying = false;
		Debug.Log ("Game Ended");
	}	
}
