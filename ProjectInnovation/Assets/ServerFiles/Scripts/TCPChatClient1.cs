﻿using shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

/**
 * Assignment 2 - Starting project.
 * 
 * @author J.C. Wichman
 */
public class TCPChatClient1 : MonoBehaviour
{

    public static TCPChatClient1 Instance;

    [SerializeField] private string _hostname = "77.63.65.58";
    [SerializeField] private int _port = 55555;
    [SerializeField] private TCPMessageReceiver receiver;

    private TcpMessageChannel _client;

    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("ALREADY A CLIENT IN SCENE");
            Destroy(this);
            return;
        }

        Instance = this;

        connectToServer();
    }

    private void Update()
    {
        if (_client.HasMessage())
        {
            ASerializable message = _client.ReceiveMessage();

            //Debug.Log("reveived");
            receiver.DecodeASerializable(message);
            return;

            if (message is ChatMessage)
            {
                ChatMessage messageC = (ChatMessage)message;
                Debug.Log(messageC.message);

            }
            if (message is PuzzleOneSetup)
            {
                PuzzleOneSetup puzzle = (PuzzleOneSetup)message;
                Debug.Log(puzzle.name);
                foreach(bool b in puzzle.lightBool)
                {
                    Debug.Log(b);
                }
            }
            if (message is SliderSolution)
            {
                SliderSolution slider = (SliderSolution)message;

            }
            else Debug.Log("test");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TrySending();
        }
    }

    private void connectToServer()
    {
        try
        {
           // testClient = new TcpClient();
            _client = new TcpMessageChannel();
            _client.Connect(_hostname, _port);
            Debug.Log("Connected to server.");
        }
        catch (Exception e)
        {
            Debug.Log("Could not connect to server:");
            Debug.Log(e.Message);
        }
    }



    private void TrySending()
    {
        try
        {
            ChatMessage message = new ChatMessage();
            message.name= "test";
            message.message = "da";
            sendMessage(message);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            //for quicker testing, we reconnect if something goes wrong.
            _client.Close();
            connectToServer();
        }

    }

    private void onTextEntered(string pInput)
    {
        if (pInput == null || pInput.Length == 0) return;

		try 
        {

			//echo client - send one, expect one (hint: that is not how a chat works ...)
			byte[] outBytes = Encoding.UTF8.GetBytes(pInput);
		//	StreamUtil.Write(_client.GetStream(), outBytes);

//			byte[] inBytes = StreamUtil.Read(_client.GetStream());
      //      string inString = Encoding.UTF8.GetString(inBytes);
       //     Debug.Log(inString);
		} 
        catch (Exception e) 
        {
            Debug.Log(e.Message);
			//for quicker testing, we reconnect if something goes wrong.
			_client.Close();
			connectToServer();
		}
    }

    public void sendMessage(ASerializable ser)
    {
        Debug.Log(ser.name);
        _client.SendMessage(ser);
    }


}

