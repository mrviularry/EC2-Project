using ProtoBuf;
using AWSEC2-CloudPC.Common.Models;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class GetDrivesResponse : IMessage
    {
        [ProtoMember(1)]
        public Drive[] Drives { get; set; }
    }
}
