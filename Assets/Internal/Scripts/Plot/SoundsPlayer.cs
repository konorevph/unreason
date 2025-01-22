using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    public AudioSource[] Sounds;
    public void Execute()
    {
        foreach (var sound in Sounds)
        {
            sound.Play();
        }
    }
}
