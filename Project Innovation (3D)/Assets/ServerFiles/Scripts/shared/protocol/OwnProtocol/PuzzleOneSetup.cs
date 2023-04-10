using System.Collections.Generic;


namespace shared
{
	/**
	 * Send from SERVER to CLIENT to notify that the client has joined a specific room (i.e. that it should change state).
	 */
	public class PuzzleOneSetup : ASerializable
	{
		public string name;
		//public List<bool> lightBool = new List<bool>();
		public bool[,] lightBool;
		public override void Serialize(Packet pPacket)
		{
			pPacket.Write(name);
			pPacket.Write(lightBool.GetLength(0));
			pPacket.Write(lightBool.GetLength(1));
            for (int i = 0; i < lightBool.GetLength(0); i++)
            {
                for (int j = 0; j < lightBool.GetLength(2); j++)
                {
					pPacket.Write(lightBool[i, j]);

                }
            }

        }

		public override void Deserialize(Packet pPacket)
		{

			name = pPacket.ReadString();
			int count1 = pPacket.ReadInt();
			int count2 = pPacket.ReadInt();
			lightBool = new bool[count1, count2];



			for (int i = 0; i < count1; i++)
			{
				for (int j = 0; j < count2; j++)
				{
					lightBool[i,j] = (pPacket.ReadBool());

				}
			}
		}
	}
}
