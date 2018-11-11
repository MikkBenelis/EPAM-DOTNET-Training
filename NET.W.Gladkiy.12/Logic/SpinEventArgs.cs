namespace Roulette.Model
{
    using System.Text;

    /// <summary>
    /// Enumeration of number colors
    /// </summary>
    public enum NumberColor
    {
        BLACK, RED, GREEN
    }

    /// <summary>
    /// Struct of number with value and color
    /// </summary>
    public struct Number
    {
        public int Value;
        public NumberColor Color;

        /// <summary>Creates number with given value and color</summary>
        /// <param name="value">Number value</param>
        /// <param name="color">Number color</param>
        public Number(int value, NumberColor color)
        {
            Value = value;
            Color = color;
        }

        /// <summary>ToString</summary>
        /// <returns>Number string representation</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Value: {Value}, ");
            sb.Append($"Color: {Color}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Spin event arguments
    /// </summary>
    public class SpinEventArgs
    {
        /// <summary>Creates spin event arguments</summary>
        /// <param name="number"></param>
        public SpinEventArgs(Number number)
        {
            Number = number;
        }

        /// <summary>Number with color</summary>
        public Number Number { get; private set; }
    }
}
