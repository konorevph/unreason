using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
	[SerializeField]
	public UnityEvent OnCheckpointReached;

	public Checkpoint[] NextCheckpoints;

	protected void Trigger()
	{
		OnCheckpointReached?.Invoke();
		foreach (Checkpoint checkpoint in NextCheckpoints)
		{
			checkpoint.gameObject.SetActive(true);
		}
		this.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Trigger();
		}
	}
}