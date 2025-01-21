using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = true;
    public GameObject locker;
    public float closeSpeed = 100f;
    public float openSpeed = 30f;
    public AudioSource ClosingAudioSource;
    public AudioSource OpeningAudioSource;
    
    private ILock doorLock;
    private HingeJoint[] doors;
    private BoxCollider[] handlers;
    private float? partialOpenAngle = null;

    void Awake()
    {
        doors = this.GetComponentsInChildren<HingeJoint>();
        if (locker != null)
        {
            doorLock = locker.GetComponentInChildren<ILock>();
        }

        handlers = new BoxCollider[doors.Length];
        for (int i = 0; i< doors.Length; i++)
        {
            foreach (BoxCollider boxCollider in doors[i].GetComponentsInChildren<BoxCollider>())
            {
                if (boxCollider.CompareTag("door_handler"))
                {
                    handlers[i] = boxCollider;
                    break;
                }
            }
        }
    }

    void Start()
    {
        if (doorLock != null)
        {
            isOpened = doorLock.IsOpened();
        }
        
        UpdateState();
        Debug.Log("Door " + this.name + " is " + (isOpened ? "opened" : "closed"));
    }

    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (doorLock != null)
        {
            isOpened = doorLock.IsOpened();
        }

        foreach (var handler in handlers)
        {
            handler.enabled = isOpened;
        }

        foreach (HingeJoint door in doors)
        {
            JointLimits limits = door.limits;
            limits.max = 90;
            door.limits = limits;

            // door.GetComponent<Rigidbody>().isKinematic = isOpened || !isOpened && door.angle > 0;

            if (!isOpened && door.angle > 0)
            {
                CloseDoor(door);
                door.useMotor = true;
            }
            else if (isOpened && partialOpenAngle != null)
            {
                OpenDoor(door);
                door.useMotor = true;
            }
            else
            {
                door.useMotor = false;
            }
        }
    }

    private void CloseDoor(HingeJoint door)
    {
        JointMotor motor = door.motor;
        motor.force = 100;
        motor.targetVelocity = -closeSpeed;
        door.motor = motor;
    }

    private void OpenDoor(HingeJoint door)
    {
        if (partialOpenAngle == null) return;
        if (door.angle >= partialOpenAngle)
        {
            partialOpenAngle = null;
            return;
        }
        JointMotor motor = door.motor;
        motor.force = 100;
        motor.targetVelocity = openSpeed;
        door.motor = motor;
    }

    public void Close()
    {
        ClosingAudioSource.Play();
        isOpened = false;
    }
    
    public void PartiallyOpen(float angle = 90f)
    {
        OpeningAudioSource.Play();
        partialOpenAngle = angle;
        isOpened = true;
    }
}
