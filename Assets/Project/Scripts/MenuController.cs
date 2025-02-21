using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AnimatedObjects[] _objects;
    private GameObject aboutPanel;
    private GameObject mainPanel;

    void Awake()
    {
        aboutPanel = GameObject.Find("About");
        if (aboutPanel == null) aboutPanel = FindInActiveObjectByName("About");
        mainPanel = GameObject.Find("Main");
        if (mainPanel == null) mainPanel = FindInActiveObjectByName("Main");

        mainPanel.SetActive(true);
        aboutPanel.SetActive(false);

        _objects = new AnimatedObjects[5];
        
        GameObject enlarger = GameObject.Find("SM_Enlarger");
        AnimatedObjects enlargerObj = new AnimatedObjects(
            "Enlarger",
            enlarger,
            enlarger.GetComponent<Animator>(),
            "Enterence_Enlarger",
            "Exit_Enlarger",
            "Movement_Enlarger"
        );
        _objects[0] = enlargerObj;

        GameObject paper = GameObject.Find("PaperObj");
        AnimatedObjects paperObj = new AnimatedObjects(
            "Paper Object",
            paper,
            paper.GetComponent<Animator>(),
            "Enterence_PaperObj",
            "Exit_PaperObj",
            "Movement_PaperObj"
        );
        _objects[1] = paperObj;

        GameObject roll = GameObject.Find("SM_Roll_01");
        AnimatedObjects rollObj = new AnimatedObjects(
            "Roll",
            roll,
            roll.GetComponent<Animator>(),
            "Enterence_Roll01",
            "Exit_Roll01",
            "Movement_Roll01"
        );
        _objects[2] = rollObj;

        GameObject timeolite = GameObject.Find("TimeoliteObj");
        AnimatedObjects timeoliteObj = new AnimatedObjects(
            "Timeolite",
            timeolite,
            timeolite.GetComponent<Animator>(),
            "Enterence_TimeoliteObj",
            "Exit_TimeoliteObj",
            "Movement_TimeoliteObj"
        );
        _objects[3] = timeoliteObj;

        GameObject metalspiral = GameObject.Find("SM_MetalSpiral");
        AnimatedObjects metalspiralObj = new AnimatedObjects(
            "Metal Spiral",
            metalspiral,
            metalspiral.GetComponent<Animator>(),
            "Enterence_MetalSpiral",
            "Exit_MetalSpiral",
            "Movement_MetalSpiral"
        );
        _objects[4] = metalspiralObj;
    }
    
    void Start()
    {
        _objects[0].Object.SetActive(true);
        _objects[0].IsPlaying = true;
        _objects[1].Object.SetActive(false);
        _objects[2].Object.SetActive(false);
        _objects[3].Object.SetActive(false);
        _objects[4].Object.SetActive(false);
    }

    
    void Update()
    {
        if (_objects[0].IsPlaying && _objects[0].Animator.GetCurrentAnimatorStateInfo(0).IsName(_objects[0].ExitAnimationName))
        {
            StartCoroutine(WaitAndChangeObject(0, 1, 0.35f));
        }
        else if (_objects[1].IsPlaying && _objects[1].Animator.GetCurrentAnimatorStateInfo(0).IsName(_objects[1].ExitAnimationName))
        {
            StartCoroutine(WaitAndChangeObject(1, 2, 1f));
        }
        else if (_objects[2].IsPlaying && _objects[2].Animator.GetCurrentAnimatorStateInfo(0).IsName(_objects[2].ExitAnimationName))
        {
            StartCoroutine(WaitAndChangeObject(2, 3, 0.5f));
        }
        else if (_objects[3].IsPlaying && _objects[3].Animator.GetCurrentAnimatorStateInfo(0).IsName(_objects[3].ExitAnimationName))
        {
            StartCoroutine(WaitAndChangeObject(3, 4, 2f));
        }
        else if (_objects[4].IsPlaying && _objects[4].Animator.GetCurrentAnimatorStateInfo(0).IsName(_objects[4].ExitAnimationName))
        {
            StartCoroutine(WaitAndChangeObject(4, 0, 3.3f));
        }
    }


    IEnumerator WaitAndChangeObject(int index, int nextIndex, float time)
    {
        yield return new WaitForSeconds(time);
        _objects[index].Object.SetActive(false);
        _objects[index].IsPlaying = false;
        _objects[nextIndex].Object.SetActive(true);
        _objects[nextIndex].IsPlaying = true;
    }


    public void EducationBtn()
    {
        SceneManager.LoadScene("Education");
    }

    public void PlaygroundBtn()
    {
        SceneManager.LoadScene("Playground");
    }

    public void AboutBtn()
    {
        mainPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void BackBtn()
    {
        aboutPanel.SetActive(false);
        mainPanel.SetActive(true);
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
