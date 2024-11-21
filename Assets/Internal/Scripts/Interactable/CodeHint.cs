using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeHint : MonoBehaviour
{
    public CodeLock codeLock;

    void Start()
    {
        var hint = this.GetComponent<TMP_Text>();
        if (codeLock != null)
        {
            int[] code = codeLock.GetCode();
            string str = "";
            foreach(int i in code)
            {
                str += i;
            }
            hint.text = str;
        }
    }
}
