using System;
using System.Linq;
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
            CreateRefresher();
        }

        private void CreateRefresher()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += delegate
            {
                ReloadRooms();
            };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
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
                this.RoomList.Items.Add(room.Value);
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

        private void Join_OnClick(object sender, RoutedEventArgs e)
        {
            App.StateViewModel.SelectedChatRoom = RoomList.SelectedIndex;
            App.CommunicationFacade.Join();
            App.CommunicationFacade.Proceed();


            var chat = new ChatScreen();
            chat.Title = "Room " + RoomList.SelectedIndex + " | " + App.StateViewModel.Name;
            chat.ShowDialog();
        }
    }
}
