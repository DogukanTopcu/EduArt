using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class L4_DragDropManager : MonoBehaviour
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


    // Experiment 1
    private GameObject UI_Tank;
    private GameObject UI_Tank_Closed;
    private GameObject UI_Beher;
    private GameObject UI_Beher_Half;
    private GameObject UI_Beher_Full;
    private GameObject UI_Tank_Beher;
    private GameObject UI_Cap;
    private GameObject UI_Fixer;
    private GameObject UI_Faucet;

    // Experiment 2
    private GameObject UI_Tank2;
    private GameObject UI_Faucet2;
    private GameObject UI_Fixer2;
    private GameObject UI_Tank_Beher2;


    // Shaking UI
    private GameObject ButtonsPanel;
    private GameObject NextButton;
    private GameObject Clue5;
    private GameObject Clue6;
    private GameObject Clue8;
    private GameObject Clue9;
    private GameObject Experiment;
    private GameObject Experiment2;

    // Object
    private GameObject Tank_Closed;
    private GameObject Tank;
    private GameObject Cap;

    private Vector3 TankInitialPos;


    public ARTemplateMenuManager menuManager;
    private bool flag1 = true;


    private void Start() {
        UI_Tank = FindInActiveObjectByName("UI_Tank");
        UI_Tank_Closed = FindInActiveObjectByName("UI_Tank-Cap");
        UI_Beher = FindInActiveObjectByName("UI_Beher");
        UI_Beher_Half = FindInActiveObjectByName("UI_Beher-Half");
        UI_Beher_Full = FindInActiveObjectByName("UI_Beher-Full");
        UI_Tank_Beher = FindInActiveObjectByName("UI_Tank-Beher");
        UI_Cap = FindInActiveObjectByName("UI_Cap");
        UI_Fixer = FindInActiveObjectByName("UI_Fixer");
        UI_Faucet = FindInActiveObjectByName("UI_Faucet");

        UI_Tank2 = FindInActiveObjectByName("UI_Tank2");
        UI_Faucet2 = FindInActiveObjectByName("UI_Faucet2");
        UI_Fixer2 = FindInActiveObjectByName("UI_Fixer2");
        UI_Tank_Beher2 = FindInActiveObjectByName("UI_Tank-Beher2");

        ButtonsPanel = FindInActiveObjectByName("ButtonsPanel");
        NextButton = FindInActiveObjectByName("NextButton");
        Clue5 = FindInActiveObjectByName("Clue5");
        Clue6 = FindInActiveObjectByName("Clue6");
        Clue8 = FindInActiveObjectByName("Clue8");
        Clue9 = FindInActiveObjectByName("Clue9");

        Experiment = FindInActiveObjectByName("Experiment");
        Experiment2 = FindInActiveObjectByName("Experiment2");

        relationsQueue.Add(new List<GameObject> { UI_Fixer.transform.GetChild(0).gameObject, UI_Beher });
        relationsQueue.Add(new List<GameObject> { UI_Beher_Half.transform.GetChild(0).gameObject, UI_Faucet });
        relationsQueue.Add(new List<GameObject> { UI_Beher_Full.transform.GetChild(0).gameObject, UI_Tank });
        relationsQueue.Add(new List<GameObject> { UI_Cap.transform.GetChild(0).gameObject, UI_Tank_Beher });
        relationsQueue.Add(new List<GameObject> { UI_Tank_Beher2.transform.GetChild(0).gameObject, UI_Fixer2 });
        relationsQueue.Add(new List<GameObject> { UI_Tank2.transform.GetChild(0).gameObject, UI_Faucet2 });
    }

    private void Update() {
        if (menuManager.IsStarted && flag1)
        {
            Tank = FindInActiveObjectByName("FilmTank");
            Cap = FindInActiveObjectByName("SM_Tank_Cap");
            Tank_Closed = FindInActiveObjectByName("FilmTank_Cap");
            flag1 = false;
        }
        TankInitialPos = FindInActiveObjectByName("FilmTank").transform.position;

        switch(level) {
            case 1:
                UI_Fixer.SetActive(false);
                UI_Beher.SetActive(false);
                UI_Beher_Half.SetActive(true);
                break;
            case 2:
                UI_Faucet.SetActive(false);
                UI_Beher_Half.SetActive(false);
                UI_Beher_Full.SetActive(true);
                break;
            case 3:
                UI_Tank.SetActive(false);
                UI_Beher_Full.SetActive(false);
                UI_Tank_Beher.SetActive(true);
                break;
            case 4:
                UI_Cap.SetActive(false);
                UI_Tank_Beher.SetActive(false);
                UI_Tank_Closed.SetActive(true);
                break;
            case 5:
                UI_Tank_Beher2.SetActive(false);
                UI_Tank2.SetActive(true);
                break;
            case 6:
                Experiment2.SetActive(false);
                break;
            default:
                break;
        }
    }


    public void StartShakingUI() {
        Experiment.SetActive(false);
        ButtonsPanel.SetActive(true);

        Tank_Closed.transform.DOKill();
        Tank_Closed.transform.DOMoveY(Tank_Closed.transform.position.y + 0.2f, 0.5f);

        Clue6.SetActive(true);
        Clue5.SetActive(false);
    }


    public void CompleteShake() {
        ButtonsPanel.SetActive(false);
        NextButton.SetActive(false);
        Clue8.SetActive(false);

        StartCoroutine(CompleteShakeRoutine());
    }

    private IEnumerator CompleteShakeRoutine() {
        Tank_Closed.transform.DOKill();
        Tank_Closed.transform.DOMove(TankInitialPos, 1.5f)
            .SetEase(Ease.InOutSine);
        
        yield return new WaitForSeconds(1.8f);
        
        Tank_Closed.SetActive(false);
        Tank.SetActive(true);
        Cap.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        Clue9.SetActive(true);
        Experiment2.SetActive(true);

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
