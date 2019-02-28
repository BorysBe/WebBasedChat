using System;
using System.Windows;

namespace WebBasedChat.WpfClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            DataContext = App.CommunicationFacade;
        }
        
        private void Proceed_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: introduce MVVM Light to easily bind commands to button
            
            if (!string.IsNullOrEmpty(Nickname.Text))
            {
                try
                {
                    App.StateViewModel.Name = Nickname.Text;
                    App.CommunicationFacade.Proceed();
                    var roomScreen = new RoomScreen();
                    roomScreen.Title = Nickname.Text;
                    roomScreen.ShowDialog();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Please, put your nickname first");
            }
        }
    }
}
