using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EndScreen : MonoBehaviour 
{
	[SerializeField]
	private Text scoreLabel;
	[SerializeField]
	private Text timeLabel;
	[Inject]
	private GameManager gameManager;
	[Inject]
	private Score score;

	[Inject]
	private void OnInject ()
	{
		gameManager.OnGameOver += ShowResults;
	}

    private void ShowResults()
    {
		gameObject.SetActive (true);
		scoreLabel.text = string.Format (scoreLabel.text, score.Points);
		timeLabel.text = string.Format (timeLabel.text, score.Seconds / 60, score.Seconds % 60);
    }
}
