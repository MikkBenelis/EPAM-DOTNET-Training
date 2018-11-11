namespace NET.W.Gladkiy._12
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Roulette.Controllers;
    using Roulette.Model;

    // Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {

        private SpinnerController spinnerController;
        private PlayerController playersController;

        // Main window constructor
        public MainWindow()
        {
            this.InitializeComponent();
        }

        // Main window loaded handler
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Create controllers
            this.spinnerController = new SpinnerController(this.SpinnerImage);
            this.playersController = new PlayerController(this.spinnerController);

            // Add players to players list
            for (int i = 1; i <= int.Parse(PlayersCountLabel.Content.ToString()); i++)
            {
                this.playersController.AddPlayer("Player " + i, 100);
            }

            // Setup players list
            PlayersList.ItemsSource = this.playersController.PlayersList;
        }

        // Spin button click
        private void SpinButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.spinnerController == null)
            {
                throw new NullReferenceException();
            }

            // Spin spinner and update players list when spinning ends
            if (!this.spinnerController.IsSpinning)
            {
                this.spinnerController.SpinSpinner(this.ResultLabel, () => this.playersController.RefreshPlayersList());
            }
        }

        // Set player state to given
        private void SetPlayerState(object sender, RoutedEventArgs e)
        {
            if (PlayersList.SelectedIndex >= 0 && !this.spinnerController.IsSpinning)
            {
                // Parse player state
                string stateStr = (sender as Button).Content.ToString();
                Player.STATE state = (Player.STATE)Enum.Parse(typeof(Player.STATE), stateStr);

                // Set player state and update players list
                int selectedPlayerIndex = PlayersList.SelectedIndex;
                this.playersController.SetPlayerState(selectedPlayerIndex, state);
            }
        }

        // Update slider value
        private void UpdateSliderValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayersCountLabel.Content = e.NewValue.ToString();
        }

        // Set new players count
        private void SetNewPlayersCount(object sender, RoutedEventArgs e)
        {
            if (!this.spinnerController.IsSpinning)
            {
                this.playersController.ClearPlayersList();
                for (int i = 1; i <= int.Parse(PlayersCountLabel.Content.ToString()); i++)
                {
                    this.playersController.AddPlayer("Player " + i, 100);
                }
            }
        }
    }
}
