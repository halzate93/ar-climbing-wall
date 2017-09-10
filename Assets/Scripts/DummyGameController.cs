using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DummyGameController : ITickable
{
	private GameManager gameManager;
	private LeakManager leaks;


	public DummyGameController (GameManager gameManager, LeakManager leaks)
	{
		this.gameManager = gameManager;
		this.leaks = leaks;
	}

    public void Tick()
    {
        if (!gameManager.IsPlaying && Input.GetButtonDown ("Submit"))
			gameManager.StartGame ();
		if (gameManager.IsPlaying && Input.GetButtonDown ("Break"))
			leaks.CompleteTouch ();
    }
}
 