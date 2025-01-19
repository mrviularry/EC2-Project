using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoLoadRegistryKey : IMessage
    {
        [ProtoMember(1)]
        public string RootKeyName { get; set; }
    }
}
