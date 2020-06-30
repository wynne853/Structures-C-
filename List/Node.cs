/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author wynne
 */
namespace Structure.LinkedList
{
    public class Node<T>
    {
        public T Obj { get; set; }
        public Node<T> NodeRight { get; set; }
        public Node<T> NodeLeft { get; set; }

        public Node(T obj, Node<T> nodeRight, Node<T> nodeLeft)
        {
            this.Obj = obj;
            this.NodeRight = nodeRight;
            this.NodeLeft = nodeLeft;
        }
    }
}