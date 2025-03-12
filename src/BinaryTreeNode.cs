/*
 * Authors: Christopher Waschke, Brody Weinkauf, Jackson Jenks
 * Assignment: Week 9 - Binary Search Trees
 * Description: Contact Application Using Binary Search Tree
 */

using System;

namespace src;

/*
 * BinaryTreeNode<T> Class
 * A Generic Class representing a branch in a Binary Tree
 * Has three properties, the value of the node, and the two branches that come off of it.
 */
public class BinaryTreeNode<T> where T : IComparable  // Translation: BinarySearchNode, with generic type T that implements IComparable.
{
    // Our properties.
    private T value;
    private BinaryTreeNode<T>? left; // Note: C# is a slightly more modern language than Java, as such ? following a type means that it could be null.
    private BinaryTreeNode<T>? right;


    /*
     * Constructor Method
     * 
     * Creates a tree node with the given value value.
     * Parameters:
     *  value (T) the value of the node.
     */
    public BinaryTreeNode(T value)
    {
        this.value = value;
    }

    /*
     * Our Value Getter/Setters, done in C# styling.
     */
    public T Value
    {
        set { this.value = value; }
        get => this.value;
    }

    /*
     * Our Left Getter/Setter, done in C# styling.
     */
    public BinaryTreeNode<T> Left
    {
        set { this.left = value; }
        get { return this.left; } // This is okay to be null, as null means that we're a leaf, or at least a one way branch.
    }

    /*
     * Our Right Getter/Setter, done in C# styling.
     */
    public BinaryTreeNode<T> Right
    {
        set { this.right = value; }
        get { return this.right; } // This is okay to be null, as null means that we're a leaf, or at least a one way branch.
    }
}
