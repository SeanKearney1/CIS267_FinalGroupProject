using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    //==PUBLIC==//
    [Header("--Level Select--")]
    [Header("1 = Elven, 2 = Dwarven, 3 = Orc")]
    [Range(1, 3)]
    public int level;

    //==PRIVATE==//
    private GameObject popUpWindow;
    private Button yesBtn;
    private Button noBtn;

    private void Start()
    {
        popUpWindow = gameObject.transform.GetChild(0).gameObject;
        GameObject pUPBackground = popUpWindow.transform.GetChild(0).gameObject;
        yesBtn = pUPBackground.transform.GetChild(3).GetComponent<Button>();
        noBtn = pUPBackground.transform.GetChild(4).GetComponent<Button>();
        yesBtn.onClick.AddListener(yesButtonClick);
        noBtn.onClick.AddListener(noButtonClick);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doubleCheckPlayerChoice();
        }
    }
    private void doubleCheckPlayerChoice()
    {
        popUpWindow.SetActive(true);
        Time.timeScale = 0f;
    }
    public void yesButtonClick()
    {
        SceneManager.LoadScene(level);
    }
    public void noButtonClick()
    {
        popUpWindow.SetActive(false);
        Time.timeScale = 1f;
    }
}
