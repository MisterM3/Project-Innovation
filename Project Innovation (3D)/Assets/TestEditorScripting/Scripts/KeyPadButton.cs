using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class KeyPadButton : MonoBehaviour
{

    [SerializeField] int number;

    public EventHandler<int> OnObjectClicked;


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("AHHH");
            OnObjectClicked?.Invoke(this.gameObject, number);
        }
    }


}
