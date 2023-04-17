using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotsPuzzle : MonoBehaviour
{
    [SerializeField] int[] slotPositionsSolution;
    [SerializeField] int[] slotCurrentPosition;

    public UnityEvent slotsDoneEvent;

    public UnityEvent slotsWrongAfterCorrect;

    public UnityEvent bothSlotsDoneEvent;

    private bool thisDone = false;
    private bool otherDone = false;
    public void ChangeSlotsPosition(int index, int slotNumber)
    {
        slotCurrentPosition[index] = slotNumber;

        if (CheckCorrect())
        {
            Win();
        }
        else NotCorrect();
    }

    public bool CheckCorrect()
    {
        for (int i = 0; i < slotCurrentPosition.Length; i++)
        {
            if (slotCurrentPosition[i] != slotPositionsSolution[i]) return false;
        }

        return true;
    }

    public void Win()
    {
        thisDone = true;
        if (otherDone)
        {
            bothSlotsDoneEvent.Invoke();

        }
        slotsDoneEvent.Invoke();
    }

    public void NotCorrect()
    {
        if (!thisDone) return;

        thisDone = false;
        slotsWrongAfterCorrect.Invoke();
    }

    public void OtherDone()
    {

        Debug.LogError("deafafeagaeg Done");
        otherDone= true;
        if (thisDone)
        {
            bothSlotsDoneEvent.Invoke();
        }
    }

    public void OtherWrong()
    {
        otherDone= false;
    }
}
