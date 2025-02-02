using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] Checkpoints;
    private int currentCheckpointIndex = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && currentCheckpointIndex < Checkpoints.Length)
        {
            Checkpoints[currentCheckpointIndex].Check();
            currentCheckpointIndex++;
        }
    }
}
