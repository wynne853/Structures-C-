/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


using System.Collections.Generic;
/**
*
* @author wynne
*/
namespace Tree.Generic
{
    class GenericNode<Index, T>
    {

        public Index Ind { get; set; }
        public T Obj { get; set; }
        public GenericNode<Index, T> Dad { get; set; }
        public List<GenericNode<Index, T>> Chieldren { get; set; }

        public GenericNode(Index index, T obj, GenericNode<Index, T> dad)
        {
            this.Ind = index;
            this.Obj = obj;
            this.Dad = dad;
            this.Chieldren = new List<GenericNode<Index, T>>();

        }


    }
}