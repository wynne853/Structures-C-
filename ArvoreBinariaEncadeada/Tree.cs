/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ArvoreBinariaEncadeada;

import java.util.ArrayList;

/**
 *
 * @author wynne
 */
public class Tree<Index extends Comparable,E> {

    private Node<Index,E> root = new Node<Index, E>();
    private ArrayList<E> listReturn = new ArrayList<>();
    
    public boolean add(Index index,E item){
        boolean condition = true;
        Node<Index,E> aux = this.root;
        
        Node<Index,E> newNode = new Node<>();
        newNode.setIndex(index);
        newNode.setItem(item);
        
        while(condition){
            if(aux.getIndex().compareTo(index) == 0){
                aux = newNode;
                return true;
            }
            if(aux.getIndex().compareTo(index) == 1){
                if(aux.getChildrenRight() != null){
                    aux = aux.getChildrenRight();
                }else{
                    aux.setChildrenRight(newNode);
                    return true;
                }
            }
            if(aux.getIndex().compareTo(index) == -1){
                if(aux.getChildrenLeft() != null){
                    aux = aux.getChildrenLeft();
                }else{
                    aux.setChildrenLeft(newNode);
                    return true;
                }
            }
            
        }
        return true;
    }
    
    public Node<Index,E> search(Index indexSearch){    
        return this.searchNode(this.root, indexSearch);
    }
    
    private Node<Index,E> searchNode(Node<Index,E> node,Index index){
        
        Node<Index,E> aux = this.root;
        
        boolean condition = true;
        while(condition){
            if(aux.getIndex().compareTo(index) == 0){
                return aux;
            }
            if(aux.getIndex().compareTo(index) == 1){
                if(aux.getChildrenRight() != null){
                    aux = aux.getChildrenRight();
                }else{
                    return null;
                }
                
            }
            if(aux.getIndex().compareTo(index) == -1){
                if(aux.getChildrenLeft() != null){
                    aux = aux.getChildrenLeft();
                }else{
                    return null;
                }
            }
            
        }
        return null;
    
    }
       
     /**
     * 
     * @param mode pode assumir 1 :pre-ordem , 2: pos- ordem , 3: em ordem
     * @return um array com todos os elementos na ordem pedida
     */
    public ArrayList<E> sweep(int mode){
        
        this.listReturn.clear();
        
        switch(mode){
            case 1:this.sweep_Pre(this.root);
                break;
            case 2:this.sweep_Pos(this.root);
                break;
            case 3:this.sweep_Em(this.root);
                break;
        }
        
        return this.listReturn;
    }
    
    private Node<Index,E> sweep_Pre(Node<Index,E> node){
        
        this.listReturn.add(node.getItem());
        
        if(node.getChildrenLeft()!= null){
            Node<Index,E> auxNode = sweep_Pre(node.getChildrenLeft());
        }
        if(node.getChildrenRight()!= null){
            Node<Index,E> auxNode = sweep_Pre(node.getChildrenRight());
        }
        
        return null;

    }
    private Node<Index,E> sweep_Pos(Node<Index,E> node){
        if(node.getChildrenLeft()!= null){
            Node<Index,E> auxNode = sweep_Pos(node.getChildrenLeft());
        }
        if(node.getChildrenRight()!= null){
            Node<Index,E> auxNode = sweep_Pos(node.getChildrenRight());
        }
        
        this.listReturn.add(node.getItem());
        
        return null;
    }
    private Node<Index,E> sweep_Em(Node<Index,E> node){
               
        if(node.getChildrenLeft()!= null){
            Node<Index,E> auxNode = sweep_Em(node.getChildrenLeft());
        }
        
        this.listReturn.add(node.getItem());
        
        if(node.getChildrenRight()!= null){
            Node<Index,E> auxNode = sweep_Em(node.getChildrenRight());
        }  
        
        return null;
    }
    
    public int levelNode(Index index){
        int level = sweepNode(index);
        return level;
    }
    
    public Node<Index,E> toRemove(Index indexToRemove){
       
        Node<Index,E> node = this.searchNode(this.root, indexToRemove);
        
        if(node.getChildrenLeft() == null && node.getChildrenRight() == null){
            if(node.getFather().getChildrenLeft().equals(node)){
                node.getFather().setChildrenLeft(null);
            }else{
                node.getFather().setChildrenRight(null);
            }
            node.setFather(null);
        }else if(node.getChildrenLeft() == null){
            node.getChildrenRight().setFather(node.getFather());
            if(node.getFather().getChildrenLeft().equals(node)){
                node.getFather().setChildrenLeft(node.getChildrenRight());
            }else{
                node.getFather().setChildrenRight(node.getChildrenRight());
            }
            node.setFather(null);
            node.setChildrenRight(null);
        }else if(node.getChildrenRight() == null){
            node.getChildrenLeft().setFather(node.getFather());
            if(node.getFather().getChildrenLeft().equals(node)){
                node.getFather().setChildrenLeft(node.getChildrenLeft());
            }else{
                node.getFather().setChildrenRight(node.getChildrenLeft());
            }
            node.setFather(null);
            node.setChildrenLeft(null);        
        }else{
           Node<Index, E> aux = remove2Chieldren(node.getChildrenRight());
           if(aux.getChildrenRight()!= null){
               aux.getFather().setChildrenLeft(aux.getChildrenRight());
           }else{
               aux.getFather().setChildrenLeft(null);
           }
           
           aux.setFather(node.getFather());
           aux.setChildrenLeft(node.getChildrenLeft());
           aux.setChildrenRight(node.getChildrenRight());
           
           node.setChildrenLeft(null);
           node.setChildrenRight(null);
           node.setFather(null);
        }
        return node;
    }

    private Node<Index, E> remove2Chieldren(Node<Index, E> node) {
        if(node.getChildrenLeft() == null){
            return node;
        }
        
        return remove2Chieldren(node.getChildrenLeft());
    }

    private int sweepNode(Index index) {
        
        Node<Index,E> aux = this.root;
        
        boolean condition = true;
        int contador = -1;
        while(condition){
            
            contador++;
            
            if(aux.getIndex().compareTo(index) == 0){
                return contador;
            }
            if(aux.getIndex().compareTo(index) == 1){
                if(aux.getChildrenRight() != null){
                    aux = aux.getChildrenRight();
                    continue;
                }else{
                    return -1;
                }
                
            }
            if(aux.getIndex().compareTo(index) == -1){
                if(aux.getChildrenLeft() != null){
                    aux = aux.getChildrenLeft();
                }else{
                    return -1;
                }
            }

        }
        return contador;
    }
}
