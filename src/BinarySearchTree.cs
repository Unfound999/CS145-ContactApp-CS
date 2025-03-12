using System;
using System.Collections;

namespace src;

public class NodeNotFoundException : Exception
{

}

public class BinarySearchTree<T> where T : IComparable 
{
    public enum SearchType
    {
        PREORDER,
        INORDER,
        POSTORDER,
        SEARCH
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

    public void Add(T newData)
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

    public T Get(T value)
    {
        return this.GetPreOrder(value).Value;
    }

    public T Get(T value, SearchType searchType)
    {
        switch (searchType)
        {
            case SearchType.PREORDER:
                return this.GetPreOrder(value).Value;
            case SearchType.INORDER:
                return this.GetInOrder(value).Value;
            case SearchType.POSTORDER:
                return this.GetPostOrder(value).Value;
            case SearchType.SEARCH:
                return this.GetSearch(value).Value;
            default:
                return this.GetInOrder(value).Value; // This really shouldn't ever happen, but worst case, we'll fall onto an InOrder search.
        }
    }

    private BinaryTreeNode<T> GetSearch(T value)
    {
        BinaryTreeNode<T> current = root;
        while (current != null)
        {
            int compareVal = current.Value.CompareTo(value);
            if (compareVal == 0)
            {
                return current;
            }
            if (compareVal > 0)
            {
                current = current.Left;
            }
            if (compareVal < 0)
            {
                current = current.Right;
            }
        }
        throw new NodeNotFoundException();
    }

    private BinaryTreeNode<T> GetPreOrder(T value)
    {
    }

    private BinaryTreeNode<T> GetInOrder(T value)
    {
    }

    private BinaryTreeNode<T> GetPostOrder(T value)
    {

    }

}
