using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L5_DragDropManager : MonoBehaviour
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


    // Experiment
    private GameObject UI_FilmPieces;
    private GameObject UI_Film_Latch2;
    private GameObject UI_Film_Latch;
    private GameObject UI_Film;
    private GameObject UI_Rope;
    private GameObject UI_Rope_Film;
    private GameObject UI_Latch;
    private GameObject UI_Latch2;
    private GameObject UI_Folder;
    private GameObject UI_Scissors;
    private GameObject UI_Tong;
    private GameObject UI_Folder_Film;


    void Start()
    {
        UI_FilmPieces = FindInActiveObjectByName("UI_FilmPieces");
        UI_Film_Latch2 = FindInActiveObjectByName("UI_Film-Latch2");
        UI_Film_Latch = FindInActiveObjectByName("UI_Film-Latch");
        UI_Film = FindInActiveObjectByName("UI_Film");
        UI_Rope = FindInActiveObjectByName("UI_Rope");
        UI_Rope_Film = FindInActiveObjectByName("UI_Rope_Film");
        UI_Latch = FindInActiveObjectByName("UI_Latch");
        UI_Latch2 = FindInActiveObjectByName("UI_Latch2");
        UI_Folder = FindInActiveObjectByName("UI_Folder");
        UI_Scissors = FindInActiveObjectByName("UI_Scissors");
        UI_Tong = FindInActiveObjectByName("UI_Tong");
        UI_Folder_Film = FindInActiveObjectByName("UI_Folder-Film");

        relationsQueue.Add(new List<GameObject> { UI_Latch.transform.GetChild(0).gameObject, UI_Film });
        relationsQueue.Add(new List<GameObject> { UI_Latch2.transform.GetChild(0).gameObject, UI_Film_Latch });
        relationsQueue.Add(new List<GameObject> { UI_Film_Latch2.transform.GetChild(0).gameObject, UI_Rope });
        relationsQueue.Add(new List<GameObject> { UI_Tong.transform.GetChild(0).gameObject, UI_Rope_Film });
        relationsQueue.Add(new List<GameObject> { UI_Scissors.transform.GetChild(0).gameObject, UI_Rope_Film });
        relationsQueue.Add(new List<GameObject> { UI_FilmPieces.transform.GetChild(0).gameObject, UI_Folder });
    }


    void Update()
    {
        switch(level) {
            case 1:
                UI_Film.SetActive(false);
                UI_Latch.SetActive(false);
                UI_Latch2.SetActive(true);
                UI_Film_Latch.SetActive(true);
                break;
            case 2:
                UI_Film_Latch.SetActive(false);
                UI_Latch2.SetActive(false);
                UI_Film_Latch2.SetActive(true);
                break;
            case 3:
                UI_Film_Latch2.SetActive(false);
                UI_Rope.SetActive(false);
                UI_Rope_Film.SetActive(true);
                break;
            case 4:
                UI_Tong.SetActive(false);
                break;
            case 5:
                UI_Rope_Film.SetActive(false);
                UI_Scissors.SetActive(false);
                UI_FilmPieces.SetActive(true);
                break;
            case 6:
                UI_FilmPieces.SetActive(false);
                UI_Folder.SetActive(false);
                UI_Folder_Film.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void NextLevel() {
        SceneManager.LoadScene("Education");
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
