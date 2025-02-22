public class Question
{
    private string questionText;
    private string answer1;
    private string answer2;
    private string answer3;
    private string correctAnswer;

    private bool answered;
    private bool answeredCorrectly;

    public Question(string question, string answer1, string answer2, string answer3, string correctAnswer)
    {
        this.questionText = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.correctAnswer = correctAnswer;

        answered = false;
        answeredCorrectly = false;
    }

    public string QuestionText {
        get { return questionText; }
        set { questionText = value; }
    }
    public string Answer1
    {
        get { return answer1; }
        set { answer1 = value; }
    }

    public string Answer2
    {
        get { return answer2; }
        set { answer2 = value; }
    }

    public string Answer3
    {
        get { return answer3; }
        set { answer3 = value; }
    }

    public string CorrectAnswer
    {
        get { return correctAnswer; }
        set { correctAnswer = value; }
    }

    public bool Answered
    {
        get { return answered; }
        set { answered = value; }
    }

    public bool AnsweredCorrectly
    {
        get { return answeredCorrectly; }
        set { answeredCorrectly = value; }
    }
}
