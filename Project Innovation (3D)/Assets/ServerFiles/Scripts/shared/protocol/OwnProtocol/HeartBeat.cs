using shared;
using System.Collections;
using System.Collections.Generic;

public class HeartBeat : ASerializable
{

    public override void Serialize(Packet pPacket)
    {
        pPacket.Write(name);


    }

    public override void Deserialize(Packet pPacket)
    {

        name = pPacket.ReadString();


    }
}
