using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EduButtonManager : MonoBehaviour
{
    private Button backButton;

    private GameObject Level1;
    private GameObject Level2;
    private GameObject Level3;
    private GameObject Level4;
    private GameObject Level5;
    private GameObject Quiz;
    private GameObject Level6;
    private GameObject Level7;
    private GameObject Level8;
    private GameObject Quiz2;

    [SerializeField]
    private int level;
    public Sprite OpenedLevelSprite;

    private void Awake() {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("Level", level);
        }
    }

    private void Start() {
        backButton = GameObject.Find("BackBtn").GetComponent<Button>();
        backButton.onClick.AddListener(BackBtn);

        Level1 = GameObject.Find("Level1");
        Level2 = GameObject.Find("Level2");
        Level3 = GameObject.Find("Level3");
        Level4 = GameObject.Find("Level4");
        Level5 = GameObject.Find("Level5");
        Quiz = GameObject.Find("Level6");
        Level6 = GameObject.Find("Level7");
        Level7 = GameObject.Find("Level8");
        Level8 = GameObject.Find("Level9");
        Quiz2 = GameObject.Find("Level10");

        if (level >= 0)
        {
            Level1.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 1";
            Level1.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level1.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 1"));
        }

        if (level > 1)
        {
            Level2.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 2";
            Level2.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level2.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 2"));
        }

        if (level > 2)
        {
            Level3.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level3.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 3";
            Level3.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level3.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 3"));
        }

        if (level > 3)
        {
            Level4.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level4.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 4";
            Level4.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level4.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 4"));
        }

        if (level > 4)
        {
            Level5.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level5.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 5";
            Level5.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level5.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 5"));
        }

        if (level > 5)
        {
            Quiz.GetComponent<Image>().color = Color.white;
            Quiz.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Quiz.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 6"));
        }

        if (level > 6)
        {
            Level6.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level6.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 6";
            Level6.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level6.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 7"));
        }

        if (level > 7)
        {
            Level7.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level7.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 7";
            Level7.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level7.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 8"));
        }

        if (level > 8)
        {
            Level8.GetComponent<Image>().sprite = OpenedLevelSprite;
            Level8.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seviye 8";
            Level8.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            Level8.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 9"));
        }

        if (level > 9)
        {
            Quiz2.GetComponent<Image>().color = Color.white;
            Quiz2.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            // Quiz2.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Level 9"));
        }
    }

    private void Update() {
        
    }

    public void BackBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Level1Btn()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2Btn()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3Btn()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Level4Btn()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void Level5Btn()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void QuizBtn()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void Level6Btn()
    {
        SceneManager.LoadScene("Level 6");
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
