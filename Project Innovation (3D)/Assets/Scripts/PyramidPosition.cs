using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PyramidPosition : MonoBehaviour
{

    public UnityEvent pyramidPutIn;

    public UnityEvent bothPyramidsIn;

    public bool thisDone;
    public bool otherDone;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PyramidItem.Instance.RemovePyramid())
            {
                PyramidIn();
            }
        }
    }


    public void PyramidIn()
    {
        thisDone= true;
        if (otherDone)
        {
            bothPyramidsIn.Invoke();
        }

        pyramidPutIn.Invoke();
    }

    public void OtherPyramidIn()
    {
        otherDone = true;
        if (thisDone)
        {
            bothPyramidsIn.Invoke();
        }

    }
}
