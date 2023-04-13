using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPyramid : MonoBehaviour
{

    public bool open = true;
    bool empty = false;
    public void OnMouseOver()
    {
        Debug.LogWarning("test");
        if (empty) return;
        if (Input.GetMouseButtonDown(0) && open)
        {
            Debug.LogError("test");
            PyramidItem.Instance.AddPyramid();
            empty = true;
        }
    }
}
