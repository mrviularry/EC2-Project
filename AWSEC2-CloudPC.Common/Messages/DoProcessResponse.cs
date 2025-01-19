using ProtoBuf;
using AWSEC2-CloudPC.Common.Enums;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoProcessResponse : IMessage
    {
        [ProtoMember(1)]
        public ProcessAction Action { get; set; }

        [ProtoMember(2)]
        public bool Result { get; set; }
    }
}
