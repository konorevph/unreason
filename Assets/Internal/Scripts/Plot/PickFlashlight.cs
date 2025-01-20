using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlashlight : MonoBehaviour
{
    public Door door;
    
    public void CloseDoor()
    {
        door.Close();    
    }

    public void OpenDoor()
    {
        door.PartiallyOpen(10f);
    }

    public void PlaySound()
    {
        
    }
}
