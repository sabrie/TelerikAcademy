namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int left = 0;
            int right = collection.Count - 1;
            InternalMergeSort(collection, left, right);
        }

        private void InternalMergeSort(IList<T> collection, int left, int right)
        {
            int mid = 0;
            if (left < right)
            {
                mid = (left + right) / 2;
                InternalMergeSort(collection, left, mid);
                InternalMergeSort(collection, (mid + 1), right);
                MergeSortedArray(collection, left, mid, right);
            }
        }

        private void MergeSortedArray(IList<T> collection, int left, int mid, int right)
        {
            int total_elements = right - left + 1; //BODMAS rule
            int right_start = mid + 1;
            int temp_location = left;
            IList<T> tempArray = new List<T>(total_elements);

            while ((left <= mid) && right_start <= right)
            {
                if (collection[left].CompareTo(collection[right_start]) <= 0)
                {
                    tempArray.Add(collection[left++]);
                }
                else
                {
                    tempArray.Add(collection[right_start++]);
                }
            }
            if (left > mid)
            {
                for (int j = right_start; j <= right; j++)
                    tempArray.Add(collection[right_start++]);
            }
            else
            {
                for (int j = left; j <= mid; j++)
                    tempArray.Add(collection[left++]);
            }

            for (int i = 0, j = temp_location; i < total_elements; i++, j++)
            {
                collection[j] = tempArray[i];
            }
        }
    }
}
