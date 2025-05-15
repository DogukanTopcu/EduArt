using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Level8ui : MonoBehaviour
{
    private Dictionary<string, GameObject> images = new Dictionary<string, GameObject>();

    // Objects:
    private GameObject paper_1;
    private GameObject paper_2;
    private GameObject paper_3;
    private GameObject marjor;

    // Positions:
    private GameObject HorizontalCartPoint;
    private GameObject HorizontalMarjorPoint;


    // States:
    private GameObject selectedImage;
    private String selectedImageName;


    void Awake()
    {
        HorizontalMarjorPoint = FindInActiveObjectByName("HorizontalMarjorPoint");
        HorizontalCartPoint = FindInActiveObjectByName("HorizontalCartPoint");

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

        selectedImageName = PlayerPrefs.GetString("SelectedImage");
    }

    void Start()
    {
        selectedImage = images[selectedImageName];

        if (selectedImageName == "image2") {
            marjor.transform.position = HorizontalMarjorPoint.transform.position;
            selectedImage.transform.position = HorizontalCartPoint.transform.position;
        }
        selectedImage.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
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
