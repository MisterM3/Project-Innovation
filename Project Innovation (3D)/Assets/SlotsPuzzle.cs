using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotsPuzzle : MonoBehaviour
{
    [SerializeField] int[] slotPositionsSolution;
    [SerializeField] int[] slotCurrentPosition;

    public UnityEvent slotsDoneEvent;
    public void ChangeSlotsPosition(int index, int slotNumber)
    {
        slotCurrentPosition[index] = slotNumber;

        if (CheckCorrect()) Win();
    }

    public bool CheckCorrect()
    {
        for(int i = 0; i < slotCurrentPosition.Length; i++)
        {
            if (slotCurrentPosition[i] != slotPositionsSolution[i]) return false;
        }

        return true;
    }

    public void Win()
    {
        slotsDoneEvent.Invoke();
    }
}
