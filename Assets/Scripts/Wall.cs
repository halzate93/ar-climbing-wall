using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class Wall : MonoBehaviour 
{
	[SerializeField]
	private float healthPoints;
	[SerializeField]
	private Animator cracks;
	[SerializeField]
	private int lifes;
	[SerializeField]
	private VideoPlayer collapse;
	private float currentHealthPoints;
	[Inject]
	private GameManager gameManager;
	private AudioSource crackingSound;

	private void Start ()
	{
		currentHealthPoints = healthPoints;
		crackingSound = GetComponent<AudioSource> ();
	}

	public void Damage (float damage)
	{
		if (!gameManager.IsPlaying) return;
		currentHealthPoints -= damage;
		if (currentHealthPoints <= 0)
			Break ();
	}

	public void Break ()
	{
		lifes--;
		currentHealthPoints = healthPoints;
		cracks.SetTrigger ("Crack");
		if (lifes == 0)
			Collapse ();
		crackingSound.Play ();
	}

	private void Collapse ()
	{
		collapse.gameObject.SetActive (true);
		collapse.Play ();
		gameManager.EndGame ();
	}
}
