using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DummyGameController : ITickable
{
	private GameManager gameManager;
	private LeakManager leaks;
    private Wall wall;

    public DummyGameController (GameManager gameManager, LeakManager leaks, Wall wall)
	{
		this.gameManager = gameManager;
		this.leaks = leaks;
		this.wall = wall;
	}

    public void Tick()
    {
        if (!gameManager.IsPlaying && Input.GetButtonDown ("Submit"))
			gameManager.StartGame ();
		if (gameManager.IsPlaying && Input.GetButtonDown ("Touch"))
			leaks.CompleteTouch ();
		if (gameManager.IsPlaying && Input.GetButtonDown ("Break"))
			wall.Break ();
    }
}
 