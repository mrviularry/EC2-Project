﻿using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class DoVisitWebsite : IMessage
    {
        [ProtoMember(1)]
        public string Url { get; set; }

        [ProtoMember(2)]
        public bool Hidden { get; set; }
    }
}
