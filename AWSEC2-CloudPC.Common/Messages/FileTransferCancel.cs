﻿using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class FileTransferCancel : IMessage
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Reason { get; set; }
    }
}
