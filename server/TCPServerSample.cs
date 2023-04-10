using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using shared;
using System.Threading;
using server;
class TCPServerSample
{
	/**
	 * This class implements a simple concurrent TCP Echo server.
	 * Read carefully through the comments below.
	 */
	public static void Main(string[] args)
	{

		TCPServerSample server = new TCPServerSample();
		server.run();
	}


	LobbyRoom _lobbyRoom;
	private void run()
	{
		Log.LogInfo("Starting server on port 55555", this, ConsoleColor.Gray);

		//start listening for incoming connections (with max 50 in the queue)
		//we allow for a lot of incoming connections, so we can handle them
		//and tell them whether we will accept them or not instead of bluntly declining them
		TcpListener listener = new TcpListener(IPAddress.Any, 55555);
		listener.Start(50);

		while (true)
		{
			//check for new members	
			if (listener.Pending())
			{
				//get the waiting client
				Log.LogInfo("Accepting new client...", this, ConsoleColor.White);
				TcpClient client = listener.AcceptTcpClient();
				Console.WriteLine(client);
				//and wrap the client in an easier to use communication channel
				TcpMessageChannel channel = new TcpMessageChannel(client);
				//and add it to the login room for further 'processing'
				_lobbyRoom.AddMember(channel);
			}

			_lobbyRoom.Update();

			Thread.Sleep(100);
		}

	}

	private TCPServerSample()
	{
		_lobbyRoom = new LobbyRoom(this);

	}
}


