using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
	public bool Active = false;
	[SerializeField]
	public UnityEvent OnCheckpointReached;

	public Checkpoint[] NextCheckpoints;

	private void Start()
	{
		gameObject.SetActive(Active);
	}

	protected void Trigger()
	{
		OnCheckpointReached?.Invoke();
		foreach (Checkpoint checkpoint in NextCheckpoints)
		{
			checkpoint.gameObject.SetActive(true);
		}
		this.enabled = false;
	}
}