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
		AfterTrigger();
	}

	protected virtual void AfterTrigger()
	{
		this.enabled = false;
	}

	// ReSharper disable Unity.PerformanceAnalysis
	public void Check()
	{
		Trigger();
	}
}