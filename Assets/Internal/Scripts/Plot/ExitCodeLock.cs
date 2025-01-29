using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCodeLock : MonoBehaviour
{
    public GameObject LockObject;
    private ILock Lock;

    private void Start()
    {
        Lock = LockObject.GetComponent<ILock>();
    }

    private void Update()
    {
        if (Lock.IsOpened())
        {
            SceneManager.LoadScene("Final");
        }
    }
}
