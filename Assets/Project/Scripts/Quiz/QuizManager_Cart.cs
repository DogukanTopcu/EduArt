using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager_Cart : MonoBehaviour
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
            question: "Karanlık odada negatiften pozitif görüntü elde etmek için hangi araç kullanılır?",
            answer1: "Tarayıcı",
            answer2: "Işık kutusu",
            answer3: "Tripod",
            correctAnswer: "Agrandizör (büyütücü)"
        );

        Question q2 = new Question(
            question: "Fotoğraf kağıdı ışığa duyarlı olduğu için hangi ışık altında çalışılır?",
            answer1: "Güneş ışığı",
            answer2: "Mavi LED ışık",
            answer3: "Floresan beyaz ışık",
            correctAnswer: "Kırmızı ya da kehribar emniyet ışığı"
        );

        Question q3 = new Question(
            question: "Pozlandırma süresi neye göre belirlenir?",
            answer1: "Kağıdın boyutuna göre",
            answer2: "Karanlık oda büyüklüğüne göre",
            answer3: "Kullanılan kimyasalın markasına göre",
            correctAnswer: "Negatifin yoğunluğuna ve agrandizör ışığına göre"
        );

        Question q4 = new Question(
            question: "⁠Pozlandırılmış fotoğraf kağıdı ilk olarak hangi banyoya girer?",
            answer1: "Stop Bath",
            answer2: "Fixer",
            answer3: "Yıkama",
            correctAnswer: "Developer (Geliştirici)"
        );

        Question q5 = new Question(
            question: "Baskı sürecinde kullanılan geliştirici solüsyonun amacı nedir?",
            answer1: "Kağıdı ışığa duyarsız hale getirmek",
            answer2: "Renkli baskı yapmak",
            answer3: "Kimyasalı durdurmak",
            correctAnswer: "Görüntüyü görünür hâle getirmek"
        );

        Question q6 = new Question(
            question: "Pozlandırma sonrası ikinci aşama olan durdurma banyosunun amacı nedir?",
            answer1: "Gelişen görüntüyü keskinleştirmek",
            answer2: "Kağıdı yumuşatmak",
            answer3: "Renk doygunluğunu artırmak",
            correctAnswer: "Geliştirici etkisini durdurmak"
        );

        Question q7 = new Question(
            question: "Üçüncü aşama olan sabitleyici (fixer) banyo ne işe yarar?",
            answer1: "Görüntüyü negatif hale getirir",
            answer2: "Renk düzeltmesi yapar",
            answer3: "Baskıdaki tozları temizler",
            correctAnswer: "Kağıdı ışığa duyarsızlaştırarak kalıcı hale getirir"
        );

        Question q8 = new Question(
            question: "Baskı işlemi tamamlandıktan sonra fotoğraf kağıdı ne kadar süreyle yıkanmalıdır?",
            answer1: "1-2 dakika",
            answer2: "5-10 saniye",
            answer3: "Yıkanmaz, doğrudan kurutulur",
            correctAnswer: "10-20 dakika"
        );

        Question q9 = new Question(
            question: "Baskı sonrası kurutma işlemi nasıl yapılır?",
            answer1: "Saç kurutma makinesi ile",
            answer2: "Direkt güneş ışığına bırakılarak",
            answer3: "Karanlık oda zeminine serilerek",
            correctAnswer: "Kurutma askısına asılarak doğal şekilde"
        );

        Question q10 = new Question(
            question: "Baskı işlemi sırasında doğru ton ve kontrastı elde etmek için hangi yöntem kullanılır?",
            answer1: "Kağıdı suya batırmak",
            answer2: "Oda sıcaklığını artırmak",
            answer3: "Kimyasal oranlarını azaltmak",
            correctAnswer: "Agrandizörde filtre kullanmak"
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
