using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using System.Collections;
using UnityEngine.UI;

public class Level5ui : MonoBehaviour
{
    // DragDropManager
    private L5_DragDropManager ddm;

    // UI
    private GameObject StopInfoUI;
    private GameObject TankPartInfoUI;
    private GameObject StartExperimentUI;
    private GameObject Experiment;
    private GameObject NextButton;


    // Position
    private GameObject SpiralPos;
    private GameObject CylinderPos;
    private GameObject HuniPos;
    private GameObject FilmLatchPos1;
    private GameObject FilmLatchPos2;
    private GameObject Clip1DefaultPos;
    private GameObject Clip2DefaultPos;
    private GameObject FilmRopePos;
    private GameObject FilmDefaultPos;
    private GameObject TongStartPos;
    private GameObject TongStopPos;
    private GameObject TongDefaultPos;

    // Scissors Positions
    private GameObject ScissorsDefaultPos;
    private GameObject ScissorsPos1a;
    private GameObject ScissorsPos1b;
    private GameObject ScissorsPos2a;
    private GameObject ScissorsPos2b;
    private GameObject ScissorsPos3a;
    private GameObject ScissorsPos3b;
    private GameObject ScissorsPos4a;
    private GameObject ScissorsPos4b;
    private GameObject ScissorsPos5a;
    private GameObject ScissorsPos5b;


    // Objects
    private GameObject Spiral;
    private GameObject Cylinder;
    private GameObject Huni;
    private GameObject Film;
    private GameObject Clip1;
    private GameObject Clip2;
    private GameObject Tong;
    private GameObject Scissors;
    private GameObject Folder;
    private GameObject FolderOpened;
    // Filmparts
    private GameObject FilmPart_1;
    private GameObject FilmPart_2;
    private GameObject FilmPart_3;
    private GameObject FilmPart_4;
    private GameObject FilmPart_5;
    private GameObject FilmPart_6;


    // Flags
    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private bool flag4 = true;
    private bool flag5 = true;
    private bool flag6 = true;


    // Clues
    private GameObject Clue1;
    private GameObject Clue2;
    private GameObject Clue3;
    private GameObject Clue4;
    private GameObject Clue5;
    private GameObject Clue6;
    private GameObject Clue7;
    private GameObject Clue8;

    void Start()
    {
        // DragDropManager
        ddm = GameObject.Find("DragDropManager").GetComponent<L5_DragDropManager>();

        // UI
        StopInfoUI = FindInActiveObjectByName("StopInfoUI");
        TankPartInfoUI = FindInActiveObjectByName("TankPartInfoUI");
        StartExperimentUI = FindInActiveObjectByName("StartExperimentUI");
        Experiment = FindInActiveObjectByName("Experiment");
        NextButton = FindInActiveObjectByName("NextButton");

        // Position
        SpiralPos = FindInActiveObjectByName("TankSpiralPos");
        CylinderPos = FindInActiveObjectByName("CylinderPos");
        HuniPos = FindInActiveObjectByName("HuniPos");
        FilmLatchPos1= FindInActiveObjectByName("FilmLatchPos1");
        FilmLatchPos2 = FindInActiveObjectByName("FilmLatchPos2");
        Clip1DefaultPos = FindInActiveObjectByName("paper_clip_1_Pos");
        Clip2DefaultPos = FindInActiveObjectByName("paper_clip_2_Pos");
        FilmRopePos = FindInActiveObjectByName("FilmRopePos");
        FilmDefaultPos = FindInActiveObjectByName("FilmDefaultPos");
        TongStartPos = FindInActiveObjectByName("TongStartPos");
        TongStopPos = FindInActiveObjectByName("TongStopPos");
        TongDefaultPos = FindInActiveObjectByName("TongDefaultPos");

        // Scissors Positions
        ScissorsDefaultPos = FindInActiveObjectByName("ScissorsDefaultPos");
        ScissorsPos1a = FindInActiveObjectByName("ScissorsPos1a");
        ScissorsPos1b = FindInActiveObjectByName("ScissorsPos1b");
        ScissorsPos2a = FindInActiveObjectByName("ScissorsPos2a");
        ScissorsPos2b = FindInActiveObjectByName("ScissorsPos2b");
        ScissorsPos3a = FindInActiveObjectByName("ScissorsPos3a");
        ScissorsPos3b = FindInActiveObjectByName("ScissorsPos3b");
        ScissorsPos4a = FindInActiveObjectByName("ScissorsPos4a");
        ScissorsPos4b = FindInActiveObjectByName("ScissorsPos4b");
        ScissorsPos5a = FindInActiveObjectByName("ScissorsPos5a");
        ScissorsPos5b = FindInActiveObjectByName("ScissorsPos5b");

        // Objects
        Spiral = FindInActiveObjectByName("SM_Tank_Spiral");
        Cylinder = FindInActiveObjectByName("SM_Tank_Cylinder_Bottom");
        Huni = FindInActiveObjectByName("SM_Tank_Cylinder_Top");
        Film = FindInActiveObjectByName("Film");
        Clip1 = FindInActiveObjectByName("paper_clip_1");
        Clip2 = FindInActiveObjectByName("paper_clip_2");
        Tong = FindInActiveObjectByName("Tong");
        Scissors = FindInActiveObjectByName("scissor");
        Folder = FindInActiveObjectByName("Folder");
        FolderOpened = FindInActiveObjectByName("FolderOpen");
        // Filmparts
        FilmPart_1 = FindInActiveObjectByName("FilmPart_1");
        FilmPart_2 = FindInActiveObjectByName("FilmPart_2");
        FilmPart_3 = FindInActiveObjectByName("FilmPart_3");
        FilmPart_4 = FindInActiveObjectByName("FilmPart_4");
        FilmPart_5 = FindInActiveObjectByName("FilmPart_5");
        FilmPart_6 = FindInActiveObjectByName("FilmPart_6");


        // Clues
        Clue1 = FindInActiveObjectByName("Clue1");
        Clue2 = FindInActiveObjectByName("Clue2");
        Clue3 = FindInActiveObjectByName("Clue3");
        Clue4 = FindInActiveObjectByName("Clue4");
        Clue5 = FindInActiveObjectByName("Clue5");
        Clue6 = FindInActiveObjectByName("Clue6");
        Clue7 = FindInActiveObjectByName("Clue7");
        Clue8 = FindInActiveObjectByName("Clue8");


        NextButton.GetComponent<Button>().onClick.AddListener(NextButtonBtn);
    }

    void Update()
    {
        if (ddm.Level == 1 && flag1) {
            ddm.IsDraggingValid = false;
            flag1 = false;
            Clue1.SetActive(false);
            StartCoroutine(Step1());
        }
        else if (ddm.Level == 2 && flag2) {
            ddm.IsDraggingValid = false;
            flag2 = false;
            Clue2.SetActive(false);
            StartCoroutine(Step2());
        }
        else if (ddm.Level == 3 && flag3) {
            ddm.IsDraggingValid = false;
            flag3 = false;
            Clue3.SetActive(false);
            StartCoroutine(Step3());
        }
        else if (ddm.Level == 4 && flag4) {
            ddm.IsDraggingValid = false;
            flag4 = false;
            Clue4.SetActive(false);
            Experiment.SetActive(false);
            StartCoroutine(Step4());
        }
        else if (ddm.Level == 5 && flag5) {
            ddm.IsDraggingValid = false;
            flag5 = false;
            Clue6.SetActive(false);
            StartCoroutine(Step5());
        }
        else if (ddm.Level == 6 && flag6) {
            ddm.IsDraggingValid = false;
            flag6 = false;
            Clue7.SetActive(false);
            Experiment.SetActive(false);
            Folder.SetActive(false);
            FolderOpened.SetActive(true);
            StartCoroutine(Step6());
        }
    }


    private IEnumerator Step1()
    {
        Clip1.transform.DOKill();
        Clip1.transform.DOMove(FilmLatchPos1.transform.position, 0.75f)
            .OnComplete(() => {
                Clip1.transform.DORotate(FilmLatchPos1.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(1.2f);
        Clip1.transform.SetParent(Film.transform);
        Clue2.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    private IEnumerator Step2()
    {
        Clip2.transform.DOKill();
        Clip2.transform.DOMove(FilmLatchPos2.transform.position, 0.75f)
            .OnComplete(() => {
                Clip2.transform.DORotate(FilmLatchPos2.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(1.2f);
        Clip2.transform.SetParent(Film.transform);
        Clue3.SetActive(true);
        ddm.IsDraggingValid = true;
    }
    private IEnumerator Step3()
    {
        Film.transform.DOKill();
        Film.transform.DORotate(FilmRopePos.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() => {
                Film.transform.DOMove(FilmRopePos.transform.position, 1f);
            });
        
        yield return new WaitForSeconds(1.7f);
        Clue4.SetActive(true);
        ddm.IsDraggingValid = true;
    }
    private IEnumerator Step4()
    {
        Tong.transform.DOKill();
        Tong.transform.DOMove(TongStartPos.transform.position, 1f)
            .OnComplete(() => {
                Tong.transform.DORotate(TongStopPos.transform.rotation.eulerAngles, 0.25f);
            });
        yield return new WaitForSeconds(1.5f);

        Tong.transform.DOKill();
        Tong.transform.DOMove(TongStopPos.transform.position, 4f);

        yield return new WaitForSeconds(4.2f);

        Tong.transform.DOKill();
        Tong.transform.DOMove(TongStartPos.transform.position, 4f);

        yield return new WaitForSeconds(4.2f);

        Tong.transform.DOKill();
        Tong.transform.DORotate(TongDefaultPos.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() => {
                Tong.transform.DOMove(TongDefaultPos.transform.position, 1f);
            });
        
        yield return new WaitForSeconds(2f);
        NextButton.SetActive(true);
        Clue5.SetActive(true);
        ddm.IsDraggingValid = true;
    }
    private IEnumerator Step5()
    {
        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos1a.transform.position, 1f)
            .OnComplete(() => {
                Scissors.transform.DORotate(ScissorsPos1a.transform.rotation.eulerAngles, 0.25f);
            });
        yield return new WaitForSeconds(1.5f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos1b.transform.position, 0.5f)
            .OnComplete(() => {
                Scissors.transform.DOMove(ScissorsPos1a.transform.position, 0.5f);
            });
        
        yield return new WaitForSeconds(1.1f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos2a.transform.position, 0.5f);

        yield return new WaitForSeconds(0.7f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos2b.transform.position, 0.5f)
            .OnComplete(() => {
                Scissors.transform.DOMove(ScissorsPos2a.transform.position, 0.5f);
            });
        
        yield return new WaitForSeconds(1.1f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos3a.transform.position, 0.5f);

        yield return new WaitForSeconds(0.7f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos3b.transform.position, 0.5f)
            .OnComplete(() => {
                Scissors.transform.DOMove(ScissorsPos3a.transform.position, 0.5f);
            });
        
        yield return new WaitForSeconds(1.1f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos4a.transform.position, 0.5f);

        yield return new WaitForSeconds(0.7f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos4b.transform.position, 0.5f)
            .OnComplete(() => {
                Scissors.transform.DOMove(ScissorsPos4a.transform.position, 0.5f);
            });
        
        yield return new WaitForSeconds(1.1f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos5a.transform.position, 0.5f);

        yield return new WaitForSeconds(0.7f);

        Scissors.transform.DOKill();
        Scissors.transform.DOMove(ScissorsPos5b.transform.position, 0.5f)
            .OnComplete(() => {
                Scissors.transform.DOMove(ScissorsPos5a.transform.position, 0.5f);
            });
        
        yield return new WaitForSeconds(1.1f);

        Scissors.transform.DOKill();
        Scissors.transform.DORotate(ScissorsDefaultPos.transform.rotation.eulerAngles, 0.5f)
            .OnComplete(() => {
                Scissors.transform.DOMove(ScissorsDefaultPos.transform.position, 1f);
            });
        
        yield return new WaitForSeconds(1.7f);
        Clue7.SetActive(true);
        ddm.IsDraggingValid = true;
    }

    private IEnumerator Step6() {
        GameObject FilmPos1 = FolderOpened.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        GameObject FilmPos2 = FolderOpened.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        GameObject FilmPos3 = FolderOpened.transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        GameObject FilmPos4 = FolderOpened.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        GameObject FilmPos5 = FolderOpened.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
        GameObject FilmPos6 = FolderOpened.transform.GetChild(1).GetChild(0).GetChild(2).gameObject;

        GameObject LeftSide = FolderOpened.transform.GetChild(0).GetChild(0).gameObject;
        GameObject RightSide = FolderOpened.transform.GetChild(1).GetChild(0).gameObject;

        FilmPart_1.transform.DOKill();
        FilmPart_1.transform.SetParent(LeftSide.transform);
        FilmPart_1.transform.DOMove(FilmPos1.transform.position, 1f)
            .OnComplete(() => {
                FilmPart_1.transform.DORotate(FilmPos1.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(0.25f);

        FilmPart_2.transform.DOKill();
        FilmPart_2.transform.SetParent(LeftSide.transform);
        FilmPart_2.transform.DOMove(FilmPos2.transform.position, 1f)
            .OnComplete(() => {
                FilmPart_2.transform.DORotate(FilmPos2.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(0.25f);

        FilmPart_3.transform.DOKill();
        FilmPart_3.transform.SetParent(LeftSide.transform);
        FilmPart_3.transform.DOMove(FilmPos3.transform.position, 1f)
            .OnComplete(() => {
                FilmPart_3.transform.DORotate(FilmPos3.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(0.25f);

        FilmPart_4.transform.DOKill();
        FilmPart_4.transform.SetParent(RightSide.transform);
        FilmPart_4.transform.DOMove(FilmPos4.transform.position, 1f)
            .OnComplete(() => {
                FilmPart_4.transform.DORotate(FilmPos4.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(0.25f);

        FilmPart_5.transform.DOKill();
        FilmPart_5.transform.SetParent(RightSide.transform);
        FilmPart_5.transform.DOMove(FilmPos5.transform.position, 1f)
            .OnComplete(() => {
                FilmPart_5.transform.DORotate(FilmPos5.transform.rotation.eulerAngles, 0.25f);
            });
        
        yield return new WaitForSeconds(0.25f);

        FilmPart_6.transform.DOKill();
        FilmPart_6.transform.SetParent(RightSide.transform);
        FilmPart_6.transform.DOMove(FilmPos6.transform.position, 1f)
            .OnComplete(() => {
                FilmPart_6.transform.DORotate(FilmPos5.transform.rotation.eulerAngles, 0.25f);
            });

        yield return new WaitForSeconds(1.5f);
        Clue8.SetActive(true);
        ddm.IsDraggingValid = true;
    }


    // Step 4 to Step 5
    private IEnumerator NextStep()
    {
        Film.transform.DOKill();
        Film.transform.DOMove(FilmDefaultPos.transform.position, 1f)
            .OnComplete(() => {
                Film.transform.DORotate(FilmDefaultPos.transform.rotation.eulerAngles, 0.5f);
            });
        yield return new WaitForSeconds(1.5f);

        Clip1.transform.SetParent(transform.GetChild(1));
        Clip2.transform.SetParent(transform.GetChild(1));

        Clip1.transform.DOKill();
        Clip1.transform.DORotate(Clip1DefaultPos.transform.rotation.eulerAngles, 0.25f)
            .OnComplete(() => {
                Clip1.transform.DOMove(Clip1DefaultPos.transform.position, 0.75f);
            });
        
        Clip2.transform.DOKill();
        Clip2.transform.DORotate(Clip2DefaultPos.transform.rotation.eulerAngles, 0.25f)
            .OnComplete(() => {
                Clip2.transform.DOMove(Clip2DefaultPos.transform.position, 0.75f);
            });
        
        yield return new WaitForSeconds(1.2f);
        Clue6.SetActive(true);
        Experiment.SetActive(true);
    }

    public void NextButtonBtn()
    {
        NextButton.SetActive(false);
        Clue5.SetActive(false);
        StartCoroutine(NextStep());
    }

    public void StopInfoUIBtn()
    {
        StopInfoUI.SetActive(false);
        TankPartInfoUI.SetActive(true);
    }
    public void TankPartInfoUIBtn()
    {
        TankPartInfoUI.SetActive(false);
        Spiral.transform.DOMove(SpiralPos.transform.position, 1f);
        Cylinder.transform.DOMove(CylinderPos.transform.position, 1f);
        Huni.transform.DOMove(HuniPos.transform.position, 1f).OnComplete(() => {
            Film.SetActive(true);
            StartExperimentUI.SetActive(true);
        });
    }
    public void StartExperimentUIBtn()
    {
        StartExperimentUI.SetActive(false);
        Clue1.SetActive(true);
        Experiment.SetActive(true);
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
