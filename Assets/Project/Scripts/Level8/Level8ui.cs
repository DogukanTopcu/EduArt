using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq.Expressions;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level8ui : MonoBehaviour
{
    private Dictionary<string, GameObject> images = new Dictionary<string, GameObject>();

    // Objects:
    private GameObject paper_1;
    private GameObject paper_2;
    private GameObject paper_3;
    private GameObject marjor;
    private GameObject card1;
    private GameObject card2;
    private GameObject card3;

    // Positions:
    private GameObject HorizontalCartPoint;
    private GameObject HorizontalMarjorPoint;
    private GameObject PaperOutPoint;
    private GameObject Cart1_DefaultPoint;
    private GameObject Cart2_DefaultPoint;
    private GameObject Cart3_DefaultPoint;
    private GameObject CartPosition;
    private GameObject CartPoint;

    // UI:
    private GameObject focusSettingsPanel;
    private GameObject focusSlider;
    private GameObject TimeoliteInfoUI;
    private GameObject CartInfoUI;
    private GameObject TestInfoUI;
    private GameObject Dark;
    private GameObject PozometerSelection;


    // Clues:
    private GameObject clue_1;
    private GameObject clue_2;
    private GameObject clue_3;
    private GameObject clue_4;
    private GameObject clue_5;
    private GameObject clue_6;
    private GameObject warning;


    // States:
    private GameObject selectedImage;
    private String selectedImageName;
    private String selectedPosometerTime;


    void Awake()
    {
        HorizontalMarjorPoint = FindInActiveObjectByName("HorizontalMarjorPoint");
        HorizontalCartPoint = FindInActiveObjectByName("HorizontalCartPoint");
        PaperOutPoint = FindInActiveObjectByName("PaperOutPoint");
        Cart1_DefaultPoint = FindInActiveObjectByName("Cart1_DefaultPoint");
        Cart2_DefaultPoint = FindInActiveObjectByName("Cart2_DefaultPoint");
        Cart3_DefaultPoint = FindInActiveObjectByName("Cart3_DefaultPoint");
        CartPosition = FindInActiveObjectByName("CartPosition");
        CartPoint = FindInActiveObjectByName("CartPoint");

        paper_1 = FindInActiveObjectByName("paper_1");
        paper_2 = FindInActiveObjectByName("paper_2");
        paper_3 = FindInActiveObjectByName("paper_3");
        paper_1.SetActive(false);
        paper_2.SetActive(false);
        paper_3.SetActive(false);

        images.Add("image1", paper_1);
        images.Add("image2", paper_2);
        images.Add("image3", paper_3);

        marjor = FindInActiveObjectByName("Marjor");
        card1 = FindInActiveObjectByName("Card1");
        card2 = FindInActiveObjectByName("Card2");
        card3 = FindInActiveObjectByName("Card3");

        focusSettingsPanel = FindInActiveObjectByName("focusingSettings");
        focusSlider = FindInActiveObjectByName("SliderS");
        TimeoliteInfoUI = FindInActiveObjectByName("TimeoliteInfoUI");
        CartInfoUI = FindInActiveObjectByName("CartInfoUI");
        TestInfoUI = FindInActiveObjectByName("testInfoUI");
        Dark = FindInActiveObjectByName("Dark");
        PozometerSelection = FindInActiveObjectByName("pozometerSelection");

        clue_1 = FindInActiveObjectByName("Clue1");
        clue_2 = FindInActiveObjectByName("Clue2");
        clue_3 = FindInActiveObjectByName("Clue3");
        clue_4 = FindInActiveObjectByName("Clue4");
        clue_5 = FindInActiveObjectByName("Clue5");
        clue_6 = FindInActiveObjectByName("Clue6");
        warning = FindInActiveObjectByName("Warning");

        selectedImageName = PlayerPrefs.GetString("selectedImageName");
    }

    void Start()
    {
        if (selectedImage)
        {
            selectedImage = images[selectedImageName];
        }
        else {
            selectedImageName = "image1";
            selectedImage = images["image1"];
        }

        if (selectedImageName == "image2") {
            marjor.GetComponent<Transform>().position = HorizontalMarjorPoint.transform.position;
            marjor.GetComponent<Transform>().rotation = HorizontalMarjorPoint.transform.rotation;
            selectedImage.GetComponent<Transform>().position = HorizontalCartPoint.transform.position;
            selectedImage.GetComponent<Transform>().rotation = HorizontalCartPoint.transform.rotation;
        }
        selectedImage.SetActive(true);

        clue_1.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            clue_1.SetActive(false);
            focusSettingsPanel.SetActive(true);
            
            focusSettingsPanel.GetComponentInChildren<Button>().onClick.AddListener(() => StartCoroutine(OnNextButtonClick()));
            
            focusSlider.GetComponent<Slider>().onValueChanged.AddListener((value) =>
            {
                // Make Blur Updates
            });
        });
    }

    void Update()
    {
        
    }


    private IEnumerator OnNextButtonClick()
    {
        if (focusSlider.GetComponent<Slider>().value < 0.67f && focusSlider.GetComponent<Slider>().value > 0.5f)
        {
            // Contine
            warning.SetActive(false);
            focusSettingsPanel.SetActive(false);
            clue_2.SetActive(true);
            clue_2.GetComponentInChildren<Button>().onClick.AddListener(OnClue2NextButtonClick);
        }
        else {
            // Display Warning
            warning.SetActive(true);
            yield return new WaitForSeconds(1f);
            warning.SetActive(false);
        }
    }

    private void OnClue2NextButtonClick(){
        clue_2.SetActive(false);
        TestInfoUI.SetActive(true);
        TestInfoUI.GetComponentInChildren<Button>().onClick.AddListener(OnTestInfoUINextButtonClick);
        selectedImage.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTestInfoUINextButtonClick()
    {
        TestInfoUI.SetActive(false);
        TimeoliteInfoUI.SetActive(true);
        TimeoliteInfoUI.GetComponentInChildren<Button>().onClick.AddListener(OnTimeoliteInfoUINextButtonClick);
    }

    private void OnTimeoliteInfoUINextButtonClick()
    {
        TimeoliteInfoUI.SetActive(false);
        CartInfoUI.SetActive(true);
        CartInfoUI.GetComponentInChildren<Button>().onClick.AddListener(OnCartInfoUINextButtonClick);
    }

    private void OnCartInfoUINextButtonClick()
    {
        CartInfoUI.SetActive(false);
        clue_3.SetActive(true);
        clue_3.GetComponentInChildren<Button>().onClick.AddListener(OnClue3NextButtonClick);
    }

    private void OnClue3NextButtonClick()
    {
        clue_3.SetActive(false);
        Dark.SetActive(true);
        clue_4.SetActive(true);
        clue_4.GetComponentInChildren<Button>().onClick.AddListener(() => StartCoroutine(OnClue4NextButtonClick()));
    }

    private IEnumerator OnClue4NextButtonClick()
    {
        clue_4.SetActive(false);
        selectedImage.transform.DOKill();
        selectedImage.transform.DOMove(PaperOutPoint.transform.position, 1f);
        card1.SetActive(true);
        card2.SetActive(true);
        card3.SetActive(true);
        yield return new WaitForSeconds(1f);

        card1.transform.DOKill();
        card1.transform.DOMove(CartPoint.transform.position, 1f).OnComplete(() =>
        {
            card1.transform.DOMove(CartPosition.transform.position, 0.5f);
        });

        yield return new WaitForSeconds(1.7f);
        card1.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.3f);

        card1.transform.DOKill();
        card1.transform.DOMove(CartPoint.transform.position, 1f).OnComplete(() =>
        {
            card1.transform.DOMove(Cart1_DefaultPoint.transform.position, 0.5f);
        });

        yield return new WaitForSeconds(1.5f);

        card2.transform.DOKill();
        card2.transform.DOMove(CartPoint.transform.position, 1f).OnComplete(() =>
        {
            card2.transform.DOMove(CartPosition.transform.position, 0.5f);    
        });
        
        yield return new WaitForSeconds(1.7f);
        card2.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        card2.transform.DOKill();
        card2.transform.DOMove(CartPoint.transform.position, 1f).OnComplete(() =>
        {
            card2.transform.DOMove(Cart2_DefaultPoint.transform.position, 0.5f);
        });

        yield return new WaitForSeconds(1.5f);

        card3.transform.DOKill();
        card3.transform.DOMove(CartPoint.transform.position, 1f).OnComplete(() =>
        {
            card3.transform.DOMove(CartPosition.transform.position, 0.5f);
        });

        yield return new WaitForSeconds(1.7f);
        card3.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        card3.transform.DOKill();
        card3.transform.DOMove(CartPoint.transform.position, 1f).OnComplete(() =>
        {
            card3.transform.DOMove(Cart3_DefaultPoint.transform.position, 0.5f);
        });

        yield return new WaitForSeconds(1.5f);
        
        clue_5.SetActive(true);
        clue_5.GetComponentInChildren<Button>().onClick.AddListener(OnClue5NextButtonClick);
    }

    private void OnClue5NextButtonClick()
    {
        Dark.SetActive(false);
        clue_5.SetActive(false);

        Dictionary<string, GameObject> imagesList = new Dictionary<string, GameObject> {
            { PozometerSelection.transform.GetChild(0).name, PozometerSelection.transform.GetChild(0).gameObject },
            { PozometerSelection.transform.GetChild(1).name, PozometerSelection.transform.GetChild(1).gameObject },
            { PozometerSelection.transform.GetChild(2).name, PozometerSelection.transform.GetChild(2).gameObject }
        };

        GameObject selectedImageList = imagesList[selectedImageName];
        selectedImageList.SetActive(true);
        PozometerSelection.SetActive(true);

        for (int i = 0; i < selectedImageList.transform.childCount; i++)
        {
            GameObject child = selectedImageList.transform.GetChild(i).gameObject;
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                selectedImageList.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                selectedImageList.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                selectedImageList.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
                selectedPosometerTime = child.name;
                child.transform.GetChild(0).gameObject.SetActive(true);
                
            });
        }

        PozometerSelection.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(OnPozometerSelectionNextButtonClick);
    }

    private void OnPozometerSelectionNextButtonClick()
    {
        if (selectedPosometerTime != null)
        {
            PozometerSelection.SetActive(false);
            clue_6.SetActive(true);
            // Next level
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
