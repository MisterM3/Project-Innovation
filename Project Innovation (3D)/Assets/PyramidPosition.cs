using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidPosition : MonoBehaviour
{


    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PyramidItem.Instance.RemovePyramid()) ;
        }
    }
}
