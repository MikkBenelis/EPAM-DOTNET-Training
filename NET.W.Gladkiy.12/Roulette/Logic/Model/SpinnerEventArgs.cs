namespace Roulette.Model
{
    using System.Text;
    
    public struct Number
    {
        #region Fields

        public int Value;
        public EColor Color;

        #endregion Fields

        #region Constructors

        /// <summary>Creates number with given value and color</summary>
        /// <param name="value">Number value</param>
        /// <param name="color">Number color</param>
        public Number(int value, EColor color)
        {
            Value = value;
            Color = color;
        }

        #endregion Constructors

        #region Enums

        /// <summary>Number color enumetation</summary>
        public enum EColor
        {
            BLACK, RED, GREEN
        }

        #endregion Enums

        #region PublicAPI

        /// <summary>ToString</summary>
        /// <returns>Number string representation</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Value: {Value}, ");
            sb.Append($"Color: {Color}");
            return sb.ToString();
        }

        #endregion PublicAPI
    }

    public class SpinnerEventArgs
    {
        #region Constructors

        /// <summary>Creates spin event arguments</summary>
        /// <param name="number"></param>
        public SpinnerEventArgs(Number number)
        {
            Number = number;
        }

        #endregion Constructors

        #region Properties

        /// <summary>Number with color</summary>
        public Number Number { get; private set; }

        #endregion Properties
    }
}
