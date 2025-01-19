using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class ClientIdentificationResult : IMessage
    {
        [ProtoMember(1)]
        public bool Result { get; set; }
    }
}
