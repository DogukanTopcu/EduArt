using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class Level9ui : MonoBehaviour
{
    private L9_DragDropManager ddm;
    private string selectedImage = "image1"; // Default value
    private string selectedPosometerTime = "3"; // Default value

    // Objects:
    private GameObject cart;
    private GameObject marjor;
    private GameObject dark;
    private GameObject FinalPanel;
    private GameObject paperClip;

    // Experiments:
    private GameObject Experiment1;
    private GameObject Experiment2;
    private GameObject Experiment2_Cart;


    // Materials
    public Material image_11;
    public Material image_12;
    public Material image_13;
    public Material image_21;
    public Material image_22;
    public Material image_23;
    public Material image_31;
    public Material image_32;
    public Material image_33;

    public Material image1_red;
    public Material image2_red;
    public Material image3_red;

    // Textures:
    private Dictionary<string, Texture2D> image1Textures = new Dictionary<string, Texture2D>();
    private Dictionary<string, Texture2D> image2Textures = new Dictionary<string, Texture2D>();
    private Dictionary<string, Texture2D> image3Textures = new Dictionary<string, Texture2D>();

    public Texture2D image1;
    public Texture2D image2;
    public Texture2D image3;
    public Texture2D image4;
    public Texture2D image5;
    public Texture2D image6;
    public Texture2D image7;
    public Texture2D image8;
    public Texture2D image9;

    // Flags
    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private bool flag4 = true;
    private bool flag5 = true;
    private bool flag6 = true;
    private bool flag7 = true;
    private bool flag8 = true;


    // Clues:
    private GameObject clue1;
    private GameObject clue2;
    private GameObject clue3;
    private GameObject clue4;
    private GameObject clue5;
    private GameObject clue6;
    private GameObject clue7;
    private GameObject clue8;
    private GameObject clue9;
    private GameObject clue10;
    private GameObject clue11;
    private GameObject clue12;

    // Positions:
    private GameObject V_MarjorPoint;
    private GameObject H_MarjorPoint;
    private GameObject V_CartMidPoint;
    private GameObject H_CartMidPoint;
    private GameObject V_CartMarjorPoint;
    private GameObject H_CartMarjorPoint;

    private GameObject developerMidPoint;
    private GameObject developerCartPoint;
    private GameObject stopMidPoint;
    private GameObject stopCartPoint;
    private GameObject fixerMidPoint;
    private GameObject fixerCartPoint;
    private GameObject faucetMidPoint;
    private GameObject faucetCartPoint;

    private GameObject cartRopePoint;
    private GameObject defaultClipPoint;
    private GameObject ropeClipPoint;
    private GameObject H_CartFinal;
    private GameObject V_CartFinal;
    

    private Dictionary<string, Dictionary<string, Material>> imageDictionary = new Dictionary<string, Dictionary<string, Material>>();

    void Awake()
    {
        ddm = GameObject.Find("DragDropManager").GetComponent<L9_DragDropManager>();

        selectedImage = PlayerPrefs.GetString("SelectedImage") == "" ? "image1" : PlayerPrefs.GetString("SelectedImage");
        selectedPosometerTime = PlayerPrefs.GetString("selectedPosometerTime") == "" ? "3" : PlayerPrefs.GetString("selectedPosometerTime");

        imageDictionary.Add("image1", new Dictionary<string, Material>()
        {
            { "3", image_11 },
            { "5", image_12 },
            { "7", image_13 }
        });
        imageDictionary.Add("image2", new Dictionary<string, Material>()
        {
            { "3", image_21 },
            { "5", image_22 },
            { "7", image_23 }
        });
        imageDictionary.Add("image3", new Dictionary<string, Material>()
        {
            { "3", image_31 },
            { "5", image_32 },
            { "7", image_33 }
        });

        image1Textures.Add("3", image1);
        image1Textures.Add("5", image2);
        image1Textures.Add("7", image3);

        image2Textures.Add("3", image4);
        image2Textures.Add("5", image5);
        image2Textures.Add("7", image6);

        image3Textures.Add("3", image7);
        image3Textures.Add("5", image8);
        image3Textures.Add("7", image9);

        // Experiments:
        Experiment1 = FindInActiveObjectByName("Experiment");
        Experiment2 = FindInActiveObjectByName("Experiment2");
        Experiment2_Cart = FindInActiveObjectByName("UI_Cart");

        // Objects:
        cart = FindInActiveObjectByName("cart");
        marjor = FindInActiveObjectByName("Marjor");
        dark = FindInActiveObjectByName("Dark");
        FinalPanel = FindInActiveObjectByName("FinalPanel");
        paperClip = FindInActiveObjectByName("paper_clip");
        

        // Clues:
        clue1 = FindInActiveObjectByName("Clue1");
        clue2 = FindInActiveObjectByName("Clue2");
        clue3 = FindInActiveObjectByName("Clue3");
        clue4 = FindInActiveObjectByName("Clue4");
        clue5 = FindInActiveObjectByName("Clue5");
        
        clue6 = FindInActiveObjectByName("Clue6");
        clue7 = FindInActiveObjectByName("Clue7");
        clue8 = FindInActiveObjectByName("Clue8");
        clue9 = FindInActiveObjectByName("Clue9");
        clue10 = FindInActiveObjectByName("Clue10");
        clue11 = FindInActiveObjectByName("Clue11");
        clue12 = FindInActiveObjectByName("Clue12");


        // Points:
        V_MarjorPoint = FindInActiveObjectByName("V_MarjorPoint");
        H_MarjorPoint = FindInActiveObjectByName("H_MarjorPoint");
        V_CartMidPoint = FindInActiveObjectByName("V_CartMidPoint");
        H_CartMidPoint = FindInActiveObjectByName("H_CartMidPoint");
        V_CartMarjorPoint = FindInActiveObjectByName("V_CartMarjorPoint");
        H_CartMarjorPoint = FindInActiveObjectByName("H_CartMarjorPoint");

        developerMidPoint = FindInActiveObjectByName("developerMidPoint");
        developerCartPoint = FindInActiveObjectByName("developerCartPoint");
        stopMidPoint = FindInActiveObjectByName("stopMidPoint");
        stopCartPoint = FindInActiveObjectByName("stopCartPoint");
        fixerMidPoint = FindInActiveObjectByName("fixerMidPoint");
        fixerCartPoint = FindInActiveObjectByName("fixerCartPoint");
        faucetMidPoint = FindInActiveObjectByName("faucetMidPoint");
        faucetCartPoint = FindInActiveObjectByName("faucetCartPoint");

        cartRopePoint = FindInActiveObjectByName("cartRopePoint");
        defaultClipPoint = FindInActiveObjectByName("defaultClipPoint");
        ropeClipPoint = FindInActiveObjectByName("ropeClipPoint");
        H_CartFinal = FindInActiveObjectByName("H_CartFinal");
        V_CartFinal = FindInActiveObjectByName("V_CartFinal");
    }

    void Start()
    {
        if (selectedImage == "image2")
        {
            Experiment2_Cart.transform.GetChild(0).gameObject.SetActive(false);
            Experiment2_Cart.transform.GetChild(1).gameObject.SetActive(true);
            Experiment2_Cart.transform.GetChild(2).gameObject.SetActive(false);

            FinalPanel.transform.GetChild(0).gameObject.SetActive(false);
            FinalPanel.transform.GetChild(1).gameObject.SetActive(true);
            FinalPanel.transform.GetChild(1).gameObject.GetComponent<RawImage>().texture = image2Textures[selectedPosometerTime];

            marjor.GetComponent<Transform>().position = H_MarjorPoint.transform.position;
            marjor.GetComponent<Transform>().rotation = H_MarjorPoint.transform.rotation;
        }
        else {

            FinalPanel.transform.GetChild(0).gameObject.SetActive(true);
            FinalPanel.transform.GetChild(1).gameObject.SetActive(false);

            if (selectedImage == "image1")
            {
                Experiment2_Cart.transform.GetChild(0).gameObject.SetActive(true);
                Experiment2_Cart.transform.GetChild(1).gameObject.SetActive(false);
                Experiment2_Cart.transform.GetChild(2).gameObject.SetActive(false);

                FinalPanel.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = image1Textures[selectedPosometerTime];
            }
            else {
                Experiment2_Cart.transform.GetChild(0).gameObject.SetActive(false);
                Experiment2_Cart.transform.GetChild(1).gameObject.SetActive(false);
                Experiment2_Cart.transform.GetChild(2).gameObject.SetActive(true);

                FinalPanel.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = image3Textures[selectedPosometerTime];
            }
        }

        clue1.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            clue1.SetActive(false);
            dark.SetActive(true);
            clue2.SetActive(true);
            Experiment1.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (ddm.Level == 1 && flag1) {
            ddm.IsDraggingValid = false;
            flag1 = false;
            clue2.SetActive(false);

            StartCoroutine(PlaceCart());
        }
        if (ddm.Level == 2 && flag2) {
            ddm.IsDraggingValid = false;
            flag2 = false;
            clue3.SetActive(false);

            StartCoroutine(PlaceRedFilter());
        }
        if (ddm.Level == 3 && flag3) {
            ddm.IsDraggingValid = false;
            flag3 = false;
            clue4.SetActive(false);
            Experiment1.SetActive(false);

            cart.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials = new Material[0];
            cart.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().materials = new Material[0];

            clue5.SetActive(true);
            clue5.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                clue5.SetActive(false);
                StartCoroutine(StartEnlarger());
                
            });

            ddm.IsDraggingValid = true;
        }

        if (ddm.Level == 4 && flag4) {
            ddm.IsDraggingValid = false;
            flag4 = false;
            clue6.SetActive(false);

            StartCoroutine(ToDeveloper());
        }
        if (ddm.Level == 5 && flag5) {
            ddm.IsDraggingValid = false;
            flag5 = false;
            clue7.SetActive(false);

            StartCoroutine(ToStop());
        }
        if (ddm.Level == 6 && flag6) {
            ddm.IsDraggingValid = false;
            flag6 = false;
            clue8.SetActive(false);

            StartCoroutine(ToFixer());
        }
        if (ddm.Level == 7 && flag7)
        {
            ddm.IsDraggingValid = false;
            flag7 = false;
            clue9.SetActive(false);

            StartCoroutine(ToFaucet());
        }
        if (ddm.Level == 8 && flag8)
        {
            ddm.IsDraggingValid = false;
            flag8 = false;
            clue10.SetActive(false);

            StartCoroutine(ToRope());
        }
    }



    // Enumerators:
    private IEnumerator PlaceCart()
    {
        cart.transform.DOKill();
        if (selectedImage == "image2")
        {
            cart.transform.DOMove(H_CartMidPoint.transform.position, 1f)
            .OnComplete(() =>
            {
                cart.transform.DORotate(H_CartMidPoint.transform.rotation.eulerAngles, 0.25f)
                .OnComplete(() =>
                {
                    cart.transform.DOMove(H_CartMarjorPoint.transform.position, 1f);
                });
            });
        }
        else {
            cart.transform.DOMove(V_CartMidPoint.transform.position, 1f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(V_CartMarjorPoint.transform.position, 1f);
            });
        }

        yield return new WaitForSeconds(3f);
        
        clue3.SetActive(true);
        ddm.IsDraggingValid = true;
    }


    private IEnumerator PlaceRedFilter() {
        yield return new WaitForSeconds(1f);

        if (selectedImage == "image1")
        {
            cart.transform.GetChild(0).gameObject.SetActive(true);
            cart.transform.GetChild(1).gameObject.SetActive(false);

            cart.transform.GetChild(0).gameObject.GetComponent<Renderer>().AddMaterial(image1_red);
        }
        else if (selectedImage == "image2") {
            cart.transform.GetChild(1).gameObject.SetActive(true);
            cart.transform.GetChild(0).gameObject.SetActive(false);

            cart.transform.GetChild(1).gameObject.GetComponent<Renderer>().AddMaterial(image2_red);
        }
        else {
            cart.transform.GetChild(0).gameObject.SetActive(true);
            cart.transform.GetChild(1).gameObject.SetActive(false);

            cart.transform.GetChild(0).gameObject.GetComponent<Renderer>().AddMaterial(image3_red);
        }

        yield return new WaitForSeconds(3f);
        clue4.SetActive(true);
        ddm.IsDraggingValid = true;
    }


    private IEnumerator StartEnlarger() {
        yield return new WaitForSeconds(2f);

        if (selectedImage == "image2")
        {
            cart.transform.GetChild(1).gameObject.SetActive(true);
            cart.transform.GetChild(0).gameObject.SetActive(false);

            cart.transform.GetChild(1).gameObject.GetComponent<Renderer>().AddMaterial(imageDictionary[selectedImage][selectedPosometerTime]);
        }
        else {
            cart.transform.GetChild(1).gameObject.SetActive(false);
            cart.transform.GetChild(0).gameObject.SetActive(true);

            cart.transform.GetChild(0).gameObject.GetComponent<Renderer>().AddMaterial(imageDictionary[selectedImage][selectedPosometerTime]);
        }
        
        yield return new WaitForSeconds(1f);
        clue6.SetActive(true);
        Experiment2.SetActive(true);
    }


    private IEnumerator ToDeveloper() {
        cart.transform.DOKill();
        cart.transform.DOMove(developerMidPoint.transform.position, 1f)
        .OnComplete(() =>
        {
            cart.transform.DORotate(developerMidPoint.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(developerCartPoint.transform.position, 1f);
            });
        });

        yield return new WaitForSeconds(6f);
        clue7.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    private IEnumerator ToStop()
    {
        cart.transform.DOKill();
        cart.transform.DOMove(stopMidPoint.transform.position, 1f)
        .OnComplete(() =>
        {
            cart.transform.DORotate(stopMidPoint.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(stopCartPoint.transform.position, 1f);
            });
        });

        yield return new WaitForSeconds(6f);
        clue8.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    private IEnumerator ToFixer() {
        cart.transform.DOKill();
        cart.transform.DOMove(fixerMidPoint.transform.position, 1f)
        .OnComplete(() =>
        {
            cart.transform.DORotate(fixerMidPoint.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(fixerCartPoint.transform.position, 1f);
            });
        });

        yield return new WaitForSeconds(6f);
        clue9.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    private IEnumerator ToFaucet() {
        cart.transform.DOKill();
        cart.transform.DOMove(faucetMidPoint.transform.position, 1f)
        .OnComplete(() =>
        {
            cart.transform.DORotate(faucetMidPoint.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(faucetCartPoint.transform.position, 1f);
            });
        });

        yield return new WaitForSeconds(3f);
        dark.SetActive(false);
        yield return new WaitForSeconds(3f);
        clue10.SetActive(true);
        ddm.IsDraggingValid = true;
    }


    private IEnumerator ToRope() {
        paperClip.transform.DOKill();
        paperClip.transform.DOMove(ropeClipPoint.transform.position, 1f)
        .OnComplete(() =>
        {
            paperClip.transform.DORotate(ropeClipPoint.transform.rotation.eulerAngles, 0.5f);
        });

        cart.transform.DOKill();
        cart.transform.DOMove(cartRopePoint.transform.position, 1.5f)
        .OnComplete(() =>
        {
            cart.transform.DORotate(cartRopePoint.transform.rotation.eulerAngles, 0.5f);
        });

        yield return new WaitForSeconds(4f);
        clue11.SetActive(true);
        Experiment2.SetActive(false);
        
        clue11.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            clue11.SetActive(false);
            StartCoroutine(Final());
        });

        ddm.IsDraggingValid = true;
    }

    private IEnumerator Final() {
        cart.transform.DOKill();
        if (selectedImage == "image2")
        {
            cart.transform.DORotate(H_CartFinal.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(H_CartFinal.transform.position, 1f);
            });
        }
        else {
            cart.transform.DORotate(V_CartFinal.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() =>
            {
                cart.transform.DOMove(V_CartFinal.transform.position, 1f);
            });
        }
        yield return new WaitForSeconds(8f);
        clue12.SetActive(true);
        FinalPanel.SetActive(true);
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
