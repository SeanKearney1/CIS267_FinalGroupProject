using TMPro;
using UnityEngine;

public class InfoSignDisplay : MonoBehaviour
{
    //==PUBLIC==//
    [TextArea(3, 8)]
    public string signInfo;

    //==PRIVATE==//
    private GameObject infoDisplayCanvas;
    private TMP_Text infoDisplayTxt;

    void Start()
    {
        infoDisplayCanvas = gameObject.transform.GetChild(0).gameObject;
        GameObject tempPanel = infoDisplayCanvas.transform.GetChild(0).gameObject;
        infoDisplayTxt = tempPanel.transform.GetChild(0).GetComponent<TMP_Text>();
        infoDisplayTxt.text = signInfo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            infoDisplayCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            infoDisplayCanvas.SetActive(false);
        }
    }
}
