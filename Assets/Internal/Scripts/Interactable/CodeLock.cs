using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    public GameObject OpenedIndicator, ClosedIndicator;
    private CodeLockRoll[] rolls;
    private int[] code;
    private bool isOpened;

    void Awake()
    {
        rolls = this.GetComponentsInChildren<CodeLockRoll>();
        GenerateCode(rolls.Length);
    }

    void Start()
    {
        UpdateState();
        Log();
    }

    public void UpdateState()
    {
        isOpened = true;
        for (int i = 0; i < code.Length; i++)
        {
            if (code[i] != rolls[i].GetValue())
            {
                isOpened = false;
                break;
            }
        }

        OpenedIndicator.SetActive(isOpened);
        ClosedIndicator.SetActive(!isOpened);
    }

    public bool IsOpened()
    {
        return isOpened;
    }

    public int[] GetCode()
    {
        return code;
    }

    private void GenerateCode(int length)
    {
        code = new int[length];
        
        for (int i = 0; i < length; i++)
        {
            code[i] = Random.Range(0, 9);
        }
    }

    public void Log()
    {
        string code = "";
        foreach(int i in this.code)
        {
            code += i;
        }

        Debug.Log("Code: " + code
            + "\ncodelock is " 
            + (isOpened ? "opened" : "closed"));
    }
}
