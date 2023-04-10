using System.Collections.Generic;


namespace shared
{
    public class SliderSolution : ASerializable
    {

        public int value1;
        public int value2;
        public int value3;
        public override void Serialize(Packet pPacket)
        {
            pPacket.Write(name);
            pPacket.Write(value1);
            pPacket.Write(value2);
            pPacket.Write(value3);

        }

        public override void Deserialize(Packet pPacket)
        {

            name = pPacket.ReadString();
            value1 = pPacket.ReadInt();
            value2 = pPacket.ReadInt();
            value3 = pPacket.ReadInt();

        }
    }
}
