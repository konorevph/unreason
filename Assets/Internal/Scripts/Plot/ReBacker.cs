using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class ReBacker : MonoBehaviour
{
    private NavMeshSurface _surface;

    private void Start()
    {
        _surface = GetComponent<NavMeshSurface>();
    }
}
