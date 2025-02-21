using UnityEngine;
using System.Collections.Generic;

public class UndoRedoController : MonoBehaviour
{
    public static Stack<GameObject> stack = new Stack<GameObject>();
    public static Stack<GameObject> undoStack = new Stack<GameObject>();


    private GameObject undoBtn;
    private GameObject redoBtn;

    private void Start()
    {
        undoBtn = GameObject.Find("UndoBtn");
        redoBtn = GameObject.Find("RedoBtn");
    }
    
    
    public void UndoBtn()
    {
        if (stack.Count > 0)
        {
            GameObject obj = stack.Pop();
            obj.SetActive(false);
            undoStack.Push(obj);
        }
    }

    public void RedoBtn()
    {
        if (undoStack.Count > 0)
        {
            GameObject obj = undoStack.Pop();
            obj.SetActive(true);
            stack.Push(obj);
        }
    }
}
