using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelActivator : MonoBehaviour
{
	public GameObject[] ModelsToActivate;
	public GameObject[] ModlsToDisactivate;

	public void Execute()
	{
		foreach (var model in ModelsToActivate)
		{
			model.SetActive(true);
		}

		foreach (var model in ModlsToDisactivate)
		{
			model.SetActive(false);
		}
	}
}
