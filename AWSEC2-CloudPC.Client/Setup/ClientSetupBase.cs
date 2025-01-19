using AWSEC2-CloudPC.Client.User;

namespace AWSEC2-CloudPC.Client.Setup
{
    public abstract class ClientSetupBase
    {
        protected UserAccount UserAccount;

        protected ClientSetupBase()
        {
            UserAccount = new UserAccount();
        }
    }
}
