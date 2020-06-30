/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author wynne
 */
namespace Tree.B
{
    public class Node<Index, T>
    {

        public Index Ind { get; set; }
        public T Obj { get; set; }
        public Node<Index, T> Dad { get; set; }
        public Node<Index, T> SonLeft { get; set; }
        public Node<Index, T> SonRight { get; set; }

        public Node(Index index, T obj, Node<Index, T> dad, Node<Index, T> sonLeft, Node<Index, T> sonRight)
        {
            this.Ind = index;
            this.Obj = obj;
            this.Dad = dad;
            this.SonLeft = sonLeft;
            this.SonRight = sonRight;
        }

        public Node(Index index, T obj)
        {
            this.Ind = index;
            this.Obj = obj;
        }

        public int CompareTo(Index index)
        {
            return this.Ind.ToString().CompareTo(index.ToString());
        }
    }
}