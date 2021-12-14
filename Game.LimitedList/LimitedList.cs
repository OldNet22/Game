using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.LimitedList
{
    public class LimitedList<T>
    {
        private int capacity;
        private List<T> list;

        public bool IsFull => capacity <= Count;
        public int Count => list.Count;
        public T this[int index] => list[index];

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 1);
            list = new List<T>(this.capacity);
        }

        public bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, "item");

            if (IsFull)
            {
                return false;
            }

            list.Add(item);
            return true;
        }


    }
}
