namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private Random rand = new Random();
        

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int minIndex = 0;
            int maxIndex = this.items.Count - 1;
            int indexFound = 0;

            while (maxIndex >= minIndex)
            {
                int middleIndex = (minIndex + maxIndex) / 2;

                if (this.items[middleIndex].CompareTo(item) < 0)
                {
                    minIndex = middleIndex + 1;
                }
                else if (this.items[middleIndex].CompareTo(item) > 0)
                {
                    maxIndex = middleIndex - 1;
                }
                else if (this.items[middleIndex].CompareTo(item) == 0)
                {
                    indexFound = middleIndex;
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            for (var i = 0; i < items.Count; i++)
            {
                int r = i + rand.Next(0, items.Count - i);
                var temp = items[i];
                items[i] = items[r];
                items[r] = temp;
            }
        }


        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
