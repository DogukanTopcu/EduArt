using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Compression;

public class QuizManager_Negative : MonoBehaviour
{
    private List<Question> questions;
    private Question currentQuestion;

    private int totalQuestions = 10;
    private int currentQuestionIndex = 0;
    private int totalQuestionsAnswered = 0;
    
    private string selectedOption;
    private GameObject selectedObject;

    private GameObject QuestionPanel;
    private GameObject A1;
    private GameObject A2;
    private GameObject A3;
    private GameObject A4;
    private GameObject AnswerAndNextButton;
    private GameObject CorrectSign;
    private GameObject WrongSign;

    // Sprites
    public Sprite SelectedButtonSprite; 
    public Sprite NormalButtonSprite;


    // Colors
    private Color CorrectColor = new Color(157f / 255f, 233f / 255f, 98f / 255f, 1f);
    private Color WrongColor = new Color(234f / 255f, 98f / 255f, 98f / 255f, 1f);



    void Start()
    {
        Question q1 = new Question(
            question: "Karanlık odada filmi rulodan çıkarırken ışık seviyesi ne kadar olmalıdır?",
            answer1: "Yüksek ışık seviyesi",
            answer2: "Düşük ışık seviyesi",
            answer3: "Orta seviyede ışık",
            correctAnswer: "Işık yok"
        );

        Question q2 = new Question(
            question: "Negatif filmin karanlık odadaki yolculuğu hangi aşama ile başlar?",
            answer1: "Fixer banyosu",
            answer2: "Geliştirici banyosu",
            answer3: "Yıkama",
            correctAnswer: "Filmi makineden çıkarıp ışık geçirmez tank içine yerleştirme"
        );

        Question q3 = new Question(
            question: "Film banyosunda kullanılan birinci solüsyon nedir?",
            answer1: "Fixer",
            answer2: "Durdurma",
            answer3: "Yıkama",
            correctAnswer: "Geliştirici"
        );

        Question q4 = new Question(
            question: "İkinci banyonun amacı nedir?",
            answer1: "Filmi geliştirip pozitif görüntü elde etmek",
            answer2: "Filmin ışığa duyarlılığını artırmak",
            answer3: "Filmin kimyasal reaksiyonlarını durdurmak",
            correctAnswer: "Filmin görüntüsünü sabitlemek"
        );

        Question q5 = new Question(
            question: "Filmdeki görüntüyü sabitleyen solüsyonun adı nedir?",
            answer1: "Durdurma",
            answer2: "Yıkama",
            answer3: "Geliştirici",
            correctAnswer: "Fixer (hipo)"
        );

        Question q6 = new Question(
            question: "Film geliştirici solüsyonunun amacı nedir?",
            answer1: "Filmin görüntüsünü netleştirmek",
            answer2: "Filmin üzerine kimyasal maddeler eklemek",
            answer3: "Filmi sabitlemek",
            correctAnswer: "Film yüzeyindeki görüntüyü oluşturmak"
        );

        Question q7 = new Question(
            question: "Karanlık odada kullanılan durdurma solüsyonunun görevi nedir?",
            answer1: "Filmi yıkamak",
            answer2: "Filmi pozitif hale getirmek",
            answer3: "Filmi ışığa karşı korumak",
            correctAnswer: "Filmin üzerindeki kimyasal reaksiyonları durdurmak"
        );

        Question q8 = new Question(
            question: "Birinci banyo sıcaklığı kaç derece olmalıdır?",
            answer1: "10°C",
            answer2: "35°C",
            answer3: "40°C",
            correctAnswer: "20°C"
        );

        Question q9 = new Question(
            question: "Filmin yıkama aşamasının amacı nedir?",
            answer1: "Filmi pozitif hale getirmek",
            answer2: "Filmin üzerine baskı yapmak",
            answer3: "Filmin üzerine renk eklemek",
            correctAnswer: "Filmi kimyasal maddelerden arındırmak"
        );

        Question q10 = new Question(
            question: "Karanlık odada baskı işlemleri tamamlandıktan sonra oda nasıl bırakılmalıdır?",
            answer1: "Kimyasallar açık bırakılmalı",
            answer2: "Işıklar açık bırakılmalı",
            answer3: "Kapılar açık bırakılmalı",
            correctAnswer: "Kullanılan malzemeler temizlenip düzenlenmeli"
        );
        
        questions = new List<Question> { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10 };
        Shuffle(questions);

        QuestionPanel = FindInActiveObjectByName("Question");
        A1 = FindInActiveObjectByName("AnswerA");
        A2 = FindInActiveObjectByName("AnswerB");
        A3 = FindInActiveObjectByName("AnswerC");
        A4 = FindInActiveObjectByName("AnswerD");
        AnswerAndNextButton = FindInActiveObjectByName("Button");
        CorrectSign = FindInActiveObjectByName("correct");
        WrongSign = FindInActiveObjectByName("wrong");

        NewQuestion();
    }

    private void AnswerButton() {
        A1.GetComponent<Button>().interactable = false;
        A2.GetComponent<Button>().interactable = false;
        A3.GetComponent<Button>().interactable = false;
        A4.GetComponent<Button>().interactable = false;
        
        if (selectedOption == questions[currentQuestionIndex].CorrectAnswer)
        {
            CorrectSign.SetActive(true);
            selectedObject.GetComponent<Image>().color = CorrectColor;
            AnswerAndNextButton.GetComponent<Image>().color = CorrectColor;
            if (currentQuestionIndex + 1 >= questions.Count)
            {
                AnswerAndNextButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Mükemmel, Baskı Aşamasına Geçebilirsin!";
                if (PlayerPrefs.GetInt("Level") <= 6)
                {
                    PlayerPrefs.SetInt("Level", 7);
                }
                AnswerAndNextButton.GetComponent<Button>().onClick.RemoveAllListeners();
                AnswerAndNextButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Education"));
                return;
            }

            AnswerAndNextButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Harikasın, bir sonraki soruya geçebilirsin!";
        }
        else
        {
            WrongSign.SetActive(true);
            selectedObject.GetComponent<Image>().color = WrongColor;
            AnswerAndNextButton.GetComponent<Image>().color = WrongColor;
            AnswerAndNextButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Üzgünüm yanlış cevap, bir sonraki soruya geçebilirsin!";

            questions.Add(currentQuestion);
        }

        currentQuestionIndex++;
        AnswerAndNextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        AnswerAndNextButton.GetComponent<Button>().onClick.AddListener(NewQuestion);
    }

    private void NewQuestion() {
        A1.GetComponent<Button>().interactable = true;
        A2.GetComponent<Button>().interactable = true;
        A3.GetComponent<Button>().interactable = true;
        A4.GetComponent<Button>().interactable = true;
        AnswerAndNextButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Cevapla";

        CorrectSign.SetActive(false);
        WrongSign.SetActive(false);

        AnswerAndNextButton.GetComponent<Image>().color = Color.white;
        if (selectedObject != null) {
            selectedObject.GetComponent<Image>().color = Color.white;
            selectedObject.GetComponent<Image>().sprite = NormalButtonSprite;
            selectedObject = null;
        }
        AnswerAndNextButton.GetComponent<Button>().interactable = false;

        Debug.Log(currentQuestionIndex);
        Debug.Log(questions.Count);

        currentQuestion = questions[currentQuestionIndex];
        QuestionPanel.GetComponent<TMPro.TextMeshProUGUI>().text = questions[currentQuestionIndex].QuestionText;
        List<GameObject> options = new List<GameObject> { A1, A2, A3, A4 };
        ShuffleGameObjects(options);
        options[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = questions[currentQuestionIndex].Answer1;
        options[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = questions[currentQuestionIndex].Answer2;
        options[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = questions[currentQuestionIndex].Answer3;
        options[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = questions[currentQuestionIndex].CorrectAnswer;

        AnswerAndNextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        AnswerAndNextButton.GetComponent<Button>().onClick.AddListener(AnswerButton);
    }

    public void ButtonSelected(Button button)
    {
        A1.GetComponent<Image>().sprite = NormalButtonSprite;
        A2.GetComponent<Image>().sprite = NormalButtonSprite;
        A3.GetComponent<Image>().sprite = NormalButtonSprite;
        A4.GetComponent<Image>().sprite = NormalButtonSprite;
        button.GetComponent<Image>().sprite = SelectedButtonSprite;
        selectedOption = button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        selectedObject = button.gameObject;
        AnswerAndNextButton.GetComponent<Button>().interactable = true;
    }


    public void Shuffle(List<Question> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Question value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public void ShuffleGameObjects(List<GameObject> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void GoBackFunction () {
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
