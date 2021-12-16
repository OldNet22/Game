using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.LimitedList
{
    public class LimitedList<T> : IEnumerable<T>
    {
        private int capacity;
        protected List<T> list;

        public bool IsFull => capacity <= Count;
        public int Count => list.Count;
        public T this[int index] => list[index];

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 1);
            list = new List<T>(this.capacity);
        }

        public virtual bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item);
            //if(item is null)
            //{
            //    throw new ArgumentNullException(nameof(item));
            //}
            if (IsFull)
            {
                return false;
            }

            list.Add(item);
            return true;
        }

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                //....
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
