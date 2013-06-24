namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        static void QuickSort(IList<T> collection, int left, int right)
        {
            int leftHold = left;
            int rightHold = right;
            Random objRan = new Random();
            int pivot = objRan.Next(left, right);
            QuickSwap(collection, pivot, left);
            pivot = left;
            left++;

            while (right >= left)
            {
                int compareLeftVal = collection[left].CompareTo(collection[pivot]);
                int compareRightVal = collection[right].CompareTo(collection[pivot]);

                if ((compareLeftVal >= 0) && (compareRightVal < 0))
                {
                    QuickSwap(collection, left, right);
                }
                else
                {
                    if (compareLeftVal >= 0)
                    {
                        right--;
                    }
                    else
                    {
                        if (compareRightVal < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                            left++;
                        }
                    }
                }
            }

            QuickSwap(collection, pivot, right);

            pivot = right;
            if (pivot > leftHold)
            {
                QuickSort(collection, leftHold, pivot);
            }
            if (rightHold > pivot + 1)
            {
                QuickSort(collection, pivot + 1, rightHold);
            }
        }

        static void QuickSwap(IList<T> collection, int left, int right)
        {
            T swap = collection[right];
            collection[right] = collection[left];
            collection[left] = swap;
        }
    }
}
