using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroomingEntrance : MonoBehaviour
{
    public Door door;

    public void OpenDoor()
    {
        door.PartiallyOpen(30f);
    }
}
