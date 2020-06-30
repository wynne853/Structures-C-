

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
    public class TreeGeneric<Index, T> : Tree<Index, T>
    {

        private GenericNode<Index, T> root;
        private int lenght = 0;
        private static TreeGeneric<Index, T> structure = new TreeGeneric<Index, T>();


        public static TreeGeneric<Index, T> instance()
        {
            return TreeGeneric<Index, T>.structure;
        }

        public bool Add(Index index, T obj, Index indexDad)
        {

            if (indexDad == null)
            {
                if (this.root != null)
                {
                    return false;
                }
                this.root = new GenericNode<Index, T>(index, obj, null);
                this.lenght++;

                return true;
            }

            GenericNode<Index, T> dad = this.FindElement(indexDad, this.root);
            GenericNode<Index, T> newNode = new GenericNode<Index, T>(index, obj, dad);
            if (dad != null && dad.Chieldren != null)
            {
                dad.Chieldren.Add(newNode);
            }
            this.lenght++;

            return true;
        }

        public T Delete(Index index)
        {
            GenericNode<Index, T> node = this.FindElement(index, this.root);

            if (node != null)
            {
                if (node.Dad == null)
                {
                    this.root = null;
                    this.lenght = 0;
                }
                else
                {
                    node.Dad = null;
                    if (node.Chieldren.Count == 0)
                    {
                        this.lenght--;
                    }
                    else
                    {
                        List<T> vector = new List<T>();
                        PreOrderSearch(node, vector);
                        this.lenght -= (vector.Count - 1);
                    }
                }
                return node.Obj;
            }

            return default(T);
        }

        public T Search(Index index)
        {
            GenericNode<Index, T> node = this.FindElement(index, this.root);

            if (node == null)
            {
                return default(T);
            }

            return node.Obj;
        }

        public int Size()
        {
            return this.lenght;
        }

        public bool IsEmpty()
        {
            if (this.lenght == 0)
            {
                return true;
            }
            return false;
        }

        public T Replace(Index index, T newObject)
        {
            GenericNode<Index, T> node = this.FindElement(index, this.root);
            T obj = default;
            if (node != null)
            {
                obj = node.Obj;
                node.Obj = newObject;
            }
            return obj;
        }

        public T Parent(Index index)
        {

            T obj = default;

            if (index != null && !this.IsRoot(index))
            {
                GenericNode<Index, T> element = this.FindElement(index, this.root);
                if (element != null)
                {
                    obj = element.Dad.Obj;
                }
            }

            return obj;
        }

        public List<T> Children(Index index)
        {

            if (index == null)
            {
                return null;
            }

            List<T> chieldren = new List<T>();

            List<GenericNode<Index, T>> nodeChieldren = FindElement(index, this.root).Chieldren;

            for (int i = 0; i < nodeChieldren.Count; i++)
            {
                chieldren.Add(nodeChieldren[i].Obj);
            }

            return chieldren;
        }

        public bool IsInternal(Index index)
        {

            if (index == null)
            {
                return false;
            }

            GenericNode<Index, T> element = FindElement(index, this.root);

            if (element == null)
            {
                return false;
            }

            return element.Chieldren.Count != 0;
        }

        public bool IsExternal(Index index)
        {
            if (index == null)
            {
                return false;
            }

            GenericNode<Index, T> element = FindElement(index, this.root);

            if (element == null)
            {
                return false;
            }

            return element.Chieldren.Count == 0;
        }

        public int HeightNode(Index index)
        {
            GenericNode<Index, T> node = FindElement(index, this.root);
            int heightNode = 0;

            while (node.Dad != null)
            {
                node = node.Dad;
                heightNode++;
            }

            return heightNode;
        }

        public bool IsRoot(Index index)
        {
            if (index == null || this.root == null)
            {
                return false;
            }

            return index.Equals(this.root.Ind);
        }

        public bool ToClear()
        {

            this.root = null;
            this.lenght = 0;

            return true;
        }

        public List<T> GoThrough(int type)
        {

            List<T> vector = null;

            if (this.lenght != 0 && type > 0 && type < 3)
            {

                vector = new List<T>();

                switch (type)
                {
                    case 1:
                        PreOrderSearch(this.root, vector);
                        break;
                    case 2:
                        PosOrderSearch(this.root, vector);
                        break;
                }

            }

            return vector;
        }

        private void PreOrderSearch(GenericNode<Index, T> node, List<T> vector)
        {

            vector.Add(node.Obj);

            if (node.Chieldren != null)
            {
                for (int i = 0; i < node.Chieldren.Count; i++)
                {
                    GenericNode<Index, T> aux = node.Chieldren[i];
                    PreOrderSearch(aux, vector);
                }
            }
        }

        private void PosOrderSearch(GenericNode<Index, T> node, List<T> vector)
        {

            if (node.Chieldren != null)
            {
                for (int i = 0; i < node.Chieldren.Count; i++)
                {
                    GenericNode<Index, T> aux = node.Chieldren[i];
                    PreOrderSearch(aux, vector);
                }
            }

            vector.Add(node.Obj);

        }

        private GenericNode<Index, T> FindElement(Index index, GenericNode<Index, T> node)
        {

            GenericNode<Index, T> element = null;

            if (node == null)
            {
                return null;
            }

            if (node.Ind.Equals(index))
            {
                return node;
            }

            if (node.Chieldren.Count != 0)
            {

                for (int i = 0; i < node.Chieldren.Count; i++)
                {

                    GenericNode<Index, T> aux = node.Chieldren[i];

                    element = FindElement(index, aux);

                    if (element != null)
                    {
                        return element;
                    }
                }
            }

            return element;
        }
    }
}

