using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPuzzle : MonoBehaviour
{
    [SerializeField] private List<int> correctRotations = new List<int>();
    [SerializeField] private List<DragRotate> currentRotations = new List<DragRotate>();
    bool finished;
    public bool CheckCorrect()
    {
        for (int i = 0; i < currentRotations.Count; i++)
        {
            if (currentRotations[i].currentSide != correctRotations[i]) return false;
        }

        return true;
    }

    public void Finished()
    {
        if(CheckCorrect())
            finished = true;
    }
}
