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
        Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();
        nodeStack.Push(root);

        // C# lacks the stack.empty() method of Java, as such, we'll just do a count > 0.
        while (nodeStack.Count > 0)
        {
            BinaryTreeNode<T> currNode = nodeStack.Pop();
            if (currNode != null)
            {
                if (currNode.Value.Equals(value))
                {
                    return currNode;
                }
                if (currNode.Right != null)
                {
                    nodeStack.Push(currNode.Right);
                }
                if (currNode.Left != null)
                {
                    nodeStack.Push(currNode.Left);
                }
            }
        }

        throw new NodeNotFoundException();

    }

    private BinaryTreeNode<T> GetInOrder(T value)
    {
        Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();
        BinaryTreeNode<T> currNode = root;

        while (currNode != null || nodeStack.Count > 0) 
        {
            
            // Dig through the Left branch, adding each left node to the stack for processing.
            while (currNode != null)
            {
                nodeStack.Push(currNode);
                currNode = currNode.Right;
            }

            currNode = nodeStack.Pop();
            if (currNode.Value.Equals(value))
            {
                return currNode;
            }

            // If this isn't the node we're looking for, check it's right sibling, if it's not null.
            // Checking reloops the digging process, meaning we're always doing left most first.
            if(currNode.Right != null)
            {
                currNode = currNode.Right;
            }
        }
        throw new NodeNotFoundException();
    }

    private BinaryTreeNode<T> GetPostOrder(T value)
    {

    }

}
