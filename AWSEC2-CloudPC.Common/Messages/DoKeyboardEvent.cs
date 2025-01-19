using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoKeyboardEvent : IMessage
    {
        [ProtoMember(1)]
        public byte Key { get; set; }

        [ProtoMember(2)]
        public bool KeyDown { get; set; }
    }
}
