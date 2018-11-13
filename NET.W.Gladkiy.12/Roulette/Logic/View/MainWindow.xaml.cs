namespace Roulette
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    using Roulette.Controllers;
    using Roulette.Model;

    // Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        #region Fields

        private SpinnerController spinnerController;
        private PlayerController playersController;

        #endregion Fields

        #region Constructors

        // Main window constructor
        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        // Initial player cash amount
        public static int INITIAL_CASH { get => 100; }

        // Player name to be shown in players list
        public static string PLAYER_NAME { get => "Player"; }

        #endregion Properties

        #region PrivateAPI

        // Main window loaded handler
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Setup NLog
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget("filetarget")
            {
                FileName = "${basedir}/Roulette.log",
                Layout = "[${level}] [${longdate}] ${message}"
            };
            config.AddTarget(fileTarget);
            config.AddRuleForAllLevels("filetarget");
            LogManager.Configuration = config;

            // Create controllers
            this.spinnerController = new SpinnerController(this.SpinnerImage);
            this.playersController = new PlayerController(this.spinnerController);

            // Add players to players list and show them in list
            PlayersList.ItemsSource = this.playersController.PlayersList;
            this.SetNewPlayersCount(null, null);
        }

        // Spin button click
        private void SpinButtonClick(object sender, RoutedEventArgs e)
        {
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

        // Set new players count
        private void SetNewPlayersCount(object sender, RoutedEventArgs e)
        {
            if (!this.spinnerController.IsSpinning)
            {
                this.playersController.ClearPlayersList();
                for (int i = 1; i <= int.Parse(PlayersCountLabel.Content.ToString()); i++)
                {
                    this.playersController.AddPlayer($"{PLAYER_NAME} {i}", INITIAL_CASH);
                }
            }
        }

        // Update slider value
        private void UpdateSliderValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayersCountLabel.Content = e.NewValue.ToString();
        }

        #endregion PrivateAPI
    }
}
