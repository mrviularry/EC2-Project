using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages.ReverseProxy
{
    [ProtoContract]
    public class ReverseProxyDisconnect : IMessage
    {
        [ProtoMember(1)]
        public int ConnectionId { get; set; }
    }
}
