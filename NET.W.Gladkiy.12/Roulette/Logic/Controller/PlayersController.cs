namespace Roulette.Controllers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    using Roulette.Model;

    public class PlayerController
    {
        #region Fields

        // Spinner controller
        private SpinnerController _spinnerController;

        #endregion Fields

        #region Constructors

        /// <summary>Creates player controller</summary>
        public PlayerController(SpinnerController spinnerController)
        {
            PlayersList = new ObservableCollection<Player>();
            _spinnerController = spinnerController;
        }

        #endregion Constructors

        #region Properties

        // Players list
        public ObservableCollection<Player> PlayersList { get; private set; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Adds player to players list</summary>
        /// <param name="playerName">Player name</param>
        /// <param name="initialCash">Initial account cash</param>
        public void AddPlayer(string playerName, int initialCash)
        {
            if (playerName == null || initialCash < 0)
            {
                throw new ArgumentException();
            }

            // Create player
            Player player = new Player(playerName, initialCash);
            PlayersList.Add(player);
            
            // Register player events
            _spinnerController.Spinner.BlackColorEvent += player.BlackColorEventHandler;
            _spinnerController.Spinner.BlackColorEvent += player.BlackColorEventHandler;
            _spinnerController.Spinner.RedColorEvent += player.RedColorEventHandler;
            _spinnerController.Spinner.GreenColorEvent += player.GreenColorEventHandler;
            _spinnerController.Spinner.EvenNumberEvent += player.EvenNumberEventHandler;
            _spinnerController.Spinner.OddNumberEvent += player.OddNumberEventHandler;
            _spinnerController.Spinner.SpinEvent += player.SpinEventHandler;
        }

        /// <summary>Clears players list</summary>
        public void ClearPlayersList()
        {
            _spinnerController.Spinner.ClearEventListeners();
            PlayersList.Clear();
        }

        /// <summary>Sets player state</summary>
        /// <param name="player">Player to set state</param>
        /// <param name="state">State to set</param>
        public void SetPlayerState(int playerIndex, Player.STATE state)
        {
            if (PlayersList == null || playerIndex < 0)
            {
                throw new ArgumentException();
            }
   
            if (PlayersList[playerIndex].Cash >= Player.MIN_CASH)
            {
                PlayersList[playerIndex].SetState(state);
                RefreshPlayersList();
            }
        }

        /// <summary>Refresh players list</summary>
        public void RefreshPlayersList()
        {
            CollectionViewSource.GetDefaultView(PlayersList).Refresh();
        }

        #endregion PublicAPI
    }
}
