using System;
using System.Windows;

namespace WebBasedChat.WpfClient
{
    /// <summary>
    /// Interaction logic for RoomScreen.xaml
    /// </summary>
    public partial class RoomScreen : Window
    {
        public RoomScreen()
        {
            InitializeComponent();
        }

        private void RoomScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                App.CommunicationFacade.LoadRooms();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            ReloadRooms();
        }

        private void ReloadRooms()
        {
            this.RoomList.Items.Clear();
            foreach (var room in App.StateViewModel.Rooms)
            {
                this.RoomList.Items.Add(room.Key);
            }
        }

        private void CreateRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.CommunicationFacade.CreateRoom();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            ReloadRooms();
        }
    }
}
