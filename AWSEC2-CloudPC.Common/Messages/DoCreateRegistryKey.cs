using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoCreateRegistryKey : IMessage
    {
        [ProtoMember(1)]
        public string ParentPath { get; set; }
    }
}
