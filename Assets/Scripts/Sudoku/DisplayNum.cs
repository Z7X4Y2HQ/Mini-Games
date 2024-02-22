using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class DisplayNum : ReturnIndex
{


    private void Update()
    {
        DisplayNumber();
    }

    private void DisplayNumber()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetIndex();
        }
    }
}
