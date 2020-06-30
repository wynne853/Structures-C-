/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


using System.Collections;
using System.Collections.Generic;
/**
*
* @author wynne
*/
namespace Tree.B
{
    public class TreeB<Index, T> : Tree<Index, T> {

    private Node<Index, T> root;
    private int lenght = 0;
    private static TreeB<Index, T> structure = new TreeB<Index, T>();

    public static TreeB<Index, T> instance() {
        return TreeB<Index, T>.structure;
    }

    public bool Add(Index index, T obj) {

        if (index == null || obj == null) {
            return false;
        }

        Node<Index, T> newNode = new Node<Index, T>(index, obj);

        if (this.root == null) {
            this.root = newNode;
            this.lenght++;

            return true;
        }

        Node<Index, T> aux = this.root;

        for (int i = 0; i < this.lenght; i++) {

            int compare = aux.CompareTo(index);
            
            if (compare < 0) {
                if (aux.SonRight == null) {

                    aux.SonRight = newNode;
                    newNode.Dad = aux;

                    this.lenght++;

                    return true;
                } else {
                    aux = aux.SonRight;
                }
            } else if (compare >= 0) {
                if (aux.SonLeft == null) {

                    aux.SonLeft = newNode;
                    newNode.Dad = aux;
                    this.lenght++;

                    return true;
                } else {
                    aux = aux.SonLeft;
                }
            }
        }

        return false;
    }

    public T Delete(Index index) {

        Node<Index, T> node = FindElement(index, this.root);

        if (node != null) {
            
            if (node.SonLeft != null && node.SonRight != null) {
            
                Node<Index, T> aux = this.FindTheLeftMost(node.SonRight);
                
                if (aux.SonRight != null) {
                    aux.Dad.SonLeft = aux.SonRight;
                    aux.SonRight.Dad = aux.Dad;
                } else {
                    aux.Dad.SonLeft = null;
                }
                
                aux.Dad = node.Dad;
                
                if(node.Dad != null){          
                    if (node.Dad.SonLeft.Ind.Equals(node.Ind)) {
                        node.Dad.SonLeft = aux;
                    } else {
                        node.Dad.SonRight = aux;
                    }
                }
                aux.SonLeft = node.SonLeft;
                aux.SonRight = node.SonRight;

                node.SonLeft.Dad = aux;
                node.SonRight.Dad = aux;
                
            } else if (node.SonLeft == null && node.SonRight == null) {
                if(node.Dad == null){
                    this.root = null;
                    
                    return node.Obj;
                }
                if (node.Dad.SonLeft.Ind.Equals(node.Ind)) {
                    node.Dad.SonLeft = null;
                } else {
                    node.Dad.SonRight = null;
                }
                
            } else {
                
                Node<Index, T> aux;
                
                if (node.SonLeft != null) {
                    aux = node.SonLeft;
                } else {
                    aux = node.SonRight;
                }
                
                aux.Dad = node.Dad;
                
                if(node.Dad != null){
                    if (node.Dad.SonLeft.Ind.Equals(node.Ind)) {
                        node.Dad.SonLeft = aux;
                    } else {
                        node.Dad.SonRight = aux;
                    }
                }
            }

            node.Dad = null;
            node.SonLeft = null;
            node.SonRight = null;

            this.lenght--;

            return node.Obj;
        }

        return default(T);
    }

    public T Search(Index index) {
        
        Node<Index, T> node = this.FindElement(index, this.root);
        if(node == null){
            return default(T);
        }
        
        return node.Obj;
    }

    public int Size() {
        return this.lenght;
    }

    public bool IsEmpty() {
        return this.lenght == 0;
    }

    public T Replace(Index index, T newObj) {

        Node<Index, T> node = this.FindElement(index, this.root);
            T obj = default(T);
            if (node != null) {
                obj = node.Obj;
                node.Obj = newObj;
            }

        return obj;
    }

    public T Parent(Index index) {
        Node<Index,T> node = FindElement(index, this.root);
        if(node == null || node.Dad == null){
            return default(T);
        }
        
        return node.Dad.Obj;
    }

    public List<T> Children(Index index) {

        List<T> children = new List<T>();
        Node<Index, T> node = this.FindElement(index, this.root);

        if (node != null) {
            
            if (node.SonLeft != null) {
                children.Add(node.SonLeft.Obj);
            }
            if (node.SonRight != null) {
                children.Add(node.SonRight.Obj);
            }
        }
        
        return children;
    }

    public bool IsInternal(Index index) {
        Node<Index, T> node = FindElement(index, this.root);

        return node != null && (node.SonLeft != null || node.SonRight != null);
    }

    public bool IsExternal(Index index) {
        Node<Index, T> node = FindElement(index, this.root);

        return node != null && node.SonLeft == null && node.SonRight == null;
    }

    public int HeightNode(Index index) {
        Node<Index, T> node = FindElement(index, this.root);
        int heightNode = 0;

        while (node.Dad != null) {
            node = node.Dad;
            heightNode++;
        }

        return heightNode;
    }

    public bool IsRoot(Index index) {
        return index.Equals(this.root.Ind);
    }
    
    public List<T> goThrough(int type) {

            List<T> vector = new List<T>();
        
        if (this.lenght != 0 && type > 0 && type < 4) {
                        
            switch (type) {
                case 1:
                    this.PreOrderSearch(this.root,vector);
                    break;
                case 2:
                    this.PosOrderSearch(this.root,vector);
                    break;
                case 3:
                    this.InOrderSearch(this.root,vector);
                    break;
            }

        }
        
        return vector;
    }
    
    private void PreOrderSearch(Node<Index, T> node, List<T> vector) {

        vector.Add(node.Obj);

        if (node.SonLeft != null) {
            this.PreOrderSearch(node.SonLeft,vector);
        }

        if (node.SonRight != null) {
            this.PreOrderSearch(node.SonRight,vector);
        }

    }

    private void PosOrderSearch(Node<Index, T> node, List<T> vector) {

        if (node.SonLeft != null) {
            this.PosOrderSearch(node.SonLeft,vector);
        }

        if (node.SonRight != null) {
            this.PosOrderSearch(node.SonRight,vector);
        }

        vector.Add(node.Obj);

    }

    private void InOrderSearch(Node<Index, T> node, List<T> vector) {

        if (node.SonLeft != null) {
            this.InOrderSearch(node.SonLeft,vector);
        }

        vector.Add(node.Obj);

        if (node.SonRight != null) {
            this.InOrderSearch(node.SonRight,vector);
        }

    }

    private Node<Index, T> FindElement(Index index, Node<Index, T> node) {

        Node<Index, T> element = null;

        if (node.Ind.Equals(index)) {
            return node;
        }

        if (node.SonLeft != null) {
            element = FindElement(index, node.SonLeft);
            if (element != null) {
                return element;
            }
        }

        if (node.SonRight != null) {
            element = FindElement(index, node.SonRight);
        }

        return element;
    }

    private Node<Index, T> FindTheLeftMost(Node<Index, T> node) {

        if (node.SonLeft != null) {
            return FindTheLeftMost(node.SonLeft);
        } else {
            return node;
        }
    }

    public bool ToClear() {
        
        this.lenght = 0;
        this.root = null;
        
        return true;
    }

}
}