using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPadObject : MonoBehaviour
{

    [SerializeField] int goodNumber;
    [SerializeField] int numberCount;
    [SerializeField] int numberNow = 0;
    [SerializeField] int countNow = 0;

    [SerializeField] List<GameObject> keyPadNumbers;

    public  UnityEvent onSequenceCorrect;
    public UnityEvent onSequenceFalse;

    public EventHandler<int> onNumberInputted;

    public bool puzzleCompleted = false;

    // Start is called before the first frame update
    void Start()
    {

        ResetCode();

        foreach(GameObject obj in keyPadNumbers)
        {
            if (!obj.TryGetComponent<KeyPadButton>(out KeyPadButton keyPadButton))
            {
                keyPadButton = obj.AddComponent<KeyPadButton>();
            }
            if (!obj.TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
            {
                rigidBody = obj.AddComponent<Rigidbody>();
            }
            rigidBody.isKinematic = true;


            keyPadButton.OnObjectClicked += AddNumberToList;
        }
    }

    public void AddNumberToList(object sender, int numberAdded)
    {
        if (puzzleCompleted) return;
        if (!(sender is GameObject)) Debug.LogError("SENDER OF EVENT IS NOT A GAMEOBJECT BUT A " + sender.GetType());



            numberNow = numberNow * 10 + numberAdded;

        if (numberNow > 0)
        {
            countNow++;
            onNumberInputted?.Invoke(this, numberNow);
        }

        Debug.Log(numberNow);


        if (countNow == numberCount)
        {
            CheckCorrect();
        }

        
    }


    private void ResetCode()
    {
        countNow= 0;
        numberNow= 0;
        onSequenceFalse?.Invoke();
        onNumberInputted?.Invoke(this, numberNow);


    }


    public void CheckCorrect()
    {
        if (numberNow == goodNumber)
        {
            onSequenceCorrect?.Invoke();
            puzzleCompleted = true;
            Debug.Log("winner");
        }
        else ResetCode();
    }

    private void OnDestroy()
    {
        foreach (GameObject obj in keyPadNumbers)
        {
            if (!obj.TryGetComponent<KeyPadButton>(out KeyPadButton keyPadButton))
            {
                keyPadButton = obj.AddComponent<KeyPadButton>();
            }

            keyPadButton.OnObjectClicked -= AddNumberToList;


        }
    }
}
