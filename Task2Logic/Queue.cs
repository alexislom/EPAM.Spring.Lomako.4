using System;
using System.Collections;
using System.Collections.Generic;


namespace Task2Logic
{
    /// <summary>
    /// Cyclic generic queue
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        #region Fields

        private static T[] emptyArray = new T[0];
        private T[] array;
        private int head;
        private int tail;
        private int size;

        #endregion

        #region Properties

        public int Count => this.size;
        
        #endregion

        #region Constructors

        public Queue()
        {
            this.array = Queue<T>.emptyArray;
        }

        public Queue(int capacity) 
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity");
            this.array = new T[capacity];
            this.head = 0;
            this.tail = 0;
            this.size = 0;
        }

        #endregion

        #region Methods

        public void Enqueue(T item)
        {
            if (this.size == this.array.Length)
            {
                int capacity = (int)((long)this.array.Length * 200L / 100L);
                if (capacity < this.array.Length + 4)
                    capacity = this.array.Length + 4;
                this.SetCapacity(capacity);
            }
            this.array[this.tail] = item;
            this.tail = (this.tail + 1) % this.array.Length;
            this.size = this.size + 1;
        }

        public T Dequeue()
        {
            if (this.size == 0)
                throw new InvalidOperationException("Queue is empty");

            T obj = this.array[this.head];
            this.array[this.head] = default(T);
            this.head = (this.head + 1) % this.array.Length;
            this.size = this.size - 1;
            return obj;
        }

        public T Peek()
        {
            if (this.size == 0)
                throw new InvalidOperationException("Queue is empty");

            return this.array[this.head];
        }

        #endregion

        #region IEnumerable<T> members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)new Queue<T>.Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)new Queue<T>.Enumerator(this);
        }

        #endregion

        #region Private methods

        private T GetElement(int i)
        {
            return this.array[(this.head + i) % this.array.Length];
        }

        private void SetCapacity(int capacity)
        {
            T[] objArray = new T[capacity];
            if (this.size > 0)
            {
                if (this.head < this.tail)
                {
                    Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.size);
                }
                else
                {
                    Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.array.Length - this.head);
                    Array.Copy((Array)this.array, 0, (Array)objArray, this.array.Length - this.head, this.tail);
                }
            }
            this.array = objArray;
            this.head = 0;
            this.tail = this.size == capacity ? 0 : this.size;
        }

        #endregion

        /// <summary>
        /// Enumerator for queue 
        /// </summary>
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private Queue<T> q;
            private int index;
            private T currentElement;

            internal Enumerator(Queue<T> q)
            {
                this.q = q;
                this.index = -1;
                this.currentElement = default(T);
            }

            public T Current
            {
                get
                {
                    if (this.index < 0)
                    {
                        if (this.index == -1)
                            throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
                        else
                            throw new InvalidOperationException("InvalidOperation_EnumNotEnded");
                    }
                    return this.currentElement;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (this.index < 0)
                    {
                        if (this.index == -1)
                            throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
                        else
                            throw new InvalidOperationException("InvalidOperation_EnumNotEnded");
                    }
                    return (object)this.currentElement;
                }
            }

            public bool MoveNext()
            {
                if (this.index == -2)
                    return false;
                this.index = this.index + 1;
                if (this.index == this.q.size)
                {
                    this.index = -2;
                    this.currentElement = default(T);
                    return false;
                }
                this.currentElement = this.q.GetElement(this.index);
                return true;
            }
            
            void IEnumerator.Reset()
            {
                this.index = -1;
                this.currentElement = default(T);
            }

            public void Dispose()
            {
                this.index = -2;
                this.currentElement = default(T);
            }
        }
    }
}
