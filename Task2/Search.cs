using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Provides methods of binary search for array
    /// </summary>
    public static class Search
    {
        #region Public members
        /// <summary>
        /// Searches the array for a specified element using specified comparison feature
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="array">Array for searching</param>
        /// <param name="item">Element to locate</param>
        /// <param name="comparison">Contains rule of comparing</param>
        /// <returns>Index of item in sorted array or -1 if it's not found</returns>
        public static int BinarySearch<T>(this T[] array, T item, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
            return BinarySearch(array, item, 0, array.Length, comparison);
        }

        /// <summary>
        /// Searches the array for a specified element using specified comparer
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="array">Array for searching</param>
        /// <param name="item">Element to locate</param>
        /// <param name="comparer">Object that contains rule of comparing</param>
        /// <returns>Index of item in sorted array or -1 if it's not found</returns>
        public static int BinarySearch<T>(this T[] array, T item, IComparer<T> comparer)
        {
            Array.Sort(array, comparer);
            return BinarySearch(array, item, 0, array.Length, comparer.Compare);
        }

        /// <summary>
        /// Searches the array for a specified element using type default comparison feature
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="array">Array for searching</param>
        /// <param name="item">Element to locate</param>
        /// <returns>Index of item in sorted array or -1 if it's not found</returns>
        public static int BinarySearch<T>(this T[] array, T item)
        {
            Array.Sort(array, Comparer<T>.Default);
            return BinarySearch(array, item, 0, array.Length, Comparer<T>.Default.Compare);
        }
        #endregion

        #region Private member
        /// <summary>
        /// Searches the array for a specified element using specified comparison feature
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="array">Array for searching</param>
        /// <param name="item">Element to locate</param>
        /// <param name="left">Left border of seatch</param>
        /// <param name="right">Right border of search</param>
        /// <param name="comparison">Contains a rule of comparing</param>
        /// <returns>Index of item in sorted array or -1 if it's not found</returns>
        private static int BinarySearch<T>(T[] array, T item, int left, int right, Comparison<T> comparison)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array is blank");
            if (item == null)
                throw new ArgumentNullException("Array is null referenced");

            int mid = left + (right - left) / 2; ;
            if (left >= right)
                return -1;

            if (comparison(array[mid], item) == 0) 
                return mid;

            else if (comparison(array[mid], item) > 0)
                return BinarySearch(array, item, left, mid, comparison);
            else
                return BinarySearch(array, item, mid + 1, right, comparison);
        }
        #endregion
    }
}
