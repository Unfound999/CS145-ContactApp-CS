using System;
using System.Collections;

namespace src;

//  Unsure how to translate implement IComparable class. It currently does not work (Check errors on Error List)
public class BinarySearchTree<T> : IComparable where T : IComparable 
{
    enum SearchType
    {
        PREORDER,
        INORDER,
        POSTORDER
    }

    private BinaryTreeNode<T> root;
}
