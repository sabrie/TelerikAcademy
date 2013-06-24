namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int i;
            int j;
            int min;

            for (i = 0; i < collection.Count; i++)
            {
                min = i;

                for (j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)   // collection[j] < collection[min]
                    {
                        min = j;
                    }
                }

                T exchangeValues = collection[i];
                collection[i] = collection[min];
                collection[min] = exchangeValues;
            }
        }
    }
}
