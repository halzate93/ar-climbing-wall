using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Wall : MonoBehaviour 
{
	[SerializeField]
	private float healthPoints;
	[Inject]
	private GameManager gameManager;

	public void Damage (float damage)
	{
		healthPoints -= damage;
		if (healthPoints <= 0)
			Collapse ();
	}

	private void Collapse ()
	{
		gameManager.EndGame ();
	}
}
