namespace Logic.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        #region Fields

        // Queue container
        private T[] _container;

        #endregion Fields

        #region Constructors

        /// <summary>Create queue with default initial capacity and default grow factor</summary>
        public Queue() : this(DEFAULT_CAPAITY, DEFAULT_GROW_FACTOR)
        {
            // Calls overloaded constructor
        }

        /// <summary>Create queue with given initial capacity and default grow factor</summary>
        /// <param name="initialCapacity">Initial queue capacity</param>
        public Queue(int initialCapacity) : this(initialCapacity, DEFAULT_GROW_FACTOR)
        {
            // Calls overloaded constructor
        }

        /// <summary>Create queue with given initial capacity and given grow factor</summary>
        /// <param name="initialCapacity">Initial queue capacity</param>
        /// <param name="growFactor">Initial queue grow factor</param>
        public Queue(int initialCapacity, double growFactor)
        {
            if (initialCapacity < 0 || growFactor < 1.0 || growFactor > 10.0)
            {
                throw new ArgumentException();
            }

            Count = 0;
            Capacity = initialCapacity;
            GrowFactor = growFactor;
            _container = new T[initialCapacity];
        }

        #endregion Constructors

        #region Properties

        // Default queue capacity
        public static int DEFAULT_CAPAITY { get => 1; }

        // Default queue grow factor
        public static double DEFAULT_GROW_FACTOR { get => 1.0; }

        // Queue capacity
        public int Capacity { get; protected set; }

        // Queue grow factor
        public double GrowFactor { get; protected set; }

        // Queue elements count
        public int Count { get; protected set; }

        #endregion Properties

        #region PublicAPI

        /// <summary>Add element to queue</summary>
        /// <param name="element">Element to add</param>
        public void Enqueue(T element)
        {
            if (Count + 1 > Capacity)
            {
                Capacity += (int)Math.Round(Capacity * GrowFactor);
                var newContainer = new T[Capacity];
                _container.CopyTo(newContainer, 0);
                _container = newContainer;
            }

            _container[Count] = element;
            Count++;
        }

        /// <summary>Remove element from queue</summary>
        /// <returns>Removed element</returns>
        public T Dequeue()
        {
            if (Count > 0)
            {
                T result = _container[0];
                for (int i = 0; i < Count; i++)
                {
                    _container[i] = _container[i + 1];
                }

                Count--;
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>Take element without removing</summary>
        /// <returns>Taken element from queue</returns>
        public T Peek()
        {
            if (Count > 0)
            {
                return _container[0];
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>Check if element is in queue</summary>
        /// <param name="element">Element to check</param>
        /// <returns>State of element search result</returns>
        public bool Contains(T element)
        {
            foreach (T el in this)
            {
                if (el.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>Clear queue and set default capacity</summary>
        public void Clear()
        {
            _container = new T[DEFAULT_CAPAITY];
        }

        /// <summary>Removes empty elements</summary>
        public void TrimToSize()
        {
            _container = ToArray();
            Capacity = Count;
        }

        /// <summary>Get queue as array</summary>
        /// <returns>New array of queue</returns>
        public T[] ToArray()
        {
            var result = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _container[i];
            }

            return result;
        }

        /// <summary>Queue enumerator</summary>
        /// <returns>Queue enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator<T>(_container);
        }

        /// <summary>Queue explict enumerator</summary>
        /// <returns>Queue enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueIterator<T>(_container);
        }

        #endregion PublicAPI

        #region PrivateAPI

        private class QueueIterator<IT> : IEnumerator<IT>, IEnumerator
        {
            private IT[] _container;
            private int _currentIndex;

            public QueueIterator(IT[] container)
            {
                _container = container;
                _currentIndex = -1;
            }

            public IT Current => _container[_currentIndex];

            object IEnumerator.Current => _container[_currentIndex];

            public bool MoveNext()
            {
                if (_currentIndex + 1 < _container.Length)
                {
                    _currentIndex++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }

        #endregion PrivateAPI
    }
}
