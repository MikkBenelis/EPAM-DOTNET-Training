namespace Roulette.Model
{
    using System;
    using System.IO;
    using System.Text;

    public class Spinner
    {
        #region Constructors

        /// <summary>Creates spinner object</summary>
        public Spinner()
        {
            Numbers = new Number[]
            {
                new Number(0, NumberColor.GREEN),
                new Number(26, NumberColor.BLACK),
                new Number(3, NumberColor.RED),
                new Number(35, NumberColor.BLACK),
                new Number(12, NumberColor.RED),
                new Number(28, NumberColor.BLACK),
                new Number(7, NumberColor.RED),
                new Number(29, NumberColor.BLACK),
                new Number(18, NumberColor.RED),
                new Number(22, NumberColor.BLACK),
                new Number(9, NumberColor.RED),
                new Number(31, NumberColor.BLACK),
                new Number(14, NumberColor.RED),
                new Number(20, NumberColor.BLACK),
                new Number(1, NumberColor.RED),
                new Number(33, NumberColor.BLACK),
                new Number(16, NumberColor.RED),
                new Number(24, NumberColor.BLACK),
                new Number(5, NumberColor.RED),
                new Number(10, NumberColor.BLACK),
                new Number(23, NumberColor.RED),
                new Number(8, NumberColor.BLACK),
                new Number(30, NumberColor.RED),
                new Number(11, NumberColor.BLACK),
                new Number(36, NumberColor.RED),
                new Number(13, NumberColor.BLACK),
                new Number(27, NumberColor.RED),
                new Number(6, NumberColor.BLACK),
                new Number(34, NumberColor.RED),
                new Number(17, NumberColor.BLACK),
                new Number(25, NumberColor.RED),
                new Number(2, NumberColor.BLACK),
                new Number(21, NumberColor.RED),
                new Number(4, NumberColor.BLACK),
                new Number(19, NumberColor.RED),
                new Number(15, NumberColor.BLACK),
                new Number(32, NumberColor.RED)
            };
        }

        #endregion Constructors

        #region Properties

        public delegate void OnSpin(object sender, SpinEventArgs e);

        public event OnSpin SpinEvent;

        public event OnSpin BlackColorEvent;

        public event OnSpin RedColorEvent;

        public event OnSpin GreenColorEvent;

        public event OnSpin EvenNumberEvent;

        public event OnSpin OddNumberEvent;

        public Number[] Numbers { get; private set; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Sends spinning result notification</summary>
        /// <param name="number">Ranom spinned number</param>
        public void Spin(Number number)
        {
            var sb = new StringBuilder();
            sb.Append($"Time: {DateTime.Now}, ");
            sb.Append($"Players: {SpinEvent.GetInvocationList().Length}, ");

            SpinEventArgs spinEventArgs = new SpinEventArgs(number);
            if (number.Color == NumberColor.BLACK)
            {
                LogEvent(sb.ToString() + "Event: BLACK");
                BlackColorEvent?.Invoke(this, spinEventArgs);
            }

            if (number.Color == NumberColor.RED)
            {
                LogEvent(sb.ToString() + "Event: RED");
                RedColorEvent?.Invoke(this, spinEventArgs);
            }

            if (number.Color == NumberColor.GREEN)
            {
                LogEvent(sb.ToString() + "Event: GREEN");
                GreenColorEvent?.Invoke(this, spinEventArgs);
            }

            if (number.Value % 2 == 0)
            {
                LogEvent(sb.ToString() + "Event: EVEN");
                EvenNumberEvent?.Invoke(this, spinEventArgs);
            }

            if (!(number.Value % 2 == 0))
            {
                LogEvent(sb.ToString() + "Event: ODD");
                OddNumberEvent?.Invoke(this, spinEventArgs);
            }
            
            SpinEvent?.Invoke(this, spinEventArgs);
        }

        #endregion PublicAPI

        #region PrivateAPI

        private static void LogEvent(string logData)
        {
            File.AppendAllText("Roulette.log", logData + Environment.NewLine);
        }

        #endregion PrivateAPI
    }
}
