using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DamnInstaller : MonoInstaller 
{
	[SerializeField]
	private GameObject leakPrefab;
	public override void InstallBindings()
	{
		Container.Bind<Wall> ().FromComponentInHierarchy ().AsSingle ();
		Container.Bind<LeakGenerator> ().FromComponentInHierarchy ().AsSingle ();
		Container.Bind<LeakManager> ().AsSingle ();
		Container.BindFactory<Leak, Leak.Factory> ().FromComponentInNewPrefab (leakPrefab);
		Container.Bind<GameManager> ().AsSingle ();
		Container.Bind<ITickable> ().To<DummyGameController> ().AsSingle ();
		Container.BindInterfacesAndSelfTo<Score> ().AsSingle ();
		Container.Bind<ITickable> ().To<LevelReloader> ().AsSingle ();
	}
}
