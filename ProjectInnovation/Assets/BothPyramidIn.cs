using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BothPyramidIn : MonoBehaviour
{


    bool thisDone = false;
    bool otherDone = false;

    [SerializeField] UnityEvent bothPyramidIn;

    public void ThisDone()
    {
        thisDone = true;
        if (otherDone)
        {
            bothPyramidIn?.Invoke();
        }
    }

    public void OtherDone()
    {
        otherDone = true;
        if (thisDone)
        {
            bothPyramidIn?.Invoke();
        }
    }
}
