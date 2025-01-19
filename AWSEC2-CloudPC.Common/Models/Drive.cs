﻿using ProtoBuf;

namespace AWSEC2-CloudPC.Common.Models
{
    [ProtoContract]
    public class Drive
    {
        [ProtoMember(1)]
        public string DisplayName { get; set; }

        [ProtoMember(2)]
        public string RootDirectory { get; set; }
    }
}
