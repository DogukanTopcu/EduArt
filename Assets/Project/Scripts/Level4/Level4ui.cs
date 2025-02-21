using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level4ui : MonoBehaviour
{

    public L4_DragDropManager ddm;

    // Flags
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
    private GameObject Fixer;
    private GameObject Tank;
    private GameObject Cap;
    private GameObject Tank_Cap;


    // Positions
    private GameObject FixerDefaultPos;
    private GameObject FixerPos;
    private GameObject BeherCheckpointPos;
    private GameObject BeherFaucetPoint;
    private GameObject BeherDefaultPos;
    private GameObject FixerSecondPos;
    private GameObject TankFixerPos;
    private GameObject BeherTankPos;
    private GameObject TankToFixerPos_Tank;
    private GameObject TankToFixerPos_Fixer;
    private GameObject TankFaucetPos1;
    private GameObject TankFaucetPos2;



    void Start()
    {
        ddm = FindInActiveObjectByName("DragDropManager").GetComponent<L4_DragDropManager>();

        Film_Spiral_InfoUI = FindInActiveObjectByName("Film_Spiral_InfoUI");
        Film_Spiral_ExperimentInfo = FindInActiveObjectByName("Film_Spiral_ExperimentInfo");
        Experiment = FindInActiveObjectByName("Experiment");
        
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
        Fixer = FindInActiveObjectByName("Fixer");
        Tank = FindInActiveObjectByName("FilmTank");
        Cap = FindInActiveObjectByName("SM_Tank_Cap");
        Tank_Cap = FindInActiveObjectByName("FilmTank_Cap");

        FixerDefaultPos = FindInActiveObjectByName("FixerDefaultPos");
        FixerPos = FindInActiveObjectByName("FixerPos");
        BeherCheckpointPos = FindInActiveObjectByName("BeherCheckpointPos");
        BeherFaucetPoint = FindInActiveObjectByName("BeherFaucetPos");
        BeherDefaultPos = FindInActiveObjectByName("BeherDefaultPos");
        FixerSecondPos = FindInActiveObjectByName("FixerSecondPos");
        TankFixerPos = FindInActiveObjectByName("TankFixerPos");
        BeherTankPos = FindInActiveObjectByName("BeherTankPos");

        TankToFixerPos_Tank = FindInActiveObjectByName("TankToFixerPos_Tank");
        TankToFixerPos_Fixer = FindInActiveObjectByName("TankToFixerPos_Fixer");
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
            StartCoroutine(FixerAnimation());
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
            StartCoroutine(EmptyFixer());
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
    private IEnumerator FixerAnimation()
    {
        Fixer.transform.DOKill();
        Fixer.transform.DOMove(FixerPos.transform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Fixer.transform.DORotate(FixerPos.transform.rotation.eulerAngles, 1f).SetEase(Ease.OutQuad)
            );
        yield return new WaitForSeconds(4f);
        Beher.SetActive(false);
        Beher_Half.SetActive(true);

        Fixer.transform.DOKill();

        Fixer.transform.DORotate(FixerDefaultPos.transform.rotation.eulerAngles, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Fixer.transform.DOMove(FixerDefaultPos.transform.position, 1f)
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
        Fixer.transform.DOKill();
        Fixer.transform.DOMove(FixerSecondPos.transform.position, 0.5f).SetEase(Ease.OutQuad);

        Tank.transform.DOKill();
        Tank.transform.DOMove(TankFixerPos.transform.position, 1f).SetEase(Ease.OutQuad);

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


    private IEnumerator EmptyFixer() {
        Tank.transform.DOKill();
        Tank.transform.DOMove(TankToFixerPos_Tank.transform.position, 1.2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => 
                Tank.transform.DORotate(TankToFixerPos_Tank.transform.rotation.eulerAngles, 0.75f).SetEase(Ease.OutQuad)
            );
        
        Fixer.transform.DOKill();
        Fixer.transform.DOMove(TankToFixerPos_Fixer.transform.position, 1f)
            .SetEase(Ease.OutQuad);
        
        yield return new WaitForSeconds(4f);

        Fixer.transform.DOKill();
        Fixer.transform.DOMove(FixerSecondPos.transform.position, 1f)
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

        Tank.transform.DOKill();
        Tank.transform.DOMove(TankFaucetPos1.transform.position, 1.2f)
            .SetEase(Ease.OutQuad);
        
        yield return new WaitForSeconds(4f);
        Clue11.SetActive(true);
        
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
