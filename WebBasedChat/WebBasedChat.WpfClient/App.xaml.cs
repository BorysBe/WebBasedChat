using System;
using System.Windows;
using WebBasedChat.Client.Facades;
using WebBasedChat.Client.Facades.Contacts;
using WebBasedChat.Client.Factories;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;

namespace WebBasedChat.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ICommunicationFacade CommunicationFacade;
        public static State StateViewModel;
        public static readonly string SampleAddress = "http://" + Environment.MachineName + ":8008/WebBasedChat";

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            StateViewModel = new State();
            CommunicationFacade = new CommunicationFacade(StateViewModel, new CommandFactory(StateViewModel, new ClientServiceProxy(SampleAddress))); 
        }
    }
}
