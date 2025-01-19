using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class SetStatus : IMessage
    {
        [ProtoMember(1)]
        public string Message { get; set; }
    }
}
