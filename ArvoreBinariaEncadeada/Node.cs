/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ArvoreBinariaEncadeada;

import java.util.Objects;

/**
 *
 * @author wynne
 * @param <Index> deve ser comparavel
 * @param <E> pode ser qualquer objeto
 */
public class Node<Index extends Comparable,E> {
    
    private Index index;
    private E item;
    private Node<Index,E> father;
    private Node<Index,E> childrenRight;
    private Node<Index,E>  childrenLeft;

    public Index getIndex() {
        return index;
    }

    public void setIndex(Index index) {
        this.index = index;
    }

    public E getItem() {
        return item;
    }

    public void setItem(E item) {
        this.item = item;
    }

    public Node<Index, E> getFather() {
        return father;
    }

    public void setFather(Node<Index, E> father) {
        this.father = father;
    }

    public Node<Index, E> getChildrenRight() {
        return childrenRight;
    }

    public void setChildrenRight(Node<Index, E> childrenRight) {
        this.childrenRight = childrenRight;
    }

    public Node<Index, E> getChildrenLeft() {
        return childrenLeft;
    }

    public void setChildrenLeft(Node<Index, E> childrenLeft) {
        this.childrenLeft = childrenLeft;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Node<?, ?> other = (Node<?, ?>) obj;
        if (!Objects.equals(this.index, other.index)) {
            return false;
        }
        if (!Objects.equals(this.item, other.item)) {
            return false;
        }
        return true;
    }
    
}
