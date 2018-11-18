namespace NUnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Logic.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region IntBSTTest

        [Test]
        public void IntBinarySearchTreeDefaultComparerTest()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(13);

            var sb = new StringBuilder();
            foreach (var el in bst.PreorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("8 3 1 6 4 7 10 14 13 "));

            sb.Clear();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("1 3 4 6 7 8 10 13 14 "));

            sb.Clear();
            foreach (var el in bst.PostorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("1 4 7 6 3 13 14 10 8 "));
        }

        [Test]
        public void IntBinarySearchTreeGivenComparerTest()
        {
            var bst = new BinarySearchTree<int>(Comparer<int>.Create((x, y) => x - y));
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(13);

            var sb = new StringBuilder();
            foreach (var el in bst.PreorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("8 3 1 6 4 7 10 14 13 "));

            sb.Clear();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("1 3 4 6 7 8 10 13 14 "));

            sb.Clear();
            foreach (var el in bst.PostorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("1 4 7 6 3 13 14 10 8 "));
        }

        #endregion IntBSTTest

        #region StringBSTTest

        [Test]
        public void StringBinarySearchTreeDefaultComparerTest()
        {
            var bst = new BinarySearchTree<string>();
            bst.Insert("8");
            bst.Insert("3");
            bst.Insert("1");
            bst.Insert("6");
            bst.Insert("4");
            bst.Insert("7");
            bst.Insert("10");
            bst.Insert("14");
            bst.Insert("13");

            var sb = new StringBuilder();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("1 10 13 14 3 4 6 7 8 "));
        }

        [Test]
        public void StringBinarySearchTreeGivenComparerTest()
        {
            var bst = new BinarySearchTree<string>(Comparer<string>.Create((x, y) => int.Parse(x) - int.Parse(y)));
            bst.Insert("8");
            bst.Insert("3");
            bst.Insert("1");
            bst.Insert("6");
            bst.Insert("4");
            bst.Insert("7");
            bst.Insert("10");
            bst.Insert("14");
            bst.Insert("13");

            var sb = new StringBuilder();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append(el.ToString() + " ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("1 3 4 6 7 8 10 13 14 "));
        }

        #endregion StringBSTTest

        #region BookBSTTest

        [Test]
        public void BookBinarySearchTreeDefaultComparerTest()
        {
            var bst = new BinarySearchTree<Book>();
            bst.Insert(new Book("8", "1"));
            bst.Insert(new Book("3", "2"));
            bst.Insert(new Book("1", "3"));
            bst.Insert(new Book("6", "4"));
            bst.Insert(new Book("4", "5"));
            bst.Insert(new Book("7", "6"));
            bst.Insert(new Book("10", "7"));
            bst.Insert(new Book("14", "8"));
            bst.Insert(new Book("13", "9"));

            var sb = new StringBuilder();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append($"[{el.Author} {el.Title}] ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("[1 3] [10 7] [13 9] [14 8] [3 2] [4 5] [6 4] [7 6] [8 1] "));
        }

        [Test]
        public void BookBinarySearchTreeGivenComparerTest()
        {
            var bst = new BinarySearchTree<Book>(Comparer<Book>.Create((x, y) => x.Title.CompareTo(y.Title)));
            bst.Insert(new Book("8", "1"));
            bst.Insert(new Book("3", "2"));
            bst.Insert(new Book("1", "3"));
            bst.Insert(new Book("6", "4"));
            bst.Insert(new Book("4", "5"));
            bst.Insert(new Book("7", "6"));
            bst.Insert(new Book("10", "7"));
            bst.Insert(new Book("14", "8"));
            bst.Insert(new Book("13", "9"));

            var sb = new StringBuilder();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append($"[{el.Author} {el.Title}] ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("[8 1] [3 2] [1 3] [6 4] [4 5] [7 6] [10 7] [14 8] [13 9] "));
        }

        #endregion BookBSTTest

        #region PointBSTTest

        [Test]
        public void PointBinarySearchTreeGivenComparerTest()
        {
            var bst = new BinarySearchTree<Point>(Comparer<Point>.Create(
                (p1, p2) =>
                {
                    if (p1.X != p2.X)
                    {
                        return p1.X - p2.X;
                    }
                    else
                    {
                        return p1.Y - p2.Y;
                    }
                }));

            bst.Insert(new Point(8, 1));
            bst.Insert(new Point(3, 2));
            bst.Insert(new Point(1, 3));
            bst.Insert(new Point(6, 4));
            bst.Insert(new Point(4, 5));
            bst.Insert(new Point(7, 6));
            bst.Insert(new Point(10, 7));
            bst.Insert(new Point(14, 8));
            bst.Insert(new Point(13, 9));

            var sb = new StringBuilder();
            foreach (var el in bst.InorderTraversee())
            {
                sb.Append($"[{el.X} {el.Y}] ");
            }

            Assert.That(sb.ToString(), Is.EqualTo("[1 3] [3 2] [4 5] [6 4] [7 6] [8 1] [10 7] [13 9] [14 8] "));
        }

        #endregion PointBSTTest

        #region PrivateAPI

        private struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; private set; }

            public int Y { get; private set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append($"X = {X}, ");
                sb.Append($"Y = {Y}");
                return sb.ToString();
            }
        }

        private class Book : IComparable<Book>
        {
            public Book(string author, string title)
            {
                Author = author;
                Title = title;
            }

            public string Author { get; private set; }

            public string Title { get; private set; }

            public int CompareTo(Book other)
            {
                return Author.CompareTo(other.Author);
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append($"Author = {Author}, ");
                sb.Append($"Title = {Title}");
                return sb.ToString();
            }
        }

        #endregion PrivateAPI
    }
}
