using shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SliderTEst : MonoBehaviour
{

    List<int> ints= new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSolution(ASerializable serializable)
    {
        if (!(serializable is SliderSolution)) return;

        SliderSolution solution = (SliderSolution)serializable;
        
        ints.Add(solution.value1);
        ints.Add(solution.value2);
        ints.Add(solution.value3);
        
        foreach(int i in ints)
        {
            Debug.Log(i);
        }

    }
}
