namespace NUnitTests
{
    using System;
    using Logic.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void CreateSquareMatrixTest()
        {
            var sqM = new SquareMatrix<int>(3);
            Assert.That(
                () => sqM.SetElements(new int[,]
                {
                    { 1, 2, 3 },
                    { 1, 2, 3 },
                    { 1, 2, 3 }
                }),
                Throws.Nothing);

            Assert.That(
                () => sqM.SetElements(new int[,]
                {
                    { 1, 2, 3, 4, 5 },
                    { 1, 2, 3, 4, 5 },
                    { 1, 2, 3, 4, 5 }
                }),
                Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(
                () => sqM.SetElements(null), 
                Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CreateSymmetricMatrixTest()
        {
            var symM = new SymmetricMatrix<int>(3);

            Assert.That(
                () => symM.SetElements(new int[,]
                {
                    { 1, 2, 3 },
                    { 2, 3, 1 },
                    { 3, 1, 2 }
                }),
                Throws.Nothing);
            
            Assert.That(
                () => symM.SetElements(new int[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                }),
                Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CreateDiagonalMatrixTest()
        {
            var diagM = new DiagonalMatrix<int>(3);

            Assert.That(
                () => diagM.SetElements(new int[,]
                {
                    { 1, 0, 0 },
                    { 0, 2, 0 },
                    { 0, 0, 3 }
                }),
                Throws.Nothing);

            Assert.That(
                () => diagM.SetElements(new int[,]
                {
                    { 1, 0, 1 },
                    { 0, 2, 0 },
                    { 1, 0, 3 }
                }),
                Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(
                () => diagM.SetElements(new int[] { 1, 2, 3 }),
                Throws.Nothing);

            Assert.That(
                () => diagM.SetElements(new int[] { 1, 2, 3, 4, 5 }),
                Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void MatrixSumTest()
        {
            var symM = new SymmetricMatrix<int>(3);
            symM.SetElements(new int[,]
            {
                { 1, 2, 3 },
                { 2, 3, 1 },
                { 3, 1, 2 }
            });
                
            var diagM = new DiagonalMatrix<int>(3);
            diagM.SetElements(new int[,]
            {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 }
            });

            var correctSum = new SquareMatrix<int>(3);
            correctSum.SetElements(new int[,]
            {
                { 2, 2, 3 },
                { 2, 5, 1 },
                { 3, 1, 5 }
            });

            var incorrectSum = new SquareMatrix<int>(3);
            incorrectSum.SetElements(new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            });

            var result = symM.AddMatrix(diagM, delegate(int a, int b) { return a + b; });
            Assert.That(result, Is.EqualTo(correctSum));
            Assert.That(result, Is.Not.EqualTo(incorrectSum));
        }
    }
}
