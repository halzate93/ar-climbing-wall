using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

[RequireComponent (typeof (CanvasGroup))]
[RequireComponent (typeof (AudioSource))]
public class FadeOutOnStart : MonoBehaviour 
{
	[SerializeField]
	private float duration;
	[Inject]
	private GameManager gameManager;
	private CanvasGroup canvas;
	private new AudioSource audio;
	
	private void Awake ()
	{
		canvas = GetComponent<CanvasGroup> ();
		audio = GetComponent<AudioSource> ();
		gameManager.OnStart += FadeOut;
	}

    private void FadeOut()
    {
		canvas.DOFade (0f, duration);
		audio.Play ();
    }
}
