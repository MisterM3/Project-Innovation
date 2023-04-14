using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RotatingPuzzle : MonoBehaviour
{
    [SerializeField] private List<int> correctRotations = new List<int>();
    [SerializeField] private List<int> currentRotations = new List<int>();
    bool finished;


    public UnityEvent circleDone;

    public void ChangeSlotsPosition(int index, int slotNumber)
    {
        currentRotations[index] = slotNumber;

        if (CheckCorrect()) Finished();
    }

    public bool CheckCorrect()
    {
        for (int i = 0; i < currentRotations.Count; i++)
        {
            if (currentRotations[i] != correctRotations[i]) return false;
        }

        return true;
    }

    public void Finished()
    {
        if (CheckCorrect())
        {
            finished = true;
            circleDone.Invoke();
        }

    }
}
