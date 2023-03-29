using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TCPMessageReceiver : MonoBehaviour
{
    [Serializable]
    public struct MessageEvent
    {
        public string messageName;
        public UnityEvent fireEvent;
    }

    public List<MessageEvent> messages;


    public void DecodeMessage(string message)
    {

        Debug.Log("fae");

        foreach(MessageEvent messageEvent in messages)
        {

            Debug.Log(messageEvent.messageName);

            if (messageEvent.messageName == message)
            {
                messageEvent.fireEvent.Invoke();
            }
        }
    }

    public void TestDebug()
    {
        Debug.LogWarning("TEA");
    }
}
