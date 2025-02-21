using UnityEngine;
using System.Collections.Generic;

public class ObjectStack
{
    public static Stack<GameObject> stack;

    public ObjectStack()
    {
        stack = new Stack<GameObject>();
    }

    public void Push(GameObject obj)
    {
        stack.Push(obj);
    }

    public GameObject Pop()
    {
        if (stack.Count > 0)
        {
            return stack.Pop();
        }
        return null;
    }

    public GameObject Peek()
    {
        if (stack.Count > 0)
        {
            return stack.Peek();
        }
        return null;
    }

    public int Count()
    {
        return stack.Count;
    }
}
