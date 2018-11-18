namespace NUnitTests
{
    using Logic.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void CreateClearTest()
        {
            var q1 = new Queue<int>();
            Assert.That(q1.Capacity, Is.EqualTo(Queue<int>.DEFAULT_CAPAITY));
            Assert.That(q1.GrowFactor, Is.EqualTo(Queue<int>.DEFAULT_GROW_FACTOR));

            var q2 = new Queue<int>(10);
            Assert.That(q2.Capacity, Is.EqualTo(10));
            Assert.That(q2.GrowFactor, Is.EqualTo(Queue<int>.DEFAULT_GROW_FACTOR));

            var q3 = new Queue<int>(10, 1.5);
            Assert.That(q3.Capacity, Is.EqualTo(10));
            Assert.That(q3.GrowFactor, Is.EqualTo(1.5));

            q1.Clear();
            Assert.That(q1.Count, Is.EqualTo(0));
            Assert.That(q1.Capacity, Is.EqualTo(Queue<int>.DEFAULT_CAPAITY));
        }

        [Test]
        public void EnqueueTrimTest()
        {
            var q = new Queue<int>();

            q.Enqueue(10);
            Assert.That(q.Capacity, Is.EqualTo(1));

            q.Enqueue(15);
            Assert.That(q.Capacity, Is.EqualTo(2));

            q.Enqueue(30);
            Assert.That(q.Capacity, Is.EqualTo(4));

            q.TrimToSize();
            Assert.That(q.Capacity, Is.EqualTo(3));
        }

        [Test]
        public void PeekDequeueTest()
        {
            var q = new Queue<int>();

            q.Enqueue(10);
            q.Enqueue(15);
            q.Enqueue(30);

            Assert.That(q.Peek(), Is.EqualTo(10));
            Assert.That(q.Dequeue(), Is.EqualTo(10));
            Assert.That(q.Dequeue(), Is.EqualTo(15));
            Assert.That(q.Dequeue(), Is.EqualTo(30));
        }

        [Test]
        public void ContainsToArrayTest()
        {
            var q = new Queue<int>();

            q.Enqueue(10);
            q.Enqueue(15);
            q.Enqueue(30);

            Assert.That(q.Contains(10), Is.True);
            Assert.That(q.Contains(100), Is.False);

            var intArray = new int[] { 10, 15, 30 };
            Assert.That(q.ToArray(), Is.EqualTo(intArray));
        }
    }
}
