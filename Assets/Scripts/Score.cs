using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Score : ITickable
{
	private float time;
	private int points;

	public int Seconds
	{
		get
		{
			return (int)time;
		}
	}

	public int Points
	{
		get
		{
			return points;
		}
	}

	private GameManager gameManager;

	public Score (GameManager gameManager)
	{
		this.gameManager = gameManager;
	}

    public void Tick()
    {
		if (gameManager.IsPlaying)
			time += Time.deltaTime;
    }

	public void AddPoint ()
	{
		points++;
	}
}
