using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;


public class KeyPadButton : MonoBehaviour
{

    [SerializeField] int number;

    public EventHandler<int> OnObjectClicked;


    //private void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        OnObjectClicked?.Invoke(this.gameObject, number);
    //    }
    //}

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { Click(); });
    }

    void Click()
    {
        OnObjectClicked?.Invoke(this.gameObject, number);
    }

}
