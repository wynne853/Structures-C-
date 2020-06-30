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
namespace Interface
{
    public interface Tree<Index, T>
    {

        //remover elemento
        public T Delete(Index index);
        //pegar elemento

        public T Search(Index index);
        // Retorna a quantidade de nós da árvore

        public int Size();
        //retorna se a árvore está vazia

        public bool IsEmpty();
        // Substitui o elemento armazenado em determinado nó

        public T Replace(Index index, T newObject);
        // retorna o pai de um nó

        public T Parent(Index index);
        //retorna o nivel da arvore

        public List<T> Children(Index index);
        // retorna verdadeiro se o nó é interno

        public bool IsInternal(Index index);
        // retorna verdadeiro se o nó é externo

        public bool IsExternal(Index index);
        //altura do elemento na arvore 

        public int HeightNode(Index index);
        // retorna verdadeiro se o nó é raiz

        public bool IsRoot(Index index);
        //limpar estrutura

        public bool ToClear();
        //percorrer a arvore

        public List<T> GoThrough(int type);
    }
}