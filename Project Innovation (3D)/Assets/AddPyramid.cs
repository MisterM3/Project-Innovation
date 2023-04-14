using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddPyramid : MonoBehaviour
{

    public bool open = false;
    bool empty = false;

    [SerializeField] Animation animation;

    public UnityEvent onPyramidGrabbed;
    
    public void OnMouseOver()
    {
        Debug.LogWarning("test");
        if (empty) return;
        if (Input.GetMouseButtonDown(0) && open)
        {
            Debug.LogError("test");
            PyramidItem.Instance.AddPyramid();
            onPyramidGrabbed.Invoke();
            empty = true;
        }
    }

    public void OpenChest()
    {
        open = true;
        animation.Play();
    }
}
