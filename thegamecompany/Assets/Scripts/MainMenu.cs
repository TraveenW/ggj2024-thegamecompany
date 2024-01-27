using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    Button[] Buttons;
    public Canvas canvas;
    GameObject mainMenu;

    void Start()
    {
        canvas.gameObject.SetActive(true);

        canvas.transform.Find("MainMenu").GetComponent<CanvasGroup>().alpha = 1;
        canvas.transform.Find("CreditPage").GetComponent<CanvasGroup>().alpha = 0;

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
    }

    public void PlayClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsCLick()
    {
        mainMenu.SetActive(false);
        canvas.transform.Find("CreditPage").GetComponent<CanvasGroup>().alpha = 1;
    }

    public void BackClick()
    {
        mainMenu.SetActive(true);
        canvas.transform.Find("CreditPage").GetComponent<CanvasGroup>().alpha = 0;
    }

    public void QuitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
