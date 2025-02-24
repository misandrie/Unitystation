using Lidgren.Network;
using Robust.Shared.Network;
using Robust.Shared.Serialization;

namespace Content.Shared.Players;

public sealed class MsgAppearanceBan : NetMessage
{
    public override MsgGroups MsgGroup => MsgGroups.EntityEvent;

    public bool Banned;

    public override void ReadFromBuffer(NetIncomingMessage buffer, IRobustSerializer serializer)
    {
        Banned = buffer.ReadBoolean();
    }

    public override void WriteToBuffer(NetOutgoingMessage buffer, IRobustSerializer serializer)
    {
        buffer.Write(Banned);
    }
}
