/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author wynne
 */
namespace Interface.IBase
{
    interface IBase<T>
    {

        public bool Add(T obj);
        public T Delete(int position);
        public T Delete(T obj);
        public T SearchFirst();
        public T SearchLast();
        public T Search(int position);
        public T Replace(T obj, int position);
        public int Size();
        public int Index(T obj);
        public bool ToClear();
        public T[] Group(int firstPosition, int lastPosition);
    }
}
