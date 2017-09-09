using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LeakGenerator : MonoBehaviour 
{
	[SerializeField]
	private float width;
	[SerializeField]
	private float height;
	[Inject]
	private Leak.Factory leakFactory;

	public void GenerateLeak ()
	{
		Leak leak = leakFactory.Create ();
		leak.transform.position = GetRandomPosition ();
		leak.transform.parent = transform;
		Debug.Log ("New leak!");
	}

    private Vector3 GetRandomPosition()
    {
		float x = (0.5f - UnityEngine.Random.Range (0f, 1f)) * width;
		float y = (0.5f - UnityEngine.Random.Range (0f, 1f)) * height; 
		return transform.position + new Vector3 (x, y, 0f);
    }

	private void OnDrawGizmos()
	{
		Debug.DrawLine (transform.position + Vector3.right * - (width / 2f), transform.position + Vector3.right * (width / 2f));
		Debug.DrawLine (transform.position + Vector3.up * - (height / 2f), transform.position + Vector3.up * (height / 2f));
	}
}
