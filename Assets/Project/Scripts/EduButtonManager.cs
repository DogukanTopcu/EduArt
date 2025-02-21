using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EduButtonManager : MonoBehaviour
{
    private Button backButton;
    private void Start() {
        backButton = GameObject.Find("BackBtn").GetComponent<Button>();
        backButton.onClick.AddListener(BackBtn);
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
}
