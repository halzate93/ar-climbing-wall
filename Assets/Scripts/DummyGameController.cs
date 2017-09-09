using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DummyGameController : ITickable
{
	private GameManager gameManager;
	private LeakGenerator generator;


	public DummyGameController (GameManager gameManager, LeakGenerator generator)
	{
		this.gameManager = gameManager;
		this.generator = generator;
	}

    public void Tick()
    {
        if (!gameManager.IsPlaying && Input.GetButtonDown ("Submit"))
			gameManager.StartGame ();
		if (gameManager.IsPlaying && Input.GetButtonDown ("Break"))
			generator.GenerateLeak ();
    }
}
