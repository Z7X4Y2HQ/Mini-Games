using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku : MonoBehaviour
{
    private string[] nums = { "0123456789", "1234567890", "2345678901" };
    private string index = "";
    void Start()
    {
        index = nums[0];
        Debug.Log(index[0]);
    }

    // Update is called once per frame
    void Update()
    {
        index = nums[1];
        Debug.Log(index[2]);
    }
}
