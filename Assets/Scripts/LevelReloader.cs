using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelReloader : ITickable
{
    public void Tick()
    {
		if (Input.GetButtonDown ("Reload"))
		{
			string loadedScene = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene (loadedScene);
		}
    }
}
