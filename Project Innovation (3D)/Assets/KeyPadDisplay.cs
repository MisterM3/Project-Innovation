using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadDisplay : MonoBehaviour
{

    [SerializeField] KeyPadObject keyPad;
    [SerializeField] TextMeshProUGUI displayNumber;

    // Start is called before the first frame update
    void Start()
    {
        keyPad.onNumberInputted += ChangeDisplay;
    }

    private void ChangeDisplay(object sender, int number)
    {
        displayNumber.text = number.ToString();
    }

    public void OnDestroy()
    {
        keyPad.onNumberInputted -= ChangeDisplay;
    }


}
