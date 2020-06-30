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
namespace Structure.LinkedList
{
    public class LinkedList<T> : IBase<T>
    {

        private static LinkedList<T> structe = new LinkedList<T>();

        private Node<T> first = null;
        private Node<T> last = null;
        private int lenght = 0;


        public static LinkedList<T> Instance()
        {
            return LinkedList<T>.structe;
        }

        public bool AddFirst(T obj)
        {

            Node<T> newNode = new Node<T>(obj, this.first, null);

            if (this.first == null)
            {
                this.first = newNode;
                this.last = newNode;
            }

            this.first.NodeLeft = newNode;
            this.first = newNode;
            this.lenght++;

            return true;
        }

        public bool AddLast(T obj)
        {
            return this.Add(obj);
        }

        public bool Add(T obj)
        {
            Node<T> newNode = new Node<T>(obj, null, this.last);

            if (this.first == null)
            {
                this.first = newNode;
                this.last = newNode;
            }

            this.last.NodeRight = newNode;
            this.last = newNode;

            this.lenght++;

            return true;
        }

        public T DeleteFirst()
        {

            Node<T> node = this.first;

            if (this.first.NodeRight != null)
            {
                this.first = this.first.NodeRight;
                this.first.NodeLeft = null;
                node.NodeRight = null;
            }
            else
            {
                this.first = null;
            }

            this.lenght--;

            return node.Obj;
        }

        public T DeleteLast()
        {
            Node<T> node = this.last;

            if (this.last.NodeLeft != null)
            {
                this.last = this.last.NodeLeft;
                this.last.NodeRight = null;
                node.NodeRight = null;
            }
            else
            {
                this.last = null;
                this.first = null;
            }
            this.lenght--;

            return node.Obj;
        }

        public T Delete(int position)
        {

            if (ValidPosition(position))
            {
                if (position == 0)
                {
                    return this.DeleteFirst();
                }

                if (position == this.lenght - 1)
                {
                    return this.DeleteLast();
                }

                Node<T> aux = this.Find(position);
                if (aux != null)
                {
                    if (aux.NodeLeft != null)
                    {
                        aux.NodeLeft.NodeRight = aux.NodeRight;
                    }
                    if (aux.NodeRight != null)
                    {
                        aux.NodeRight.NodeLeft = aux.NodeLeft;
                    }
                    aux.NodeLeft = null;
                    aux.NodeRight = null;

                    this.lenght--;

                    return aux.Obj;
                }
            }
            return default(T);
        }

        public T Delete(T obj)
        {
            return this.Delete(Index(obj));
        }

        public T SearchFirst()
        {
            return this.first.Obj;
        }

        public T SearchLast()
        {
            return this.last.Obj;
        }

        public T Search(int position)
        {
            T item = default(T);
            if (this.ValidPosition(position))
            {
                Node<T> node = this.Find(position);

                if (node == null)
                {
                    return default(T);
                }
                item = node.Obj;
            }
            return item;
        }

        public T Replace(T obj, int position)
        {
            T item = default(T);

            if (this.ValidPosition(position))
            {
                Node<T> aux = this.Find(position);
                item = aux.Obj;
                aux.Obj = obj;
            }

            return item;
        }

        public int Size()
        {
            return this.lenght;
        }

        public int Index(T obj)
        {
            Node<T> aux = this.first;

            for (int i = 0; i < this.lenght; i++)
            {
                if (obj.Equals(aux.Obj))
                {
                    return i;
                }
                else
                {
                    aux = aux.NodeRight;
                }
            }

            return -1;
        }

        public bool ToClear()
        {
            this.first = null;
            this.last = null;
            this.lenght = 0;

            return true;
        }

        public T[] Group(int firstPosition, int lastPosition)
        {
            T[] array = null;

            if (this.ValidPosition(lastPosition) && this.ValidPosition(firstPosition) && lastPosition > firstPosition)
            {
                array = new T[(lastPosition - firstPosition)];
                Node<T> aux = this.Find(firstPosition);
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = aux.Obj;
                    aux = aux.NodeRight;
                }
            }

            return array;
        }

        private Node<T> Find(int position)
        {

            Node<T> aux;

            if (position > this.lenght || position < 0)
            {
                return null;
            }

            if ((this.lenght / 2) >= position)
            {
                aux = this.first;
                for (int i = 0; i < position; i++)
                {
                    aux = aux.NodeRight;
                }
            }
            else
            {
                aux = this.last;
                for (int i = this.lenght - 1; i > position; i--)
                {
                    aux = aux.NodeLeft;
                }
            }

            return aux;
        }

        private bool ValidPosition(int position)
        {
            return position >= 0 && position <= this.lenght;
        }
    }
}