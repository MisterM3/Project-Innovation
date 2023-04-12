using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventSlots : UnityEvent<int, int>
{ 

}



public class RotateWheel : MonoBehaviour
{

    [SerializeField] int amountSides = 4;

    [SerializeField] int currentSide = 0;

    [SerializeField] int slotIndex;

    public UnityEventSlots changedSlotEvent;

    bool isDone = false;


    private void SentNewPosition()
    {
        changedSlotEvent.Invoke(slotIndex, currentSide);
    }

    public void PuzzleIsDone()
    {
        isDone = true;
    }

    public void Start()
    {
        SnapRotation();
    }

    #region movingWheel

    float oldPosition;
    private void OnMouseOver()
    {
        if (isDone) return;

        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Input.mousePosition.y;
        }


        if (Input.GetMouseButton(0))
        {
            
            float newPosition = Input.mousePosition.y;

            float difference = newPosition - oldPosition;

            Vector3 extra = new Vector3(0, difference, 0);
            //this.transform.rotation = Quaternion.Euler(transform.eulerAngles + extra);
            transform.Rotate(extra);
           // Debug.Log(extra);

            oldPosition = newPosition;

            Debug.Log(this.transform.localRotation.eulerAngles);



            float rotationSlotY = this.transform.localRotation.eulerAngles.y;

            Debug.Log(this.transform.localRotation.eulerAngles);
            
            if (rotationSlotY < 360f - 45f && rotationSlotY > 270f - 45f) currentSide = 0;
            else if (rotationSlotY < 270f - 45f && rotationSlotY > 180 - 45f) currentSide = 1;
            else if (rotationSlotY < 180 - 45f && rotationSlotY > 90 - 45f) currentSide = 2;
            else if ((rotationSlotY < 90 - 45f  && rotationSlotY > 0) || (rotationSlotY < 360f && rotationSlotY > 360f - 45f)) currentSide = 3;

            Debug.Log(currentSide);
        }

        if (Input.GetMouseButtonUp(0))
        {

            SnapRotation();

            SentNewPosition();
        }
    }

    private void OnMouseExit()
    {
        if (isDone) return;

        SnapRotation();
        SentNewPosition();
    }

    #endregion

    public void SnapRotation()
    {


        
        switch (currentSide)
        {
            case 0:
                this.transform.localEulerAngles = new Vector3(0, 270);
                break;
            case 1:
                this.transform.localEulerAngles = new Vector3(0, 180);
                break;
            case 2:
                this.transform.localEulerAngles = new Vector3(0, 90);
                break;
            case 3:
                this.transform.localEulerAngles = new Vector3(0, 0);
                break;
        }
    }


}
