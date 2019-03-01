using System;
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
            CreateRefresher();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.CommunicationFacade.Proceed();
            Close();
        }

        private void ChatScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            ReloadMessages();
        }

        private void ReloadMessages()
        {
            Messages.Text = "";
            try
            {
                App.CommunicationFacade.LoadMessages();
                foreach (var message in App.StateViewModel.Messages)
                {
                    Messages.Text += message.UserName + " <" + message.DateTime + "> : " + message.Content + Environment.NewLine;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.CommunicationFacade.Enter(Message.Text);
                App.CommunicationFacade.Submit();
                Message.Text = string.Empty;
                ReloadMessages();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CreateRefresher()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += delegate
            {
                ReloadMessages();;
            };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }
    }
}
