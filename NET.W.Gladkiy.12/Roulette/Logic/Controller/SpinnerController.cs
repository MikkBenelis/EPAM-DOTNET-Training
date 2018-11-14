namespace Roulette.Controllers
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using Roulette.Model;

    public class SpinnerController
    {
        #region Fields

        // Spinner image
        private Image _spinnerImage;

        #endregion Fields

        #region Constructors

        /// <summary>Creates spinner object with image</summary>
        /// <param name="spinnerImage">Image of spinner</param>
        /// <returns>Created spinner object</returns>
        public SpinnerController(Image spinnerImage)
        {
            if (spinnerImage == null)
            {
                throw new ArgumentException();
            }

            _spinnerImage = spinnerImage;
            Spinner = new Spinner();
            IsSpinning = false;
        }

        #endregion Constructors

        #region Properties

        // Spinner object
        public Spinner Spinner { get; private set; }

        // Spinning state
        public bool IsSpinning { get; private set; }

        // Spinning animation time
        private static double SPINNING_TIME { get => 5; }

        // Min spinning rounds
        private static double MIN_ROUNDS { get => 1; }

        // Max spinning rounds
        private static double MAX_ROUNDS { get => 3; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Spins spinner</summary>
        public void SpinSpinner(Label resultLabel, Action callback)
        {
            if (_spinnerImage == null || resultLabel == null)
            {
                throw new ArgumentException();
            }

            var rotateTransform = _spinnerImage.RenderTransform as RotateTransform;
            if (rotateTransform == null)
            {
                rotateTransform = new RotateTransform();
            }

            TimeSpan animationTime = TimeSpan.FromSeconds(SPINNING_TIME);
            double minAngle = 360 * MIN_ROUNDS;
            double maxAngle = 360 * MAX_ROUNDS;
            double multiplier = new Random().NextDouble();
            double toAngle = (multiplier * (maxAngle - minAngle)) + minAngle;

            var animation = new DoubleAnimation()
            {
                AccelerationRatio = 0.05,
                DecelerationRatio = 0.95,
                Duration = new Duration(animationTime),
                To = rotateTransform.Angle + toAngle
            };

            _spinnerImage.RenderTransform = rotateTransform;
            animation.Completed += (sender, e) => 
            {
                _spinnerImage.RenderTransform = new RotateTransform((double)animation.To % 360);
                int number = (int)Math.Round(((double)animation.To % 360) * Spinner.Numbers.Length / 360.0);
                resultLabel.Content = Spinner.Numbers[number % Spinner.Numbers.Length].Value;
                Spinner.Spin(Spinner.Numbers[number % Spinner.Numbers.Length]);
                callback.Invoke();
                IsSpinning = false;
            };
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
            IsSpinning = true;
        }

        #endregion PublicAPI
    }
}
