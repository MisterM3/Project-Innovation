using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shared;

public class TCPMessageSender : MonoBehaviour
{

    [SerializeField] string nameString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SentMessage()
    {
        ChatMessage message = new ChatMessage();
        message.name = nameString;
        message.message = nameString;
        TCPChatClient1.Instance.sendMessage(message);
    }
}
