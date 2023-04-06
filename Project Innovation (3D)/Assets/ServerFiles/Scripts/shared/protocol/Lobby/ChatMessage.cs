namespace shared
{
	/**
	 * BIDIRECTIONAL Chat message for the lobby
	 */
	public class ChatMessage : ASerializable
	{
		public string message;

		public override void Serialize(Packet pPacket)
		{
			pPacket.Write(name);
			pPacket.Write(message);
		}

		public override void Deserialize(Packet pPacket)
		{
			name = pPacket.ReadString();
			message = pPacket.ReadString();

		}
	}
}
