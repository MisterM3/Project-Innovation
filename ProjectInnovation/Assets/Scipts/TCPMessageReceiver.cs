using shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;

public class TCPMessageReceiver : MonoBehaviour
{
    [Serializable]
    public struct MessageEvent
    {
        public string messageName;
        public ASerializableUnityEvent fireEvent;
    }

    [System.Serializable]
    public class ASerializableUnityEvent : UnityEvent<ASerializable>
    {
        public ASerializable AserParam;
    }

    public List<MessageEvent> messages;

    /*
    public void DecodeMessage(string message)
    {

        Debug.Log("fae");

        foreach(MessageEvent messageEvent in messages)
        {
            Packet packet = new Packet();
            
            Debug.Log(messageEvent.messageName);

            if (messageEvent.messageName == message)
            {
                messageEvent.fireEvent.Invoke();
            }
        }
    }
    */

    public void DecodeASerializable(ASerializable solution)
    {
        
        foreach (MessageEvent messageEvent in messages)
        {
           // Packet packet = new Packet();

            //sDebug.Log(solution.name);

            if (messageEvent.messageName == solution.name)
            {
                messageEvent.fireEvent.Invoke(solution) ;
            }
        }
    }

    public void TestDebug()
    {
        Debug.LogWarning("TEA");
    }
}
