using ProtoBuf;
using AWSEC2-CloudPC.Common.Models;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoStartupItemAdd : IMessage
    {
        [ProtoMember(1)]
        public StartupItem StartupItem { get; set; }
    }
}
