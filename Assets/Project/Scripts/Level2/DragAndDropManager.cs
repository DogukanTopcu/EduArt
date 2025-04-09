using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropManager : MonoBehaviour
{
    private GameObject experimentIcons;
    private GameObject spiralInformationUI;
    private GameObject secondClue;
    private GameObject Film;
    private GameObject Roll;


    private bool isDraggingValid = false;
    public bool IsDraggingValid
    {
        get { return isDraggingValid; }
        set { isDraggingValid = value; }
    }


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

    private GameObject UI_Film;
    private GameObject UI_Tank;
    private GameObject UI_Spiral;
    private GameObject UI_Cylinder;
    private GameObject UI_Huni;
    private GameObject UI_Film_Spiral;
    private GameObject UI_Cylinder_Tank;
    private GameObject UI_Film_Spiral_Tank_Cylinder;
    private GameObject UI_Film_Spiral_Tank_Cylinder_Huni;

    void Start()
    {
        experimentIcons = FindInActiveObjectByName("Experiment");
        spiralInformationUI = FindInActiveObjectByName("SpiralInformationPanel");
        secondClue = FindInActiveObjectByName("Clue2");
        Film = FindInActiveObjectByName("Film");
        Roll = FindInActiveObjectByName("Roll01");

        UI_Film = FindInActiveObjectByName("UI_Film");
        UI_Tank = FindInActiveObjectByName("UI_Tank");
        UI_Spiral = FindInActiveObjectByName("UI_Spiral");
        UI_Cylinder = FindInActiveObjectByName("UI_Cylinder");
        UI_Huni = FindInActiveObjectByName("UI_Huni");
        UI_Film_Spiral = FindInActiveObjectByName("UI_Film-Spiral");
        UI_Cylinder_Tank = FindInActiveObjectByName("UI_Cylinder-Tank");
        UI_Film_Spiral_Tank_Cylinder = FindInActiveObjectByName("UI_Film-Spiral-Tank-Cylinder");
        UI_Film_Spiral_Tank_Cylinder_Huni = FindInActiveObjectByName("UI_Film-Spiral-Tank-Cylinder-Huni");

        relationsQueue.Add(new List<GameObject> { UI_Film.transform.GetChild(0).gameObject, UI_Spiral });
        relationsQueue.Add(new List<GameObject> { UI_Cylinder.transform.GetChild(0).gameObject, UI_Tank });
        relationsQueue.Add(new List<GameObject> { UI_Film_Spiral.transform.GetChild(0).gameObject, UI_Cylinder_Tank });
        relationsQueue.Add(new List<GameObject> { UI_Huni.transform.GetChild(0).gameObject, UI_Film_Spiral_Tank_Cylinder });
    }

    void Update()
    {
        switch(level) {
            case 1:
                UI_Film.SetActive(false);
                UI_Spiral.SetActive(false);
                UI_Film_Spiral.SetActive(true);
                break;
            case 2:
                UI_Tank.SetActive(false);
                UI_Cylinder.SetActive(false);
                UI_Cylinder_Tank.SetActive(true);
                break;
            case 3:
                UI_Film_Spiral.SetActive(false);
                UI_Cylinder_Tank.SetActive(false);
                UI_Film_Spiral_Tank_Cylinder.SetActive(true);
                break;
            case 4:
                UI_Huni.SetActive(false);
                UI_Film_Spiral_Tank_Cylinder.SetActive(false);
                UI_Film_Spiral_Tank_Cylinder_Huni.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ContinueToExperiment() {
        spiralInformationUI.SetActive(false);
        experimentIcons.SetActive(true);
        secondClue.SetActive(true);
        Film.SetActive(false);
        Roll.SetActive(false);
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
