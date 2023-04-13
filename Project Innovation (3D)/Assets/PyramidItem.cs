using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PyramidItem : MonoBehaviour
{

    public static PyramidItem Instance { get; private set; }

    public bool hasPyramid = false;

    public UnityEvent onPyramidGot;
    public UnityEvent onPyramidLost;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }


    public void AddPyramid()
    {
        hasPyramid= true;
        onPyramidGot?.Invoke();
    }

    public bool RemovePyramid()
    {
        if (hasPyramid)
        {
            hasPyramid= false;
            onPyramidLost?.Invoke();
            return true;
        }
        else return false;
    }
}
