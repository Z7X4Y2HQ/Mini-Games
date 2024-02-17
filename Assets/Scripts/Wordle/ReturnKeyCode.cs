using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ReturnKeyCode : MonoBehaviour
{
    char[] keys = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    [HideInInspector] public char key;

    public void ReturnKeyPressed()
    {
        foreach (char i in keys)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                key = i;
                return;
            }
            else
            {
                key = ' ';
            }
        }
    }
    public void ReturnNumPressed()
    {
        foreach (char i in nums)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                key = i;
                return;
            }
            else
            {
                key = ' ';
            }
        }
    }
}