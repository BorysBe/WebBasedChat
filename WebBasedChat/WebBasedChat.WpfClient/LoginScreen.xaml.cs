using System.Windows;
using System.Windows.Controls;

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
            App.CommunicationFacade.Proceed();
            var roomScreen = new RoomScreen();
            roomScreen.ShowDialog();
        }
    }
}
