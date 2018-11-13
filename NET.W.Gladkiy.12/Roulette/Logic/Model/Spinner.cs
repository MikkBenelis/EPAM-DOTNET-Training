namespace Roulette.Model
{
    using System;
    using System.Text;
    using NLog;

    public class Spinner
    {
        #region Constructors

        /// <summary>Creates spinner object</summary>
        public Spinner()
        {
            Numbers = new Number[]
            {
                new Number(0, Number.EColor.GREEN),
                new Number(26, Number.EColor.BLACK),
                new Number(3, Number.EColor.RED),
                new Number(35, Number.EColor.BLACK),
                new Number(12, Number.EColor.RED),
                new Number(28, Number.EColor.BLACK),
                new Number(7, Number.EColor.RED),
                new Number(29, Number.EColor.BLACK),
                new Number(18, Number.EColor.RED),
                new Number(22, Number.EColor.BLACK),
                new Number(9, Number.EColor.RED),
                new Number(31, Number.EColor.BLACK),
                new Number(14, Number.EColor.RED),
                new Number(20, Number.EColor.BLACK),
                new Number(1, Number.EColor.RED),
                new Number(33, Number.EColor.BLACK),
                new Number(16, Number.EColor.RED),
                new Number(24, Number.EColor.BLACK),
                new Number(5, Number.EColor.RED),
                new Number(10, Number.EColor.BLACK),
                new Number(23, Number.EColor.RED),
                new Number(8, Number.EColor.BLACK),
                new Number(30, Number.EColor.RED),
                new Number(11, Number.EColor.BLACK),
                new Number(36, Number.EColor.RED),
                new Number(13, Number.EColor.BLACK),
                new Number(27, Number.EColor.RED),
                new Number(6, Number.EColor.BLACK),
                new Number(34, Number.EColor.RED),
                new Number(17, Number.EColor.BLACK),
                new Number(25, Number.EColor.RED),
                new Number(2, Number.EColor.BLACK),
                new Number(21, Number.EColor.RED),
                new Number(4, Number.EColor.BLACK),
                new Number(19, Number.EColor.RED),
                new Number(15, Number.EColor.BLACK),
                new Number(32, Number.EColor.RED)
            };
        }

        #endregion Constructors

        #region Properties

        public delegate void OnSpin(object sender, SpinnerEventArgs e);

        public event OnSpin SpinEvent;

        public event OnSpin BlackColorEvent;

        public event OnSpin RedColorEvent;

        public event OnSpin GreenColorEvent;

        public event OnSpin EvenNumberEvent;

        public event OnSpin OddNumberEvent;

        public Number[] Numbers { get; private set; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Send spinning result notifications</summary>
        /// <param name="number">Ranom spinned number</param>
        public void Spin(Number number)
        {
            var sb = new StringBuilder();
            sb.Append($"Players: {SpinEvent.GetInvocationList().Length}, Events: ");

            SpinnerEventArgs spinEventArgs = new SpinnerEventArgs(number);
            if (number.Color == Number.EColor.BLACK)
            {
                sb.Append("BLACK, ");
                BlackColorEvent?.Invoke(this, spinEventArgs);
            }

            if (number.Color == Number.EColor.RED)
            {
                sb.Append("RED, ");
                RedColorEvent?.Invoke(this, spinEventArgs);
            }

            if (number.Color == Number.EColor.GREEN)
            {
                sb.Append("GREEN, ");
                GreenColorEvent?.Invoke(this, spinEventArgs);
            }

            if (number.Value % 2 == 0)
            {
                sb.Append("EVEN, ");
                EvenNumberEvent?.Invoke(this, spinEventArgs);
            }

            if (!(number.Value % 2 == 0))
            {
                sb.Append("ODD, ");
                OddNumberEvent?.Invoke(this, spinEventArgs);
            }

            sb.Append(number.Value);
            LogManager.GetCurrentClassLogger().Info(sb.ToString());
            SpinEvent?.Invoke(this, spinEventArgs);
        }

        /// <summary>Clear event listeners</summary>
        public void ClearEventListeners()
        {
            BlackColorEvent = null;
            RedColorEvent = null;
            GreenColorEvent = null;
            EvenNumberEvent = null;
            OddNumberEvent = null;
            SpinEvent = null;
        }

        #endregion PublicAPI
    }
}
