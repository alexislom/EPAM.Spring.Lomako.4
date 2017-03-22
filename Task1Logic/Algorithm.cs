using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    /// <summary>
    /// Class with sorting methods
    /// </summary>
    public static class Algorithm
    {
        #region Public methods
        /// <summary>
        /// Merge sort of array
        /// </summary>
        /// <param name="array">reference to array</param>
        public static void MergeSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            MergeSort(array, 0, array.Length - 1);
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Logic of merge sort
        /// </summary>
        /// <param name="array">ref to array</param>
        /// <param name="low">low border of array</param>
        /// <param name="high">high border of array</param>
        private static void MergeSort(int[] array, int low, int high)
        {
            if(low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        /// <summary>
        /// Intermediate method of merging 2 halves of an array
        /// </summary>
        /// <param name="array">ref to array</param>
        /// <param name="low">low border of array</param>
        /// <param name="middle">index of middle element of array</param>
        /// <param name="high">high border of array</param>
        private static void Merge(int[] array, int low, int middle, int high)
        {
            int[] helper = new int[array.Length];

            for(int i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }
                
            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;

            while(helperLeft <= middle && helperRight <= high)
            {
                if(helper[helperLeft] <= helper[helperRight])
                {
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    array[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            int remaining = middle - helperLeft;

            for(int i = 0; i <= remaining; i++)
            {
                array[current + i] = helper[helperLeft + i];
            }
        }

        #endregion
    }
}
