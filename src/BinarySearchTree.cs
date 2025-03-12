using System;
using System.Collections;

namespace src;

//  Unsure how to translate implement IComparable class. It currently does not work (Check errors on Error List)
public class BinarySearchTree<T> where T : IComparable 
{
    enum SearchType
    {
        PREORDER,
        INORDER,
        POSTORDER
    }

    private BinaryTreeNode<T>? root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    public BinarySearchTree(T value)
    {
        this.root = new BinaryTreeNode<T>(value);
    }

    public void add(T newData)
    {
        if (root == null)
        {
            this.root = new BinaryTreeNode<T>(newData);
            return;
        }
        BinaryTreeNode<T> currNode = root;
        while (currNode != null)
        {
            if (currNode.Value.Equals(newData))
            {
                throw new Exception();
            }
            if (currNode.Value.CompareTo(newData) > 0)
            {
                if (currNode.Left == null)
                {
                    currNode.Left = new BinaryTreeNode<T>(newData);
                    break;
                }
                currNode = currNode.Left;
            }
            if((currNode.Value.CompareTo(newData) < 0))
            {
                if (currNode.Right == null)
                {
                    currNode.Right = new BinaryTreeNode<T>(newData);
                    break;
                }
                currNode = currNode.Right;
            }
        }
    }
}
