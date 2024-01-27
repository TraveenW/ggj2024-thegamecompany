using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    Button[] Buttons;
    [SerializeField] Canvas canvas;
    GameObject mainMenu;
    GameObject settings;
    GameObject creditPage;

    void Start()
    {
        canvas.gameObject.SetActive(true);

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settings = canvas.transform.Find("Settings").gameObject;
        creditPage = canvas.transform.Find("CreditPage").gameObject;

        mainMenu.SetActive(true);
        settings.SetActive(false);
        creditPage.SetActive(false);
    }

    public void PlayClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsCLick()
    {
        mainMenu.SetActive(false);
        creditPage.SetActive(true);
    }

    public void BackClick()
    {
        mainMenu.SetActive(true);
        creditPage.SetActive(false);
    }

    public void SettingClick()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void ExitClick()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void QuitClick()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
