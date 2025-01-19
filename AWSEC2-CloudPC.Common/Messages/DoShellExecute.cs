using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoShellExecute : IMessage
    {
        [ProtoMember(1)]
        public string Command { get; set; }
    }
}
