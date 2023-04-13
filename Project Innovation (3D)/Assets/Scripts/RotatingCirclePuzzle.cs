using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class RotatingCirclePuzzle : MonoBehaviour
{

    [SerializeField] int amountSides = 4;

    [SerializeField] public int currentSide = 0;

    [SerializeField] int slotIndex;

    public UnityEventSlots changedSlotEvent;

    bool isDone = false;

    [SerializeField] float speed = 1f;

    float rotationPerSide;

    private void Awake()
    {
        rotationPerSide = 360f / amountSides;
    }

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

    Vector2 oldPosition;
    private void OnMouseOver()
    {
        if (isDone) return;

        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Input.mousePosition;
        }


        if (Input.GetMouseButton(0))
        {

            Vector2 newPosition = Input.mousePosition;

            Vector2 difference = newPosition - oldPosition;

            float extraF = difference.x + difference.y;

            Vector3 extra = new Vector3(0, 0, extraF);
            //this.transform.rotation = Quaternion.Euler(transform.eulerAngles + extra);
            transform.Rotate(extra * speed);
           // Debug.Log(extra);

            oldPosition = newPosition;

            Debug.Log(this.transform.localRotation.eulerAngles);



            float rotationSlotY = this.transform.localRotation.eulerAngles.y;

            Debug.Log(this.transform.localRotation.eulerAngles);


            /*
            if (rotationSlotY < 360f - 45f && rotationSlotY > 270f - 45f) currentSide = 0;
            else if (rotationSlotY < 270f - 45f && rotationSlotY > 180 - 45f) currentSide = 1;
            else if (rotationSlotY < 180 - 45f && rotationSlotY > 90 - 45f) currentSide = 2;
            else if ((rotationSlotY < 90 - 45f  && rotationSlotY > 0) || (rotationSlotY < 360f && rotationSlotY > 360f - 45f)) currentSide = 3;
            */


            for (int i = 0; i < amountSides; i++)
            {
                if (i + 1 == amountSides)
                {
                    if ((rotationSlotY < 360f - (rotationPerSide * i) && rotationSlotY > 0) || (rotationSlotY < 360f && rotationSlotY > 360f - (rotationPerSide * .5f))) currentSide = i;
                    continue;
                }
                if ((rotationSlotY < 360f - (rotationPerSide * i + rotationPerSide * .5f)) && (rotationSlotY > 360f - (rotationPerSide * (i + 1) + rotationPerSide * .5f)))
                {
                    currentSide = i;
                    break;
                }
            }
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

        Vector3 angle = this.transform.localEulerAngles;

        this.transform.localEulerAngles = new Vector3(angle.x,  360f - ((currentSide + 1) * rotationPerSide));

        /*
        switch (currentSide)
        {
            case 0:
                this.transform.localEulerAngles = new Vector3(angle.x, 270);
                break;
            case 1:
                this.transform.localEulerAngles = new Vector3(angle.x, 180);
                break;
            case 2:
                this.transform.localEulerAngles = new Vector3(angle.x, 90);
                break;
            case 3:
                this.transform.localEulerAngles = new Vector3(angle.x, 0);
                break;
        }
        */
    }


}
