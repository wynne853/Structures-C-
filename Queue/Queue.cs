/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
using Interface.IBaseEspecialist;
using Structure.LinkedList;
/**
 *
 * @author wynne
 */
namespace Structure.Stack
{
    public class Queue<T> : IBaseEspecialist<T>
    {

        private LinkedList<T> list = LinkedList<T>.Instance();
        private static Queue<T> structe = new Queue<T>();

        public static Queue<T> Instance()
        {
            return Queue<T>.structe;
        }

        public bool Add(T obj)
        {
            return this.list.AddFirst(obj);
        }

        public T Delete()
        {
            return this.list.DeleteFirst();
        }

        public T SearchFirst()
        {
            return this.list.SearchFirst();
        }

        public T SearchLast()
        {
            return this.list.SearchLast();
        }

        public T Search(int position)
        {
            return this.list.Search(position);
        }

        public int Size()
        {
            return this.list.Size();
        }

        public int Index(T obj)
        {
            return this.list.Index(obj);
        }

        public bool ToClear()
        {
            return this.list.ToClear();
        }

    }
}