using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WebBasedChat.Server
{
    public class Server : IDisposable
    {
        private readonly IStorage _storage;
        private readonly ServiceHost _serviceHost;

        public Server(IStorage storage)
        {
            _storage = storage;
            try
            {
                Uri httpBaseAddress = new Uri("http://localhost:4321/WebBasedChat");
                _serviceHost = new ServiceHost(typeof(ChatService),
                    httpBaseAddress);
                _serviceHost.AddServiceEndpoint(typeof(IChatService),
                    new WSHttpBinding(), "");
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                _serviceHost.Description.Behaviors.Add(serviceBehavior);
                _serviceHost.Open();
            }
            catch (Exception)
            {
                _serviceHost = null;
            }
        }

        public void Dispose()
        {
            var disposable = ((IDisposable)_serviceHost);
            disposable?.Dispose();
        }
    }
}
