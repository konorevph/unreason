using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourcesEvent : MonoBehaviour
{
	public LightSource[] lightToOffObjects;
	public LightSource[] lightToOnObjects;

	public void Execute()
	{
		foreach (var lightSource in lightToOnObjects)
		{
			lightSource.On();
		}

		foreach (var lightSource in lightToOffObjects)
		{
			lightSource.Off();
		}
	}
}
