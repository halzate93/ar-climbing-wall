using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Leak : MonoBehaviour 
{
	[SerializeField]
	private float damagePerSecond;
	[Inject]
	private Wall wall;

	private void Update ()
	{
		wall.Damage (damagePerSecond * Time.deltaTime);
	}

	public class Factory: Factory<Leak>
	{
		
	}
}
