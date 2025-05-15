using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;

public class Level7ui : MonoBehaviour
{
    // UI
    private GameObject ligthDeskInfoUI;
    private GameObject agrandizorInfoUI;
    private GameObject timeoliteInfoUI;
    private GameObject cartInfoUI;
    private GameObject marjorInfoUI;
    private GameObject filmHolderInfoUI;
    private GameObject selectingPanel;

    // Points
    private GameObject MarjorInfoPoint;
    private GameObject MarjorDefaultPoint;
    private GameObject CartInfoPoint;
    private GameObject CartDefaultPoint;
    private GameObject SelectedFilmPoint;
    private GameObject SelectedFilmPoint2;
    private GameObject SelectedFilmPoint3;
    private GameObject CartPoint;
    private GameObject HorizontalMarjorPoint;
    private GameObject VerticalMarjorPoint;
    private GameObject SmallMarjorPoint;
    private GameObject LongMarjorPoint;
    private GameObject HorizontalCartPoint;
    private GameObject VerticalCartPoint;


    // Objects:
    private GameObject marjor;
    private GameObject cart;
    private GameObject Negative_Fillm_1;
    private GameObject Negative_Fillm_2;
    private GameObject Negative_Fillm_3;


    // Clues:
    private GameObject clue1;
    private GameObject clue2;
    private GameObject clue3;
    private GameObject clue4;
    private GameObject clue5;


    // States:
    private GameObject selectedImage = null;
    private Dictionary<string, Dictionary<string, GameObject>> imagesAndObjects;



    void Awake()
    {
        ligthDeskInfoUI = FindInActiveObjectByName("LightDeskInfoUI");
        agrandizorInfoUI = FindInActiveObjectByName("AgrandizorInfoUI");
        timeoliteInfoUI = FindInActiveObjectByName("TimeoliteInfoUI");
        marjorInfoUI = FindInActiveObjectByName("MarjorInfoUI");
        cartInfoUI = FindInActiveObjectByName("CartInfoUI");
        filmHolderInfoUI = FindInActiveObjectByName("FilmHolderInfoUI");
        selectingPanel = FindInActiveObjectByName("Select Image");

        MarjorInfoPoint = FindInActiveObjectByName("MarjorInfoPoint");
        MarjorDefaultPoint = FindInActiveObjectByName("MarjorDefaultPoint");
        CartInfoPoint = FindInActiveObjectByName("CartInfoPoint");
        CartDefaultPoint = FindInActiveObjectByName("CartDefaultPoint");
        SelectedFilmPoint = FindInActiveObjectByName("SelectedFilmPoint");
        SelectedFilmPoint2 = FindInActiveObjectByName("SelectedFilmPoint2");
        SelectedFilmPoint3 = FindInActiveObjectByName("SelectedFilmPoint3");
        CartPoint = FindInActiveObjectByName("CartPoint");
        HorizontalMarjorPoint = FindInActiveObjectByName("HorizontalMarjorPoint");
        VerticalMarjorPoint = FindInActiveObjectByName("VerticalMarjorPoint");
        SmallMarjorPoint = FindInActiveObjectByName("SmallMarjorPoint");
        LongMarjorPoint = FindInActiveObjectByName("LongMarjorPoint");
        HorizontalCartPoint = FindInActiveObjectByName("HorizontalCartPoint");
        VerticalCartPoint = FindInActiveObjectByName("VerticalCartPoint");

        marjor = FindInActiveObjectByName("Marjor");
        cart = FindInActiveObjectByName("Cart");
        Negative_Fillm_1 = FindInActiveObjectByName("Negative_Fillm_1");
        Negative_Fillm_2 = FindInActiveObjectByName("Negative_Fillm_2");
        Negative_Fillm_3 = FindInActiveObjectByName("Negative_Fillm_3");

        clue1 = FindInActiveObjectByName("Clue1");
        clue2 = FindInActiveObjectByName("Clue2");
        clue3 = FindInActiveObjectByName("Clue3");
        clue4 = FindInActiveObjectByName("Clue4");
        clue5 = FindInActiveObjectByName("Clue5");

        selectedImage = null;
        imagesAndObjects = new Dictionary<string, Dictionary<string, GameObject>>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Buttons:
    public void OnLightDeskInfoContinueButtonClick()
    {
        ligthDeskInfoUI.SetActive(false);
        agrandizorInfoUI.SetActive(true);
    }
    public void OnAgrandizorInfoContinueButtonClick()
    {
        agrandizorInfoUI.SetActive(false);
        timeoliteInfoUI.SetActive(true);
    }
    public void OnTimeoliteInfoContinueButtonClick()
    {
        marjor.transform.DOKill();
        marjor.transform.DOMove(MarjorInfoPoint.transform.position, 0.5f)
        .OnComplete(() =>
        {
            marjor.transform.DORotate(MarjorInfoPoint.transform.rotation.eulerAngles, 0.5f);
        });

        timeoliteInfoUI.SetActive(false);
        marjorInfoUI.SetActive(true);
    }
    public void OnMarjorInfoContinueButtonClick()
    {
        marjor.transform.DOKill();
        cart.transform.DOKill();

        marjor.transform.DORotate(MarjorDefaultPoint.transform.rotation.eulerAngles, 0.5f)
        .OnComplete(() =>
        {
            marjor.transform.DOMove(MarjorDefaultPoint.transform.position, 0.5f);
        });

        cart.transform.DOMove(CartInfoPoint.transform.position, 0.5f)
        .OnComplete(() =>
        {
            cart.transform.DORotate(CartInfoPoint.transform.rotation.eulerAngles, 0.5f);
        });

        marjorInfoUI.SetActive(false);
        cartInfoUI.SetActive(true);
    }
    public void OnCartInfoContinueButtonClick()
    {
        cart.transform.DOKill();
        cart.transform.DORotate(CartDefaultPoint.transform.rotation.eulerAngles, 0.5f)
        .OnComplete(() =>
        {
            cart.transform.DOMove(CartDefaultPoint.transform.position, 0.5f);
        });

        cartInfoUI.SetActive(false);

        clue1.SetActive(true);
        clue1.GetComponentInChildren<Button>().onClick.AddListener(ImageSelection);
    }

    private void ImageSelection() {
        clue1.SetActive(false);
        selectingPanel.SetActive(true);
        List<GameObject> images = new List<GameObject> {
            selectingPanel.transform.GetChild(0).transform.GetChild(0).gameObject,
            selectingPanel.transform.GetChild(0).transform.GetChild(1).gameObject,
            selectingPanel.transform.GetChild(0).transform.GetChild(2).gameObject
        };

        imagesAndObjects.Add(images[0].name, new Dictionary<string, GameObject> {
            { "image", images[0] },
            { "object", Negative_Fillm_1 }
        });
        imagesAndObjects.Add(images[1].name, new Dictionary<string, GameObject> {
            { "image", images[1] },
            { "object", Negative_Fillm_2 }
        });
        imagesAndObjects.Add(images[2].name, new Dictionary<string, GameObject> {
            { "image", images[2] },
            { "object", Negative_Fillm_3 }
        });

        foreach (GameObject image in images)
        {
            image.GetComponent<Button>().onClick.AddListener(() =>
            {
                image.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                selectedImage = image;
                foreach (GameObject img in images)
                {
                    if (img != image)
                    {
                        img.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            });
        }

        Button selectBtn = selectingPanel.transform.GetChild(1).GetComponent<Button>();
        selectBtn.onClick.AddListener(() =>
        {
            if (selectedImage != null)
            {
                selectingPanel.SetActive(false);
                PlayerPrefs.SetString("SelectedImage", selectedImage.name);
                GameObject selectedObject = imagesAndObjects[selectedImage.name]["object"];
                selectedObject.transform.DOKill();
                selectedObject.transform.DOMove(SelectedFilmPoint.transform.position, 0.5f)
                .OnComplete(() =>
                {
                    selectedObject.transform.DORotate(SelectedFilmPoint.transform.rotation.eulerAngles, 0.5f);
                });
                clue2.SetActive(true);
                clue2.GetComponentInChildren<Button>().onClick.AddListener(OnClue2ContinueButtonClick);
            }
        });
    }

    private void OnClue2ContinueButtonClick()
    {
        clue2.SetActive(false);
        GameObject selectedObject = imagesAndObjects[selectedImage.name]["object"];
        selectedObject.transform.DOKill();
        selectedObject.transform.DOMove(SelectedFilmPoint2.transform.position, 0.5f)
        .OnComplete(() =>
        {
            selectedObject.transform.DORotate(SelectedFilmPoint2.transform.rotation.eulerAngles, 0.5f);
        });
        filmHolderInfoUI.SetActive(true);
    }

    public void OnFilmHolderInfoContinueButtonClick()
    {
        filmHolderInfoUI.SetActive(false);
        GameObject selectedObject = imagesAndObjects[selectedImage.name]["object"];
        selectedObject.transform.DOKill();
        selectedObject.transform.DOMove(SelectedFilmPoint3.transform.position, 0.5f);
        clue3.SetActive(true);
        clue3.GetComponentInChildren<Button>().onClick.AddListener(() => 
        {
            StartCoroutine(OnClue3ContinueButtonClick());
        });
    }

    private IEnumerator OnClue3ContinueButtonClick()
    {
        clue3.SetActive(false);
        if (selectedImage.name == "image2")
        {
            StartCoroutine(HorizontalOrientationMarjor());
        }
        else
        {
            StartCoroutine(VerticalOrientationMarjor());
        }

        yield return new WaitForSeconds(4f);

        clue4.SetActive(true);
        clue4.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            StartCoroutine(OnClue4ContinueButtonClick());
        });
    }

    private IEnumerator HorizontalOrientationMarjor() {
        marjor.transform.DOKill();
        marjor.transform.DOMove(HorizontalMarjorPoint.transform.position, 0.5f)
        .OnComplete(() =>
        {
            marjor.transform.DORotate(HorizontalMarjorPoint.transform.rotation.eulerAngles, 0.5f);
        });

        cart.transform.DOKill();
        cart.transform.DOMove(CartPoint.transform.position, 0.5f);

        yield return new WaitForSeconds(1.5f);

        cart.transform.DOKill();
        cart.transform.DORotate(HorizontalCartPoint.transform.rotation.eulerAngles, 1f)
        .OnComplete(() =>
        {
            cart.transform.DOMove(HorizontalCartPoint.transform.position, 1f);
        });
    }

    private IEnumerator VerticalOrientationMarjor() {
        marjor.transform.DOKill();
        marjor.transform.DOMove(VerticalMarjorPoint.transform.position, 0.5f)
        .OnComplete(() =>
        {
            marjor.transform.DORotate(VerticalMarjorPoint.transform.rotation.eulerAngles, 0.5f);
        });

        cart.transform.DOKill();
        cart.transform.DOMove(CartPoint.transform.position, 0.5f);

        yield return new WaitForSeconds(1.5f);

        cart.transform.DOKill();
        cart.transform.DOMove(VerticalCartPoint.transform.position, 1f);
    }


    private IEnumerator OnClue4ContinueButtonClick() {
        clue4.SetActive(false);
        GameObject smallLeg = marjor.transform.GetChild(1).gameObject;
        GameObject longLeg = marjor.transform.GetChild(3).gameObject;

        smallLeg.transform.DOKill();
        smallLeg.transform.DOMove(SmallMarjorPoint.transform.position, 1f);

        yield return new WaitForSeconds(1f);

        longLeg.transform.DOKill();
        longLeg.transform.DOMove(LongMarjorPoint.transform.position, 1f);

        yield return new WaitForSeconds(2f);
        clue5.SetActive(true);
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
