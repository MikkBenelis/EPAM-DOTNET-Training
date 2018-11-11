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
        
        private Image _spinnerImage;

        #endregion Fields

        #region Constructors

        /// <summary>Creates empty spinner object</summary>
        /// <returns>Created spinner object</returns>
        public SpinnerController()
        {
            Spinner = new Spinner();
            IsSpinning = false;
        }

        /// <summary>Creates spinner object with image</summary>
        /// <param name="spinnerImage">Image of spinner</param>
        /// <returns>Created spinner object</returns>
        public SpinnerController(Image spinnerImage) : this()
        {
            SetSpinnerImage(spinnerImage);
        }

        #endregion Constructors

        #region Properties

        public Spinner Spinner { get; private set; }

        public bool IsSpinning { get; private set; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Sets spinner image</summary>
        /// <param name="spinnerImage">Image of spinner</param>
        public void SetSpinnerImage(Image spinnerImage)
        {
            _spinnerImage = spinnerImage ?? throw new ArgumentException();
        }

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

            TimeSpan animationTime = TimeSpan.FromSeconds(5);
            int minAngle = (int)rotateTransform.Angle + 360;
            int maxAngle = (int)rotateTransform.Angle + 360 + (360 * 3);
            var animation = new DoubleAnimation()
            {
                AccelerationRatio = 0.05,
                DecelerationRatio = 0.95,
                Duration = new Duration(animationTime),
                To = new Random().Next(minAngle, maxAngle)
            };

            _spinnerImage.RenderTransform = rotateTransform;
            animation.Completed += (sender, e) => {
                int number = (int)Math.Round(((int)animation.To % 360) * Spinner.Numbers.Length / 360.0);
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
