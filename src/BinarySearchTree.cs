/*
 * Authors: Christopher Waschke, Brody Weinkauf, Jackson Jenks
 * Assignment: Week 9 - Binary Search Trees
 * Description: Contact Application Using Binary Search Tree
 */

using System;
using System.Collections;

namespace src;

/*
 * NodeNotFoundException Class
 * Throws when a Node isn't found on the Binary Tree.
 */
public class NodeNotFoundException : Exception
{

}

/*
 * DuplicateNodeException Class
 * Throws when a Node already exists on the Binary Tree.
 */
public class DuplicateNodeException: Exception
{

}

/*
 * A Generic BinarySearchTree Class.
 * Type T must extend Comparable as to be used in the sorting of new nodes.
 */
public class BinarySearchTree<T> where T : IComparable 
{
    /*
     * Enum SearchType
     * Used to decide what type of traversal in the get method.
     */
    public enum SearchType
    {
        PREORDER,
        INORDER,
        POSTORDER,
        SEARCH
    }

    private BinaryTreeNode<T>? root; // The root Node of our Binary Tree.

    /*
    * Constructor Method
    * 
    * Creates a new BinarySearchTree, without an initial value for the root.
    */
    public BinarySearchTree()
    {
        this.root = null;
    }

    /*
     * Constructor Method
     * 
     * Constructs a new BinarySearchTree object with an initial value for the root.
     */
    public BinarySearchTree(T value)
    {
        this.root = new BinaryTreeNode<T>(value);
    }

    /* 
     * Void Method
     * If the tree was initialized without a value, it sets the root to the new Node with value T.
     * Otherwise this method uses the traditional binary search method to add a node to the tree.
     * We added weights to the values of the First and Last names in the Contact class, which are used here to decide where to find the node.
     * In a general since, this class, as it's generic, simply compares the two values till it find the right node to append our name to.
     */
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
                throw new DuplicateNodeException();
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

    /*
     * BinaryTreeNode<T> Method
     * We default to a Pre-Order search, as such this method calls getPreOrder() directly and just returns the result.
     * 
     * Parameters:
     * value (T) The value we're finding for.
     */
    public T Get(T value)
    {
        return this.GetPreOrder(value).Value;
    }

    /*
     * OverLoad of T get Method
     * This is just a switch case front-end to our internal different methods of traversal.
     * Parameters:
     *   value (T) The value we're finding for.
     *   searchType (SearchType Enum) The type of tree traversal desired to find the node.
     */
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
    /* BinaryTreeMethod<T> 
     * This method uses the traditional binary search method to find a node in the tree.
     * We added weights to the values of the First and Last names in the Contact class, which are used here to decide where to find the node.
     * In a general since, this class, as it's generic, simply compares the two values till it find the right node.
     * 
     * Parameters:
     *  value (T) The value we're finding for
    */
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

    /*
     * BinaryTreeNode<T> method
     * Traverses the Tree using the Pre-Order traversal style.
     * First, we create a stack to use as a processing order of nodes.
     * Unlike the other methods, we start by popping this node, to initially process the root.
     * If the node isn't the one we are looking for, we add the right child, if it exists, to the stack for processing.
     * We then add the left child to the tree for processing.
     * We loop this process until we have searched every node in the tree for the value we are looking for.
     * 
     * Parameters:
     *   value (T) The value we're finding for
     */
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

    /*
    * BinaryTreeNode<T> method
    * Traverses the Binary Tree using the In Order traversal pattern. (Left->Root->Right)
    * We dig through the nodes to the furthest left node. Adding each node to the stack as we go.
    * Once we're at the bottom, we process the left most node. Then we process the center. Finally, we change currNode to the right most node.
    * This will re-trigger our digging, if the node has left children, restarting the process.
    * We do this process until we found the node that we are looking for, which will be returned.
    * 
    * Parameters:
    *  value (T) The value we're finding for
    */
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

    /*
     * List<T> method. (ArrayList isn't recommended in C#, instead List<T> being used instead.)
     * This method is the exact same as the method above, except instead of looking for any single node,
     * We travel everyone adding each to a List to be returned later. Used for viewing every entry in the tree.
     */
    public List<T> GetAllInOrder()
    {
        Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();
        BinaryTreeNode<T> currNode = root;
        List<T> allValues = new List<T>();

        while (currNode != null || nodeStack.Count > 0)
        {

            // Dig through the Left branch, adding each left node to the stack for processing.
            while (currNode != null)
            {
                nodeStack.Push(currNode);
                currNode = currNode.Left;
            }

            currNode = nodeStack.Pop();
            allValues.Add(currNode.Value);

            // If this isn't the node we're looking for, check it's right sibling, if it's not null.
            // Checking reloops the digging process, meaning we're always doing left most first.
            currNode = currNode.Right;
        }
        return allValues;
    }

    /*
     * BinaryTreeNode<T> method
     * Traverses the tree using the Post Order traversal method.
     * We use two stacks to keep track the nodes that will be processed, once we leave finding the nodes
     * And the use a separate stack, to keep track of which nodes are parent nodes, to be able to process and find the nodes to left
     * After finding the nodes to the right. (Result in left->right->top when popped.)
     * 
     * Parameters:
     *  value (T): The value of the node we're looking for.
     */
    private BinaryTreeNode<T> GetPostOrder(T value)
    {
        Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();
        Stack<BinaryTreeNode<T>> parentStack = new Stack<BinaryTreeNode<T>>();
        BinaryTreeNode<T>? currNode = root;

        while (currNode != null || nodeStack.Count > 0)
        {
            while (currNode != null || parentStack.Count > 0)
            {
                if (!nodeStack.Contains(currNode))
                {
                    nodeStack.Push(currNode);
                }
                if (currNode.Right != null)
                {
                    currNode = currNode.Right;
                    continue;
                }
                if (parentStack.Count > 0)
                {
                    currNode = parentStack.Pop();
                    if (currNode.Left != null)
                    {
                        currNode = currNode.Left;
                    }
                    else if (currNode.Right != null)
                    {
                        currNode = currNode.Right;
                    }
                }
                else
                {
                    currNode = null;
                }
            }

            currNode = nodeStack.Pop();
            if (currNode.Value.Equals(value))
            {
                return currNode;
            }
            currNode = null;
        }
        throw new NodeNotFoundException();
    }

    /*
     * Boolean Method
     * Using the Search style, return if the desired value is in the tree.
     * 
     * Parameters:
     *  value (T): The value of the node we're looking for.
     */
    public Boolean Contains(T value)
    {
        try
        {
            this.GetSearch(value);
            return true;
        }
        catch (NodeNotFoundException _)
        {
            return false;
        }
    }

    /*
     * BinaryTreeNode<T> method.
     * Private Method.
     * Returns the node that is the parent of the value we're looking for. Used in removing.
     * Parameters:
     *  value (T): The value of the node we're looking for.
     */
    private BinaryTreeNode<T> GetParentNode(T value)
    {
        BinaryTreeNode<T>? parent = null;
        BinaryTreeNode<T> current = root;
        while (current != null)
        {
            int compareVal = current.Value.CompareTo(value);
            if (compareVal == 0)
            {
                return parent;
            }
            parent = current;
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

    /*
     * Void Method
     * Removes a tree from the Binary Tree node.
     * Shifts every the left branch into the current value, while removing the current value.
     * Parameters:
     * value (T): The value of the node we're looking for.
     */
    public void Remove(T value)
    {
        BinaryTreeNode<T> removeNode = this.GetPostOrder(value);
        if (removeNode.Left == null)
        {
            BinaryTreeNode<T> parent = this.GetParentNode(value);
            if(parent.Left == removeNode)
            {
                parent.Left = null;
            }
            if (parent.Right == removeNode)
            {
                parent.Right = null;
            }
            return;
        }

        while (removeNode != null)
        {
            BinaryTreeNode<T> leftNode = removeNode.Left;
            removeNode.Value = leftNode.Value;
            removeNode.Left = leftNode.Left;
            removeNode = removeNode.Left;
        }
    }
}
