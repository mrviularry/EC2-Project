using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class GetDirectory : IMessage
    {
        [ProtoMember(1)]
        public string RemotePath { get; set; }
    }
}
