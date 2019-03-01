using System;
using System.Windows;
using System.Windows.Threading;

namespace WebBasedChat.WpfClient
{
    /// <summary>
    /// Interaction logic for ChatScreen.xaml
    /// </summary>
    public partial class ChatScreen : Window
    {
        private DispatcherTimer _dispatcherTimer;

        public ChatScreen()
        {
            InitializeComponent();
            CreateRefresher();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
            App.CommunicationFacade.Proceed();
            App.StateViewModel.Messages.Clear();
            Messages.Text = "";
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
                    Messages.Text += $"{message.RoomName} - " + message.UserName + " <" + message.DateTime + "> : " + message.Content + Environment.NewLine;
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
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += delegate
            {
                ReloadMessages();;
            };
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimer.Start();
        }
    }
}
