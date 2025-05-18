using System.Collections.Generic;
using UnityEngine;

public class L9_DragDropManager : MonoBehaviour
{
    private bool isDraggingValid = true;
    public bool IsDraggingValid
    {
        get { return isDraggingValid; }
        set { isDraggingValid = value; }
    }


    [SerializeField]
    private int level = 0;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    private List<List<GameObject>> relationsQueue = new List<List<GameObject>>();
    public List<List<GameObject>> RelationsQueue
    {
        get { return relationsQueue; }
        set { relationsQueue = value; }
    }


    // Elements 1:
    private GameObject UI_Cart;
    private GameObject UI_Timeolite;
    private GameObject UI_Enlarger;
    private GameObject UI_Enlarger_Cart_Timeolite;
    private GameObject UI_Enlarger_Cart;
    private GameObject UI_RedLens;

    // Elements 2:
    private GameObject UI_Cart_2;
    private GameObject UI_Fixer;
    private GameObject UI_Developer;
    private GameObject UI_Faucet;
    private GameObject UI_Stop;
    private GameObject UI_HangingRope;


    // Flags:
    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private bool flag4 = true;
    private bool flag5 = true;



    void Start()
    {
        UI_Cart = FindInActiveObjectByName("UI_Cart_1");
        UI_Timeolite = FindInActiveObjectByName("UI_Timeolite");
        UI_Enlarger = FindInActiveObjectByName("UI_Enlarger");
        UI_Enlarger_Cart_Timeolite = FindInActiveObjectByName("UI_Enlarger-Cart-Timeolite");
        UI_Enlarger_Cart = FindInActiveObjectByName("UI_Enlarger-Cart");
        UI_RedLens = FindInActiveObjectByName("UI_RedLens");

        UI_Cart_2 = FindInActiveObjectByName("UI_Cart");
        UI_Fixer = FindInActiveObjectByName("UI_Fixer");
        UI_Developer = FindInActiveObjectByName("UI_Developer");
        UI_Faucet = FindInActiveObjectByName("UI_Faucet");
        UI_Stop = FindInActiveObjectByName("UI_Stop");
        UI_HangingRope = FindInActiveObjectByName("UI_HangingRope");


        relationsQueue.Add(new List<GameObject> { UI_Cart.transform.GetChild(0).gameObject, UI_Enlarger });
        relationsQueue.Add(new List<GameObject> { UI_RedLens.transform.GetChild(0).gameObject, UI_Enlarger_Cart });
        relationsQueue.Add(new List<GameObject> { UI_Timeolite.transform.GetChild(0).gameObject, UI_Enlarger_Cart });

        GameObject image;
        if (PlayerPrefs.GetString("SelectedImage") == "image2")
        {
            image = UI_Cart_2.transform.GetChild(1).gameObject;
        }
        else if (PlayerPrefs.GetString("SelectedImage") == "image3")
        {
            image = UI_Cart_2.transform.GetChild(2).gameObject;
        }
        else
        {
            image = UI_Cart_2.transform.GetChild(0).gameObject;
        }
        relationsQueue.Add(new List<GameObject> { image, UI_Developer });
    }

    // Update is called once per frame
    void Update()
    {
        switch(level) {
            case 1:
                UI_Cart.SetActive(false);
                UI_Enlarger.SetActive(false);
                UI_Enlarger_Cart.SetActive(true);
                break;
            
            case 2:
                UI_RedLens.SetActive(false);
                break;
            
            case 3:
                UI_Enlarger_Cart.SetActive(false);
                UI_Timeolite.SetActive(false);
                UI_Enlarger_Cart_Timeolite.SetActive(true);
                break;
            
            case 4:
                UI_Cart_2.SetActive(false);
                UI_Developer.transform.GetChild(0).gameObject.SetActive(false);
                if (flag1)
                {
                    relationsQueue.Add(new List<GameObject> { UI_Developer.transform.GetChild(1).gameObject, UI_Stop });
                    flag1 = false;
                }

                break;

            case 5:
                UI_Developer.SetActive(false);
                UI_Stop.transform.GetChild(0).gameObject.SetActive(false);
                if (flag2)
                {
                    relationsQueue.Add(new List<GameObject> { UI_Stop.transform.GetChild(1).gameObject, UI_Fixer });
                    flag2 = false;
                }
                break;

            case 6:
                UI_Stop.SetActive(false);
                UI_Fixer.transform.GetChild(0).gameObject.SetActive(false);
                if (flag3)
                {
                    relationsQueue.Add(new List<GameObject> { UI_Fixer.transform.GetChild(1).gameObject, UI_Faucet });
                    flag3 = false;
                }
                break;

            case 7:
                UI_Fixer.SetActive(false);
                UI_Faucet.transform.GetChild(0).gameObject.SetActive(false);

                if (flag4)
                {
                    relationsQueue.Add(new List<GameObject> { UI_Faucet.transform.GetChild(1).gameObject, UI_HangingRope });
                    flag4 = false;
                }
                
                break;

            case 8:
                UI_Faucet.SetActive(false);
                UI_HangingRope.transform.GetChild(0).gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }


    public GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
