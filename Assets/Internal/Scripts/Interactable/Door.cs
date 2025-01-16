using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = true;
    public GameObject locker;
    private ILock doorLock;
    private HingeJoint[] doors;
    // Start is called before the first frame update

    void Awake()
    {
        doors = this.GetComponentsInChildren<HingeJoint>();
        if (locker != null)
        {
            doorLock = locker.GetComponentInChildren<ILock>();
        }
    }

    void Start()
    {
        if (doorLock != null)
        {
            isOpened = doorLock.IsOpened();
        }
        
        UpdateState();
        Debug.Log("Door is " + (isOpened ? "opened" : "closed"));
    }

    void Update()
    {
        UpdateState();
    }

    public void UpdateState()
    {
        if(doorLock != null)
        {
            isOpened = doorLock.IsOpened();
        }

        foreach(HingeJoint door in doors)
        {
            JointLimits limits = door.limits;
            limits.max = isOpened ? 90 : 0;
            door.limits = limits;
        }
    }
}
