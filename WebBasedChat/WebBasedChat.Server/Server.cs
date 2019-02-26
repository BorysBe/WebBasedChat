using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WebBasedChat.Server.Contracts;

namespace WebBasedChat.Server
{
    public class Server : IDisposable
    {
        public static readonly string SampleAddress =  "http://" + Environment.MachineName + ":8008/WebBasedChat";
        private readonly ServiceHost _serviceHost;

        public Server(IStorage storage)
        {
            try
            {
                var myService = new ChatService(storage);
                Uri httpBaseAddress = Address;
                _serviceHost = new ServiceHost(myService, httpBaseAddress);
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
