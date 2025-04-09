using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level2ui : MonoBehaviour
{
    public DragAndDropManager ddm;
    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private bool flag4 = true;


    private GameObject levelInfoPanel;
    private GameObject startPanel;
    private GameObject experimentStartPanel;

    private GameObject experimentIcons;
    private GameObject spiralInformationUI;
    
    private GameObject firstClue;
    private GameObject secondClue;
    private GameObject thirdClue;
    private GameObject fourthClue;
    private GameObject fifthClue;

    private GameObject thirdLevelSlot;


    // Objects
    private GameObject roll;
    private GameObject film;
    private GameObject tank;
    private GameObject tankSpiral;
    private GameObject cylinder;
    private GameObject huni;


    // Object Points
    private Transform rollPoint;
    private Transform filmPoint;
    private Transform tankPoint;
    private Transform tankSpiralPoint;
    private Transform cylinderPoint;
    private Transform huniPoint;
    private Transform TankTopPoint;


    void Start()
    {
        startPanel = FindInActiveObjectByName("ExperimentStarterUI");
        levelInfoPanel = FindInActiveObjectByName("Film_Spiral_InfoUI");
        experimentStartPanel = FindInActiveObjectByName("Film_Spiral_ExperimentInfo");

        experimentIcons = FindInActiveObjectByName("Experiment");
        spiralInformationUI = FindInActiveObjectByName("SpiralInformationPanel");

        ddm = FindInActiveObjectByName("DragDropManager").GetComponent<DragAndDropManager>();

        firstClue = FindInActiveObjectByName("Clue1");
        secondClue = FindInActiveObjectByName("Clue2");
        thirdClue = FindInActiveObjectByName("Clue3");
        fourthClue = FindInActiveObjectByName("Clue4");
        fifthClue = FindInActiveObjectByName("Clue5");

        thirdLevelSlot = FindInActiveObjectByName("Level3Panel");

        roll = FindInActiveObjectByName("Roll01");
        film = FindInActiveObjectByName("Film");
        tank = FindInActiveObjectByName("SM_Tank");
        tankSpiral = FindInActiveObjectByName("SM_Tank_Spiral");
        cylinder = FindInActiveObjectByName("SM_Tank_Cylinder_Bottom");
        huni = FindInActiveObjectByName("SM_Tank_Cylinder_Top");

        rollPoint = FindInActiveObjectByName("RollPoint").transform;
        filmPoint = FindInActiveObjectByName("FilmPoint").transform;
        tankPoint = FindInActiveObjectByName("TankPoint").transform;
        tankSpiralPoint = FindInActiveObjectByName("TankSpiralPoint").transform;
        cylinderPoint = FindInActiveObjectByName("CylinderPoint").transform;
        huniPoint = FindInActiveObjectByName("HuniPoint").transform;
        TankTopPoint = FindInActiveObjectByName("TankTopPoint").transform;
    }

    public void StartExperiment() {
        startPanel.SetActive(false);
        levelInfoPanel.SetActive(true);

        roll.transform.DOMove(rollPoint.position, 1f).SetEase(Ease.OutQuad);
        film.transform.DOMove(filmPoint.position, 1f).SetEase(Ease.OutQuad);
        tank.transform.DOMove(tankPoint.position, 1f).SetEase(Ease.OutQuad);
        tankSpiral.transform.DOMove(tankSpiralPoint.position, 1f).SetEase(Ease.OutQuad);
        cylinder.transform.DOMove(cylinderPoint.position, 1f).SetEase(Ease.OutQuad);
        huni.transform.DOMove(huniPoint.position, 1f).SetEase(Ease.OutQuad);
    }

    public void NextStarterInfo() {
        levelInfoPanel.SetActive(false);
        experimentStartPanel.SetActive(true);
        experimentIcons.SetActive(true);
    }
    public void StartExperimentInfo() {
        experimentStartPanel.SetActive(false);
        firstClue.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    private void Update() {
        if (ddm.Level == 1 && flag1)
        {
            flag1 = false;
            firstClue.SetActive(false);
            experimentIcons.SetActive(false);
            spiralInformationUI.SetActive(true);
        }

        if (ddm.Level == 2 && flag2)
        {
            ddm.IsDraggingValid = false;
            flag2 = false;
            secondClue.SetActive(false);
            StartCoroutine(AnimateTankCylinder());
        }

        if (ddm.Level == 3 && flag3)
        {
            ddm.IsDraggingValid = false;
            flag3 = false;
            thirdClue.SetActive(false);
            StartCoroutine(AnimateTankSpiral());
        }

        if (ddm.Level == 4 && flag4)
        {
            ddm.IsDraggingValid = false;
            flag4 = false;
            fourthClue.SetActive(false);
            StartCoroutine(AnimateTankHuni());
        }

        if (ddm.Level == 5)
        {
            ddm.IsDraggingValid = false;
            StartCoroutine(EndLevel());
        }
    }

    public IEnumerator AnimateTankCylinder() {
        cylinder.transform.DOKill();
        cylinder.transform.DOMove(TankTopPoint.position, 2f)
            .SetEase(Ease.Linear)
            .OnComplete(() => 
                cylinder.transform.DOMove(new Vector3(tankPoint.position.x, tankPoint.position.y + 0.001f, tankPoint.position.z), 2f)
                .SetEase(Ease.Linear)
            );
        yield return new WaitForSeconds(4f);
        thirdClue.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    public IEnumerator AnimateTankSpiral() {
        tankSpiral.transform.DOKill();
        tankSpiral.transform.DOMove(TankTopPoint.position, 2f)
            .SetEase(Ease.Linear)
            .OnComplete(() => 
                tankSpiral.transform.DOMove(new Vector3(tankPoint.position.x, tankPoint.position.y + 0.001f, tankPoint.position.z), 2f)
                .SetEase(Ease.Linear)
            );
        yield return new WaitForSeconds(4f);
        fourthClue.SetActive(true);
        ddm.IsDraggingValid = true;
    }
    

    public IEnumerator AnimateTankHuni() {
        huni.transform.DOKill();
        huni.transform.DOMove(TankTopPoint.position, 2f)
            .SetEase(Ease.Linear)
            .OnComplete(() => 
                huni.transform.DOMove(new Vector3(tankPoint.position.x, tankPoint.position.y + 0.001f, tankPoint.position.z), 2f)
                .SetEase(Ease.Linear)
            );
        yield return new WaitForSeconds(4f);
        fifthClue.SetActive(true);
        thirdLevelSlot.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    public IEnumerator EndLevel() {
        fifthClue.SetActive(false);
        experimentIcons.SetActive(false);
        if (PlayerPrefs.GetInt("Level") < 3)
        {
            PlayerPrefs.SetInt("Level", 3);
        }

        yield return new WaitForSeconds(2f);
        thirdLevelSlot.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level 3");
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
