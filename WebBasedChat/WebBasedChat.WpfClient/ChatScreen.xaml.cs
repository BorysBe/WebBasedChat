using System;
using System.Linq;
using System.Windows;

namespace WebBasedChat.WpfClient
{
    /// <summary>
    /// Interaction logic for ChatScreen.xaml
    /// </summary>
    public partial class ChatScreen : Window
    {
        public ChatScreen()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.CommunicationFacade.Proceed();
            Close();
        }

        private void ChatScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            App.CommunicationFacade.LoadMesages();
            foreach (var message in App.StateViewModel.Messages.Where(x=> x.RoomId == App.StateViewModel.JoinedChatRoom))
            {
                Messages.Text += message.UserId + " <" + message.DateTime + "> " + Environment.NewLine;
            }
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            App.CommunicationFacade.Enter(Message.Text);
        }
    }
}
