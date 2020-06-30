/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using Interface.IBase;

/**
 *
 * @author wynne
 */
namespace Structure.Vector
{
    public class Vector<T> : IBase<T>
    {

        private T[] array;
        private int lastPosition = -1;
        private static readonly Vector<T> structe = new Vector<T>();

        public Vector() : this(10) { }

        public Vector(int length)
        {
            this.array = new T[length];
        }

        public static Vector<T> Instance()
        {
            return Vector<T>.structe;
        }

        public bool AddFirst(T obj)
        {
            return this.Add(obj, 0);
        }

        public bool AddLast(T obj)
        {
            return this.Add(obj);
        }

        public bool Add(T obj)
        {
            return this.Add(obj, this.lastPosition + 1);
        }

        public T DeleteFirst()
        {
            return this.Delete(0);
        }

        public T Delete(T obj)
        {
            return this.Delete(Index(obj));
        }

        public T DeleteLast()
        {
            return this.Delete(this.lastPosition);
        }

        public T Delete(int position)
        {

            if (!ValidPosition(position))
            {
                return default;
            }

            T item = this.array[position];
            this.GoToLeft(position);
            this.lastPosition--;

            return item;
        }

        public T SearchFirst()
        {
            return this.Search(0);
        }

        public T SearchLast()
        {
            return this.Search(this.lastPosition);
        }

        public T Search(int position)
        {

            if (!this.ValidPosition(position))
            {
                return default;
            }

            return this.array[position];
        }

        public T Replace(T obj, int position)
        {

            if (!this.ValidPosition(position) && obj != null)
            {
                return default;
            }

            T item = this.array[position];
            this.array[position] = obj;

            return item;
        }

        public int Size()
        {
            return this.lastPosition + 1;
        }

        public int Index(T obj)
        {
            for (int i = 0; i < this.lastPosition; i++)
            {
                if (obj.Equals(this.array[i]))
                {
                    return i;
                }
            }

            return -1;
        }


        public T[] Group(int firstPosition, int lastPosition)
        {
            T[] arrayReturn = null;

            if (this.ValidPosition(lastPosition) && this.ValidPosition(firstPosition) && lastPosition > firstPosition)
            {
                arrayReturn = new T[lastPosition - firstPosition];

                for (int i = 0, index = firstPosition; i < arrayReturn.Length; i++, index++)
                {
                    arrayReturn[i] = this.array[index];
                }
            }

            return arrayReturn;
        }

        public bool ToClear()
        {
            this.array = new T[10];
            this.lastPosition = -1;

            return true;
        }

        private bool Add(T obj, int position)
        {

            if (position < -1 || obj == null)
            {
                return false;
            }

            if (this.array.Length - 1 <= this.lastPosition)
            {
                this.IncreasesArray();
            }

            if (this.array[position] != null)
            {

                this.GoToRight(position);
            }

            this.array[position] = obj;

            this.lastPosition++;

            return true;
        }

        private void IncreasesArray()
        {
            T[] newArray = new T[2 * this.array.Length];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void GoToRight(int position)
        {
            for (int i = this.lastPosition; i >= position; i--)
            {
                this.array[i + 1] = this.array[i];
            }
        }

        private void GoToLeft(int position)
        {
            for (int i = position; i <= this.lastPosition; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private bool ValidPosition(int position)
        {
            return position >= 0 && position <= this.lastPosition;
        }

    }
}