using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotate : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    // This event echoes the new local angle to which we have been dragged
    public event Action<Quaternion> OnAngleChanged;

    Quaternion dragStartRotation;
    Quaternion dragStartInverseRotation;


    [SerializeField] int amountSides = 4;

    [SerializeField] int currentSide = 0;

    [SerializeField] int slotIndex;

    public UnityEventSlots changedSlotEvent;


    private void Awake()
    {
        // As an example: rotate the attached object
        OnAngleChanged += (rotation) => transform.localRotation = rotation;
    }


    // This detects the starting point of the drag more accurately than OnBeginDrag,
    // because OnBeginDrag won't fire until the mouse has moved from the point of mousedown
    public void OnPointerDown(PointerEventData eventData)
    {
        dragStartRotation = transform.localRotation;
        Vector3 worldPoint;
        if (DragWorldPoint(eventData, out worldPoint))
        {
            // We use Vector3.forward as the "up" vector because we're working in a Canvas
            // and so mostly care about rotation around the Z axis
            dragStartInverseRotation = Quaternion.Inverse(Quaternion.LookRotation(worldPoint - transform.position, Vector3.forward));
        }
        else
        {
            Debug.LogWarning("Couldn't get drag start world point");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {



        Debug.Log(this.transform.localRotation.eulerAngles);



        float rotationSlotZ = this.transform.localRotation.eulerAngles.z;

        Debug.Log(this.transform.localRotation.eulerAngles);

        if (rotationSlotZ < 360f - 45f && rotationSlotZ > 270f - 45f) currentSide = 0;
        else if (rotationSlotZ < 270f - 45f && rotationSlotZ > 180 - 45f) currentSide = 1;
        else if (rotationSlotZ < 180 - 45f && rotationSlotZ > 90 - 45f) currentSide = 2;
        else if ((rotationSlotZ < 90 - 45f && rotationSlotZ > 0) || (rotationSlotZ < 360f && rotationSlotZ > 360f - 45f)) currentSide = 3;

        Debug.Log(currentSide);

        SnapRotation();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        if (DragWorldPoint(eventData, out worldPoint))
        {
            Quaternion currentDragAngle = Quaternion.LookRotation(worldPoint - transform.position, Vector3.forward);
            if (OnAngleChanged != null)
            {
                OnAngleChanged(currentDragAngle * dragStartInverseRotation * dragStartRotation);
            }
        }

        Debug.Log(transform.rotation.eulerAngles);
    }

    // Gets the point in worldspace corresponding to where the mouse is
    private bool DragWorldPoint(PointerEventData eventData, out Vector3 worldPoint)
    {
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(
            GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out worldPoint);
    }

    public void SnapRotation()
    {

        switch (currentSide)
        {
            case 0:
                this.transform.localEulerAngles = new Vector3(0, 0, 270);
                break;
            case 1:
                this.transform.localEulerAngles = new Vector3(0, 0, 180);
                break;
            case 2:
                this.transform.localEulerAngles = new Vector3(0, 0, 90);
                break;
            case 3:
                this.transform.localEulerAngles = new Vector3(0, 0);
                break;
        }
    }
}