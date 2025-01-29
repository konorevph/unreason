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
            this.gameObject.SetActive(false);
        }
    }
}
