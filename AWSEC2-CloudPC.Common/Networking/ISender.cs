using AWSEC2-CloudPC.Common.Messages;

namespace AWSEC2-CloudPC.Common.Networking
{
    public interface ISender
    {
        void Send<T>(T message) where T : IMessage;
        void Disconnect();
    }
}
