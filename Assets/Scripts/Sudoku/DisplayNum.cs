using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class DisplayNum : ReturnKeyCode
{
    string x, y;
    GameObject num;

    private void Update()
    {
        DisplayNumber();
    }

    private void DisplayNumber()
    {
        if (Input.anyKeyDown && !Input.GetMouseButton(0))
        {
            ReturnNumPressed();
            string numInput = key.ToString();
            Debug.Log("hello" + numInput);
            num.GetComponent<TMP_Text>().text = numInput;
        }
    }

    public void ReturnIndex()
    {
        x = this.gameObject.name[0].ToString();
        y = this.gameObject.name[1].ToString();
        num = this.gameObject.transform.GetChild(0).gameObject;
        Debug.Log(num.name);
    }
}
