using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages.ReverseProxy
{
    [ProtoContract]
    public class ReverseProxyData : IMessage
    {
        [ProtoMember(1)]
        public int ConnectionId { get; set; }

        [ProtoMember(2)]
        public byte[] Data { get; set; }
    }
}
