namespace Roulette.Model
{
    using System;
    using System.Text;

    public class Player
    {
        #region Fields
       
        // Bool state of received event
        private bool receivedEvent;

        #endregion Fields

        #region Constructors

        /// <summary>Player constructor</summary>
        /// <param name="playerName">Player name</param>
        /// <param name="initialCash">Initial account cash</param>
        public Player(string playerName, int initialCash)
        {
            if (playerName == null || initialCash < 0)
            {
                throw new ArgumentException();
            }

            Name = playerName;
            Cash = initialCash;
            State = STATE.NOTINGAME;
            receivedEvent = false;
        }

        #endregion Constructors

        #region Enums

        /// <summary>Player state enumeration</summary>
        public enum STATE
        {
            NOTINGAME, BLACK, RED, GREEN, EVEN, ODD
        }

        #endregion Enums

        #region Properties

        // Minimum player cash
        public static int MIN_CASH { get => -100; }

        // Player name
        public string Name { get; private set; }

        // Player cash
        public int Cash { get; private set; }

        // Player state
        public STATE State { get; private set; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Add cash to account</summary>
        /// <param name="amount">Amount to add</param>
        public void AddCash(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException();
            }

            Cash += amount;
        }

        /// <summary>Take cash from account</summary>
        /// <param name="amount">Amount to take</param>
        public void TakeCash(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException();
            }

            Cash -= amount;
        }

        /// <summary>Set player state</summary>
        /// <param name="state">State to set</param>
        public void SetState(STATE state)
        {
            State = state;
        }

        /// <summary>Black color event handler</summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void BlackColorEventHandler(object sender, SpinnerEventArgs e)
        {
            if (State == STATE.BLACK)
            {
                receivedEvent = true;
                AddCash(10);
            }
        }

        /// <summary>Red color event handler</summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void RedColorEventHandler(object sender, SpinnerEventArgs e)
        {
            if (State == STATE.RED)
            {
                receivedEvent = true;
                AddCash(10);
            }
        }

        /// <summary>Green color event handler</summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void GreenColorEventHandler(object sender, SpinnerEventArgs e)
        {
            if (State == STATE.GREEN)
            {
                receivedEvent = true;
                AddCash(50);
            }
        }

        /// <summary>Event number event handler</summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void EvenNumberEventHandler(object sender, SpinnerEventArgs e)
        {
            if (State == STATE.EVEN)
            {
                receivedEvent = true;
                AddCash(10);
            }
        }

        /// <summary>Odd number event handler</summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void OddNumberEventHandler(object sender, SpinnerEventArgs e)
        {
            if (State == STATE.ODD)
            {
                receivedEvent = true;
                AddCash(10);
            }
        }

        /// <summary>End of spinning event</summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void SpinEventHandler(object sender, SpinnerEventArgs e)
        {
            if (!(State == Player.STATE.NOTINGAME))
            {
                if (!receivedEvent)
                {
                    TakeCash(15);
                    if (Cash < MIN_CASH)
                    {
                        SetState(STATE.NOTINGAME);
                    }
                }

                receivedEvent = false;
            }
        }

        /// <summary>ToString</summary>
        /// <returns>Player string representation</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, ");
            sb.Append($"Cash: {this.Cash}, ");
            sb.Append($"State: {this.State}");
            return sb.ToString();
        }

        #endregion PublicAPI
    }
}
