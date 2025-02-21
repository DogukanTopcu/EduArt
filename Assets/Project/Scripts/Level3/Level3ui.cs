using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Level3ui : MonoBehaviour
{
    // DragAndDropManager
    public L3_DragDropManager ddm;
    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private bool flag4 = true;
    private bool flag5 = true;
    private bool flag6 = true;

    // UI
    private GameObject Film_Spiral_InfoUI;
    private GameObject Film_Spiral_ExperimentInfo;
    private GameObject Experiment;
    private GameObject ButtonsPanel;
    private GameObject ButtonsPanel2;
    private GameObject Shake2;
    private GameObject PourButton;

    // Clues
    private GameObject Clue1;
    private GameObject Clue2;
    private GameObject Clue3;
    private GameObject Clue4;
    private GameObject Clue5;
    private GameObject Clue9;
    private GameObject Clue10;
    private GameObject Clue11;


    
    // Objects
    private GameObject Beher;
    private GameObject Beher_Half;
    private GameObject Beher_Full;
    private GameObject Developer;
    private GameObject Tank;
    private GameObject Cap;
    private GameObject Tank_Cap;


    private GameObject DeveloperDefaultPos;
    private GameObject DeveloperPos;
    private GameObject BeherCheckpointPos;
    private GameObject BeherFaucetPoint;
    private GameObject BeherDefaultPos;
    private GameObject DeveloperSecondPos;
    private GameObject BeherTankPos;

    private GameObject TankToDeveloperPos_Tank;
    private GameObject TankToDeveloperPos_Developer;
    private GameObject TankFaucetPos1;
    private GameObject TankFaucetPos2;


    void Start()
    {
        ddm = GameObject.Find("DragDropManager").GetComponent<L3_DragDropManager>();

        Film_Spiral_InfoUI = FindInActiveObjectByName("Film_Spiral_InfoUI");
        Film_Spiral_ExperimentInfo = FindInActiveObjectByName("Film_Spiral_ExperimentInfo");
        Experiment = FindInActiveObjectByName("Experiment");
        ButtonsPanel = FindInActiveObjectByName("ButtonsPanel");
        ButtonsPanel2 = FindInActiveObjectByName("ButtonsPanel2");
        Shake2 = FindInActiveObjectByName("Shake2");
        PourButton = FindInActiveObjectByName("PourButton");

        Clue1 = FindInActiveObjectByName("Clue1");
        Clue2 = FindInActiveObjectByName("Clue2");
        Clue3 = FindInActiveObjectByName("Clue3");
        Clue4 = FindInActiveObjectByName("Clue4");
        Clue5 = FindInActiveObjectByName("Clue5");
        Clue9 = FindInActiveObjectByName("Clue9");
        Clue10 = FindInActiveObjectByName("Clue10");
        Clue11 = FindInActiveObjectByName("Clue11");

        Beher = FindInActiveObjectByName("Beher");
        Beher_Half = FindInActiveObjectByName("Beher_half");
        Beher_Full = FindInActiveObjectByName("Beher_full");
        Developer = FindInActiveObjectByName("DeveloperObj");
        Tank = FindInActiveObjectByName("FilmTank");
        Cap = FindInActiveObjectByName("SM_Tank_Cap");
        Tank_Cap = FindInActiveObjectByName("FilmTank_Cap");

        DeveloperDefaultPos = FindInActiveObjectByName("DeveloperDefaultPos");
        DeveloperPos = FindInActiveObjectByName("DeveloperPos");
        BeherCheckpointPos = FindInActiveObjectByName("BeherCheckpointPos");
        BeherFaucetPoint = FindInActiveObjectByName("BeherFaucetPos");
        BeherDefaultPos = FindInActiveObjectByName("BeherDefaultPos");
        DeveloperSecondPos = FindInActiveObjectByName("DeveloperSecondPos");
        BeherTankPos = FindInActiveObjectByName("BeherTankPos");

        TankToDeveloperPos_Tank = FindInActiveObjectByName("TankToDeveloperPos_Tank");
        TankToDeveloperPos_Developer = FindInActiveObjectByName("TankToDeveloperPos_Developer");
        TankFaucetPos1 = FindInActiveObjectByName("TankFaucetPos1");
        TankFaucetPos2 = FindInActiveObjectByName("TankFaucetPos2");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ddm.Level == 1 && flag1)
        {
            ddm.IsDraggingValid = false;
            flag1 = false;
            Clue1.SetActive(false);
            StartCoroutine(DeveloperAnimation());
        }

        if (ddm.Level == 2 && flag2)
        {
            ddm.IsDraggingValid = false;
            flag2 = false;
            Clue2.SetActive(false);
            StartCoroutine(BeherAnimation());
        }

        if (ddm.Level == 3 && flag3)
        {
            ddm.IsDraggingValid = false;
            flag3 = false;
            Clue3.SetActive(false);
            StartCoroutine(BeherTankAnimation());
        }

        if (ddm.Level == 4 && flag4)
        {
            flag4 = false;
            Clue4.SetActive(false);
            Tank_Cap.transform.position = Tank.transform.position;
            Tank.SetActive(false);
            Cap.SetActive(false);
            Tank_Cap.SetActive(true);
            Clue5.SetActive(true);
        }

        if (ddm.Level == 5 && flag5)
        {
            ddm.IsDraggingValid = false;
            flag5 = false;
            Clue9.SetActive(false);
            StartCoroutine(EmptyDeveloper());
        }

        if (ddm.Level == 6 && flag6)
        {
            ddm.IsDraggingValid = false;
            flag6 = false;
            Clue10.SetActive(false);
            StartCoroutine(TankFaucet());
        }
    }

    // Coroutines
    private IEnumerator DeveloperAnimation()
    {
        Developer.transform.DOKill();
        Developer.transform.DOMove(DeveloperPos.transform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Developer.transform.DORotate(DeveloperPos.transform.rotation.eulerAngles, 1f).SetEase(Ease.OutQuad)
            );
        yield return new WaitForSeconds(4f);
        Beher.SetActive(false);
        Beher_Half.SetActive(true);

        Developer.transform.DOKill();

        Developer.transform.DORotate(DeveloperDefaultPos.transform.rotation.eulerAngles, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Developer.transform.DOMove(DeveloperDefaultPos.transform.position, 1f)
            );
        yield return new WaitForSeconds(2f);

        ddm.IsDraggingValid = true;
        Clue2.SetActive(true);
    }

    private IEnumerator BeherAnimation()
    {
        Beher_Half.transform.DOKill();
        Beher_Half.transform.DOMove(BeherCheckpointPos.transform.position, 0.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Beher_Half.transform.DOMove(BeherFaucetPoint.transform.position, 1f)
            );
        yield return new WaitForSeconds(4f);
        Beher_Half.SetActive(false);
        Beher_Full.SetActive(true);

        Beher_Full.transform.DOKill();
        Beher_Full.transform.DOMove(BeherCheckpointPos.transform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Beher_Full.transform.DOMove(BeherDefaultPos.transform.position, 0.5f)
            );
        yield return new WaitForSeconds(2f);
        
        ddm.IsDraggingValid = true;
        Clue3.SetActive(true);
    }

    private IEnumerator BeherTankAnimation() {
        Developer.transform.DOKill();
        Developer.transform.DOMove(DeveloperSecondPos.transform.position, 0.5f).SetEase(Ease.OutQuad);

        Tank.transform.DOKill();
        Tank.transform.DOMove(DeveloperDefaultPos.transform.position, 1f).SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(1.2f);

        Beher_Full.transform.DOKill();
        Beher_Full.transform.DOMove(BeherTankPos.transform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Beher_Full.transform.DORotate(BeherTankPos.transform.rotation.eulerAngles, 0.75f).SetEase(Ease.OutQuad)
            );

        yield return new WaitForSeconds(4f);
        Beher.transform.position = Beher_Full.transform.position;
        Beher.transform.rotation = Beher_Full.transform.rotation;

        Beher_Full.SetActive(false);
        Beher.SetActive(true);

        Beher.transform.DOKill();
        Beher.transform.DORotate(BeherDefaultPos.transform.rotation.eulerAngles, 0.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => Beher.transform.DOMove(BeherDefaultPos.transform.position, 1f));

        ddm.IsDraggingValid = true;
        Clue4.SetActive(true);
    }


    private IEnumerator EmptyDeveloper() {
        Tank.transform.DOKill();
        Tank.transform.DOMove(TankToDeveloperPos_Tank.transform.position, 1.2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Tank.transform.DORotate(TankToDeveloperPos_Tank.transform.rotation.eulerAngles, 0.75f).SetEase(Ease.OutQuad)
            );
        
        Developer.transform.DOKill();
        Developer.transform.DOMove(TankToDeveloperPos_Developer.transform.position, 1f)
            .SetEase(Ease.OutQuad);
        
        yield return new WaitForSeconds(4f);

        Developer.transform.DOKill();
        Developer.transform.DOMove(DeveloperSecondPos.transform.position, 1f)
            .SetEase(Ease.OutQuad);

        Tank.transform.DOKill();
        Tank.transform.DORotate(Tank_Cap.transform.rotation.eulerAngles, 0.75f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Tank.transform.DOMove(Tank_Cap.transform.position, 1f).SetEase(Ease.OutQuad)
            );
        
        yield return new WaitForSeconds(1f);

        ddm.IsDraggingValid = true;
        Clue10.SetActive(true);
    }


    private IEnumerator TankFaucet() {
        ButtonsPanel2.SetActive(true);
        Shake2.GetComponent<Button>().interactable = false;
        PourButton.GetComponent<Button>().interactable = false;

        Tank.transform.DOKill();
        Tank.transform.DOMove(TankFaucetPos1.transform.position, 1.2f)
            .SetEase(Ease.OutQuad);
        
        yield return new WaitForSeconds(1.5f);
        Clue11.SetActive(true);

        yield return new WaitForSeconds(2f);
        Tank.transform.DOKill();
        Tank.transform.DOMove(TankFaucetPos2.transform.position, 0.75f)
            .SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(1f);
        Shake2.GetComponent<Button>().interactable = true;

        
    }





    public void Film_Spiral_InfoUI_Btn() {
        Film_Spiral_InfoUI.SetActive(false);
        Film_Spiral_ExperimentInfo.SetActive(true);
    }
    public void Film_Spiral_ExperimentInfo_Btn() {
        Film_Spiral_ExperimentInfo.SetActive(false);
        Experiment.SetActive(true);
        Clue1.SetActive(true);
    }

    public void Clue5_Btn() {
        Clue5.SetActive(false);
        Experiment.SetActive(false);
        ButtonsPanel.SetActive(true);
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
