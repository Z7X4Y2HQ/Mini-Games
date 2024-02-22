using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnIndex : MonoBehaviour
{
    string x, y;
    GameObject numText;
    public void GetIndex()
    {
        // numText = null;
        // x = this.gameObject.name[0].ToString();
        // y = this.gameObject.name[1].ToString();
        // numText = gameObject.transform.GetChild(0).gameObject;
        // Debug.Log(x.ToString() + y.ToString());

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Check if the ray hit a UI element
        if (hit.collider != null && hit.collider.gameObject != null)
        {
            // Check if the UI element is a button
            Button button = hit.collider.gameObject.GetComponent<Button>();
            if (button != null)
            {
                // Get the name of the clicked button
                string buttonName = hit.collider.gameObject.name;
                Debug.Log("Clicked button: " + buttonName);

                // You can perform any action here based on the button name
            }
        }
    }
}