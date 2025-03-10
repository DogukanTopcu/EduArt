using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;

public class L4_Shaker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject Clue6;
    private GameObject Clue7;
    private GameObject Clue8;
    private GameObject Clue11;
    private GameObject Clue12;
    private GameObject NextButton;
    private GameObject Tank;
    private GameObject HitButton;
    private GameObject PourButton;
    private GameObject TankInitial;

    private int hitNumber = 0;
    private int totalShake = 0;
    private int totalPour = 0;

    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private bool isShaker1 = true;


    public L4_DragDropManager ddm;

    private GameObject TankFaucetPos1;
    private GameObject TankFaucetPos2;
    private GameObject ShakingPos;


    private float timer = 0f;
    private bool isShaking = false;
    private bool timerComplete = false;

    public ARTemplateMenuManager menuManager;

    private GameObject shakingObject;
    private GameObject textTimer;


    void Start()
    {
        HitButton = FindInActiveObjectByName("Hit");
        PourButton = FindInActiveObjectByName("PourButton");
        Clue6 = FindInActiveObjectByName("Clue6");
        Clue7 = FindInActiveObjectByName("Clue7");
        Clue8 = FindInActiveObjectByName("Clue8");
        Clue11 = FindInActiveObjectByName("Clue11");
        Clue12 = FindInActiveObjectByName("Clue12");
        NextButton = FindInActiveObjectByName("NextButton");

        isShaker1 = this.transform.parent.name == "ButtonsPanel";

        textTimer = FindInActiveObjectByName("timer");
    }

    private void Update() {
        if (menuManager.IsStarted && flag3)
        {
            Tank = FindInActiveObjectByName("FilmTank_Cap");
            TankInitial = FindInActiveObjectByName("FilmTank");
            TankFaucetPos1 = FindInActiveObjectByName("TankFaucetPos1");
            TankFaucetPos2 = FindInActiveObjectByName("TankFaucetPos2");
            ShakingPos = FindInActiveObjectByName("ShakingPos");

            shakingObject = Tank;
            flag3 = false;
        }
    }

    void FixedUpdate()
    {
        if (isShaking && !timerComplete)
        {
            timer += Time.deltaTime;

            if (timer >= 5f)
            {
                timerComplete = true;
                isShaking = false;

                HitButton.GetComponent<Button>().interactable = true;
                PourButton.GetComponent<Button>().interactable = true;
                this.GetComponent<Button>().interactable = false;
            }
            else
            {
                textTimer.GetComponent<TextMeshProUGUI>().text = (5f - timer).ToString("F1");
            }
        }

        if (timerComplete && totalShake == 0 && isShaker1)
        {
            Clue6.SetActive(false);
            Clue7.SetActive(true);
        }

        if (totalShake >= 1f)
        {
            Clue7.SetActive(false);
        }

        if (totalShake == 2f && flag1)
        {
            flag1 = false;
            Clue8.SetActive(true);
            NextButton.SetActive(true);
        }

        if (totalShake == 3f)
        {
            Clue8.SetActive(false);
        }

        if (totalShake >= 20f)
        {
            ddm.CompleteShake();
        }

        if (totalPour == 1)
        {
            Clue11.SetActive(false);
        }
    }


    private bool first = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.GetComponent<Button>().interactable == false) return;

        textTimer.SetActive(true);

        if (ddm.Level >= 5 && flag2)
        {
            TankInitial.transform.DOKill();
            TankInitial.transform.DOMove(TankFaucetPos2.transform.position, 0.5f)
                .SetEase(Ease.InOutSine);

            shakingObject = TankInitial;
            first = true;
            flag2 = false;
        }
        if (!timerComplete)
        {
            if (first)
            {
                shakingObject.transform.DOKill();
                shakingObject.transform.DOMoveY(shakingObject.transform.position.y + 0.1f, 0.1f)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
                first = false;
            }
            else {
                shakingObject.transform.DOPlay();
            }

            isShaking = true;
        }
        else
        {
            shakingObject.transform.DOKill();
            HitButton.GetComponent<Button>().interactable = true;
            this.GetComponent<Button>().interactable = false;
            PourButton.GetComponent<Button>().interactable = true;
            isShaking = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textTimer.SetActive(false);

        shakingObject.transform.DOPause();
        isShaking = false;
    }



    public void HitBtn() {
        if (hitNumber < 3)
        {
            Vector3 tempPos = new Vector3(Tank.transform.position.x,Tank.transform.position.y,Tank.transform.position.z);
            Tank.transform.DOKill();
            Tank.transform.DOMoveY(TankInitial.transform.position.y, 0.05f)
                .OnComplete(() => Tank.transform.DOMove(ShakingPos.transform.position, 0.15f));
            hitNumber++;

            if (hitNumber == 3)
            {
                HitButton.GetComponent<Button>().interactable = false;
                this.GetComponent<Button>().interactable = true;
                hitNumber = 0;
                timer = 0;
                timerComplete = false;
                first = true;

                totalShake++;
            }
        }
        else {
            HitButton.GetComponent<Button>().interactable = false;
            this.GetComponent<Button>().interactable = true;
            hitNumber = 0;
            timer = 0;
            timerComplete = false;
            first = true;

            totalShake++;
        }
    }


    public void PourBtn() {
        flag2 = true;
        timerComplete = false;
        timer = 0;
        first = true;
        PourButton.GetComponent<Button>().interactable = false;
        
        totalPour++;

        StartCoroutine(NextStep());
    }

    private IEnumerator NextStep() {
        TankInitial.transform.DOKill();
        TankInitial.transform.DORotate(new Vector3(180f, 0f, 0f), 0.5f)
            .OnComplete(() => 
                TankInitial.transform.DORotate(Vector3.zero, 0.5f)
            );

        yield return new WaitForSeconds(1.5f);

        if (totalPour == 3)
        {
            TankInitial.transform.DOKill();
            TankInitial.transform.DOMove(Tank.transform.position, 1f)
                .SetEase(Ease.InOutSine);
            
            yield return new WaitForSeconds(1.2f);

            Clue12.SetActive(true);
            this.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            TankInitial.transform.DOKill();
            TankInitial.transform.DOMove(TankFaucetPos1.transform.position, 0.5f)
                .SetEase(Ease.InOutSine);

            Clue11.SetActive(false);
            yield return new WaitForSeconds(2.5f);
            TankInitial.transform.DOKill();
            TankInitial.transform.DOMove(TankFaucetPos2.transform.position, 0.75f)
                .SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(1f);
            this.GetComponent<Button>().interactable = true;
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
