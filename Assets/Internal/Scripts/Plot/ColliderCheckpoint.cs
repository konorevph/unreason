using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckpoint : Checkpoint
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trigger();
        }
    }
    
    protected override void AfterTrigger()
    {
        this.enabled = false;
        this.gameObject.SetActive(false);
    }
}
