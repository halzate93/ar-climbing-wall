using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakManager
{
	private LeakGenerator generator;
	private Leak current;

	public LeakManager (LeakGenerator generator)
	{
		this.generator = generator;
	}

	public void CompleteTouch ()
	{
		if (current != null)
			current.Close ();
		current = generator.GenerateLeak ();
	}
}
