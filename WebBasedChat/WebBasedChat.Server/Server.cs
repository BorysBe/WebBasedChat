using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WebBasedChat.Server
{
    public class Server : IDisposable
    {
        public static readonly string SampleAddress =  "http://" + Environment.MachineName + ":8008/WebBasedChat";
        private readonly IStorage _storage;
        private readonly ServiceHost _serviceHost;

        public Server(IStorage storage)
        {
            _storage = storage;
            try
            {
                Uri httpBaseAddress = Address;
                _serviceHost = new ServiceHost(typeof(ChatService), httpBaseAddress);
                _serviceHost.AddServiceEndpoint(typeof(IChatService), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
                _serviceHost.Open();
            }
            catch (Exception e)
            {
                _serviceHost = null;
            }
        }

        public void Dispose()
        {
            var disposable = ((IDisposable)_serviceHost);
            disposable?.Dispose();
        }

        public Uri Address => new Uri(SampleAddress);
    }
}
