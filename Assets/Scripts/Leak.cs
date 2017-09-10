using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class Leak : MonoBehaviour 
{
	[SerializeField]
	private float damagePerSecond;
	[SerializeField]
	private AudioClip closeSound;
	[Inject]
	private Wall wall;
	[Inject]
	private Score score;
	[Inject]
	private GameManager gameManager;
	private AudioSource leakSound;


	private void Awake ()
	{
		leakSound = GetComponent<AudioSource> ();
	}

	private void Start ()
	{
		gameManager.OnGameOver += Destroy;
		leakSound.DOFade (1f, 1f);
	}

	private void Update ()
	{
		wall.Damage (damagePerSecond * Time.deltaTime);
	}

	public void Close()
    {
		leakSound.Stop ();
		leakSound.PlayOneShot (closeSound);
		score.AddPoint ();
		Invoke ("Destroy", 0.5f);
    }

	private void Destroy ()
	{
		Destroy (gameObject);
	}

	private void OnDestroy ()
	{
		gameManager.OnGameOver -= Destroy;
	}

	public class Factory: Factory<Leak>
	{
		
	}
}
