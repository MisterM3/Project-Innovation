using shared;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

/**
 * Assignment 2 - Starting project.
 * 
 * @author J.C. Wichman
 */
public class TCPChatClient : MonoBehaviour
{
    [SerializeField] private string _hostname = "77.63.65.58";
    [SerializeField] private int _port = 55555;
    [SerializeField] private TCPMessageReceiver receiver;

    private TcpClient _client;

    void Start()
    {
        connectToServer();
    }

    private void Update()
    {
        if (_client.Available != 0)
        {
            byte[] inBytes = StreamUtil.Read(_client.GetStream());
            string inString = Encoding.UTF8.GetString(inBytes);
         //   receiver.DecodeMessage(inString);
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
			_client = new TcpClient();
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

            //echo client - send one, expect one (hint: that is not how a chat works ...)
            byte[] outBytes = Encoding.UTF8.GetBytes("test");
            StreamUtil.Write(_client.GetStream(), outBytes);

      //      byte[] inBytes = StreamUtil.Read(_client.GetStream());
      //      string inString = Encoding.UTF8.GetString(inBytes);
      //      Debug.Log(inString);
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
			StreamUtil.Write(_client.GetStream(), outBytes);

			byte[] inBytes = StreamUtil.Read(_client.GetStream());
            string inString = Encoding.UTF8.GetString(inBytes);
            Debug.Log(inString);
		} 
        catch (Exception e) 
        {
            Debug.Log(e.Message);
			//for quicker testing, we reconnect if something goes wrong.
			_client.Close();
			connectToServer();
		}
    }


}

