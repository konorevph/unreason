using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockRoll : MonoBehaviour
{
    private int value;
    private CodeLock codeLock;

    void Awake()
    {
        SetValue(0);
        codeLock = this.GetComponentInParent<CodeLock>();
    }

    public int GetValue()
    {
        return value;
    }

    public void IncreaseValue()
    {
        SetValue((value + 1) % 10);
        codeLock.UpdateState();
    }

    private void SetValue(int value)
    {
        this.value = value;
        this.transform.localEulerAngles = new Vector3(0, 0, value * 36);
    }
}
