using AWSEC2-CloudPC.Common.Messages;

namespace AWSEC2-CloudPC.Client.Messages
{
    public abstract class NotificationMessageProcessor : MessageProcessorBase<string>
    {
        protected NotificationMessageProcessor() : base(true)
        {
        }
    }
}
