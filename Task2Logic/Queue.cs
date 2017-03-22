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
            this.array[this.tail] = item;
            this.tail = (this.tail + 1) % this.array.Length;

            if (this.size == this.array.Length)
                this.head = (this.head + 1) % this.array.Length;
            else
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

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            if (this.array.Length == 0)
                yield break;

            if (this.tail > this.head)
                for (int i = this.head; i < this.tail; i++)
                    yield return this.array[i];
            else
                for (int i = this.head; i < this.array.Length; i++)
                    yield return this.array[i];
                for (int i = 0; i <= this.tail - 1; i++)
                    yield return this.array[i];
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        
    }
}
