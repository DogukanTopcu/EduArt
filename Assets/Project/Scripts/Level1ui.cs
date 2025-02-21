using UnityEngine;
using DG.Tweening;

public class Level1ui : MonoBehaviour
{
    private GameObject filmRollUI;
    private GameObject filmRollInfoUI;

    private GameObject TankUI;
    private GameObject TankObjectInfoUI;
    private GameObject TankSpiralInfoUI;
    private GameObject CylinderInfoUI;

    private GameObject ChemicalsUI;
    private GameObject DeveloperUI;
    private GameObject FixerUI;
    private GameObject BeherUI;


    // Objects

    // Film Roll
    private GameObject roll;
    private Transform defaultRollPos;
    private Vector3 defaultRollRot;
    private Transform rollInfoTransform;
    private GameObject film;
    private Transform defaultFilmPos;
    private Transform filmInfoTransform;


    // Tank
    private GameObject tank;
    private Transform defaultTankPos;
    private Transform tankInfoTransform;

    private GameObject tankSpiral;
    private Transform defaultTankSpiralPos;
    private Transform tankSpiralInfoTransform;

    private GameObject cylinder;
    private Transform defaultCylinderPos;
    private Transform cylinderInfoTransform;

    private GameObject huni;
    private Transform defaultHuniPos;
    private Transform huniInfoTransform;


    // CHEMICALS
    private GameObject developer;
    private Transform defaultDeveloperPos;
    private Vector3 defaultDeveloperRot;
    private Transform developerInfoTransform;

    private GameObject fixer;
    private Transform defaultFixerPos;
    private Vector3 defaultFixerRot;
    private Transform fixerInfoTransform;

    private GameObject beher;
    private Transform defaultBeherPos;
    private Transform beherInfoTransform;


    void Start()
    {
        // Roll
        roll = GameObject.Find("Roll01");
        defaultRollPos = GameObject.Find("Roll01DefaultPos").transform;
        defaultRollRot = new Vector3(roll.transform.rotation.x, roll.transform.rotation.y, roll.transform.rotation.z);
        rollInfoTransform = GameObject.Find("Roll01InfoPoint").transform;
        filmRollUI = FindInActiveObjectByName("RollUI");
        filmRollInfoUI = FindInActiveObjectByName("RollInfoUI");

        film = GameObject.Find("Film");
        defaultFilmPos = GameObject.Find("filmDefaultPos").transform;
        filmInfoTransform = GameObject.Find("filmInfoPoint").transform;

        // Tank
        TankUI = FindInActiveObjectByName("TankUI");
        TankObjectInfoUI = FindInActiveObjectByName("TankInfoUI");
        TankSpiralInfoUI = FindInActiveObjectByName("TankSpiralInfoUI");
        CylinderInfoUI = FindInActiveObjectByName("CylinderInfoUI");

        tank = GameObject.Find("SM_Tank");
        defaultTankPos = GameObject.Find("tankDefaultPos").transform;
        tankInfoTransform = GameObject.Find("tankInfoPoint").transform;

        tankSpiral = GameObject.Find("SM_Tank_Spiral");
        defaultTankSpiralPos = GameObject.Find("tankSpiralDefaultPos").transform;
        tankSpiralInfoTransform = GameObject.Find("tankSpiralInfoPoint").transform;

        cylinder = GameObject.Find("SM_Tank_Cylinder_Bottom");
        defaultCylinderPos = GameObject.Find("tankCylinderBottomDefaultPos").transform;
        cylinderInfoTransform = GameObject.Find("tankCylinderBottomInfoPoint").transform;

        huni = GameObject.Find("SM_Tank_Cylinder_Top");
        defaultHuniPos = GameObject.Find("tankCylinderTopDefaultPos").transform;
        huniInfoTransform = GameObject.Find("tankCylinderTopInfoPoint").transform;

        // CHEMICALS
        ChemicalsUI = FindInActiveObjectByName("ChemicalsUI");
        DeveloperUI = FindInActiveObjectByName("DeveloperUI");
        FixerUI = FindInActiveObjectByName("FixerUI");
        BeherUI = FindInActiveObjectByName("BeherUI");

        developer = GameObject.Find("Developer");
        defaultDeveloperPos = GameObject.Find("developerDefaultPos").transform;
        defaultDeveloperRot = new Vector3(developer.transform.rotation.x, developer.transform.rotation.y, developer.transform.rotation.z);
        developerInfoTransform = GameObject.Find("developerInfoPoint").transform;

        fixer = GameObject.Find("Fixer");
        defaultFixerPos = GameObject.Find("fixerDefaultPos").transform;
        defaultFixerRot = new Vector3(fixer.transform.rotation.x, fixer.transform.rotation.y, fixer.transform.rotation.z);
        fixerInfoTransform = GameObject.Find("fixerInfoPoint").transform;

        beher = GameObject.Find("Beher");
        defaultBeherPos = GameObject.Find("beherDefaultPos").transform;
        beherInfoTransform = GameObject.Find("beherInfoPoint").transform;
    }


    public void showFilmRollUI()
    {
        filmRollUI.SetActive(false);
        filmRollInfoUI.SetActive(true);

        roll.transform.DOMove(rollInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                roll.transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            });

        film.transform.DOMove(filmInfoTransform.position, 1f)
        .SetEase(Ease.OutQuad)
        .OnComplete(() =>
        {
            // İlk rotasyona geçiş (hedef rotasyonun Euler açıları ile)
            film.transform.DORotate(filmInfoTransform.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    // Kendi ekseni etrafında sürekli dönme
                    film.transform.DORotate(new Vector3(360, 0, 0), 5f, RotateMode.LocalAxisAdd)
                        .SetEase(Ease.Linear)
                        .SetLoops(-1, LoopType.Restart);
                });
        });

    }

    public void moveTankSpiral() {
        roll.transform.DOKill();
        film.transform.DOKill();

        filmRollInfoUI.SetActive(false);

        roll.transform.DOMove(defaultRollPos.position, 1f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                roll.transform.DORotate(defaultRollPos.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear);
            });
        
        film.transform.DORotate(defaultFilmPos.rotation.eulerAngles, .1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                film.transform.DOMove(defaultFilmPos.position, 1f).SetEase(Ease.OutQuad);
            });

        
        filmRollInfoUI.SetActive(false);
        TankUI.SetActive(true);
    }

    public void showTankInfo()
    {
        TankUI.SetActive(false);
        TankObjectInfoUI.SetActive(true);

        tank.transform.DOMove(tankInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                tank.transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            });
    }

    public void showTankSpiralInfo()
    {
        tank.transform.DOKill();
        TankObjectInfoUI.SetActive(false);

        tank.transform.DOMove(defaultTankPos.position, 1f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                tank.transform.DORotate(defaultTankPos.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear);
            });

        tankSpiral.transform.DOMove(tankSpiralInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                tankSpiral.transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            });

        TankSpiralInfoUI.SetActive(true);
    }

    public void showCylinderInfo()
    {
        tankSpiral.transform.DOKill();
        TankSpiralInfoUI.SetActive(false);

        tankSpiral.transform.DOMove(defaultTankSpiralPos.position, 1f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                tankSpiral.transform.DORotate(defaultTankSpiralPos.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear);
            });
        
        cylinder.transform.DOMove(cylinderInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad);

        huni.transform.DOMove(huniInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad);

        CylinderInfoUI.SetActive(true);
    }

    public void moveChemicals()
    {
        cylinder.transform.DOKill();
        huni.transform.DOKill();
        CylinderInfoUI.SetActive(false);

        cylinder.transform.DOMove(defaultCylinderPos.position, 1f).SetEase(Ease.OutQuad);
        huni.transform.DOMove(defaultHuniPos.position, 1f).SetEase(Ease.OutQuad);

        ChemicalsUI.SetActive(true);
    }

    public void showDeveloperInfo()
    {
        ChemicalsUI.SetActive(false);
        DeveloperUI.SetActive(true);

        developer.transform.DOMove(developerInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                developer.transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            });
    }

    public void showFixerInfo()
    {
        developer.transform.DOKill();
        DeveloperUI.SetActive(false);

        developer.transform.DOMove(defaultDeveloperPos.position, 1f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                developer.transform.DORotate(defaultDeveloperPos.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear);
            });

        fixer.transform.DOMove(fixerInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                fixer.transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            });

        FixerUI.SetActive(true);
    }

    public void showBeherInfo()
    {
        fixer.transform.DOKill();
        FixerUI.SetActive(false);

        fixer.transform.DOMove(defaultFixerPos.position, 1f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                fixer.transform.DORotate(defaultFixerPos.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear);
            });

        beher.transform.DOMove(beherInfoTransform.position, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                beher.transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            });

        BeherUI.SetActive(true);
    }


    public void Finish() {
        beher.transform.DOKill();
        BeherUI.SetActive(false);

        beher.transform.DOMove(defaultBeherPos.position, 1f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                beher.transform.DORotate(defaultBeherPos.rotation.eulerAngles, 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear);
            });
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
