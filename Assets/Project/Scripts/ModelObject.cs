using UnityEngine;

public class ModelObject
{
    private string name;
    private GameObject prefab;
    private Texture sprite;
    private int order;

    public ModelObject(string name, GameObject prefab, Texture sprite, int order)
    {
        this.name = name;
        this.prefab = prefab;
        this.sprite = sprite;
        this.order = order;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

    public Texture Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    public int Order
    {
        get { return order; }
        set { order = value; }
    }
}
