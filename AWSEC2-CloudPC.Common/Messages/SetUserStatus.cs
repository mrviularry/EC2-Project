using ProtoBuf;
using AWSEC2-CloudPC.Common.Enums;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class SetUserStatus : IMessage
    {
        [ProtoMember(1)]
        public UserStatus Message { get; set; }
    }
}
