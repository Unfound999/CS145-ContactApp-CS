using System;

namespace src;


public class BinaryTreeNode<T> where T : IComparable  // Translation: BinarySearchNode, with generic type T that implements IComparable.
{
    private T value;
    private BinaryTreeNode<T>? left; // Note: C# is a slightly more modern language than Java, as such ? following a type means that it could be null.
    private BinaryTreeNode<T>? right;

    public BinaryTreeNode(T value)
    {
        this.value = value;
    }

    public T Value
    {
        set { this.value = value; }
    }

    public BinaryTreeNode<T> Left
    {
        set { this.left = value; }
        get { return this.left; } // This is okay to be null, as null means that we're a leaf, or at least a one way branch.
    }
    public BinaryTreeNode<T> Right
    {
        set { this.right = value; }
        get { return this.right; } // This is okay to be null, as null means that we're a leaf, or at least a one way branch.
    }
}
