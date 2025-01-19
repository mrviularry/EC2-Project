using ProtoBuf;
using AWSEC2-CloudPC.Common.Models;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class GetDirectoryResponse : IMessage
    {
        [ProtoMember(1)]
        public string RemotePath { get; set; }

        [ProtoMember(2)]
        public FileSystemEntry[] Items { get; set; }
    }
}
