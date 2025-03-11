using System;

namespace src;

public class BinarySearchNode<T> : IComparable where T : IComparable 
{
    private T value;
    private BinarySearchNode<T> left;
    private BinarySearchNode<T> right;

    public BinarySearchNode(T value)
    {
        this.value = value;
    }

    public T Value
    {
        set { this.value = value; }
    }

    public BinarySearchNode<T> Left
    {
        set { this.left = value; }
        get { return this.left; }
    }
    public BinarySearchNode<T> Right
    {
        set { this.right = value; }
        get { return this.right; }
    }

}
