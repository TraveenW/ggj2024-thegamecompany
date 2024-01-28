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

    Slider musicSlider;
    Slider sfxSlider;

    void Start()
    {
        canvas.gameObject.SetActive(true);

        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settings = canvas.transform.Find("Settings").gameObject;
        creditPage = canvas.transform.Find("CreditPage").gameObject;

        musicSlider = settings.transform.Find("Content").Find("MusicSlider").GetComponent<Slider>();
        sfxSlider = settings.transform.Find("Content").Find("SFXSlider").GetComponent<Slider>();

        mainMenu.SetActive(true);
        settings.SetActive(false);
        creditPage.SetActive(false);

        AudioManager.Instance.PlayMusic();
    }

    public void PlayClick()
    {
        SceneManager.LoadScene("FullGameLevel");
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

        musicSlider.value = AudioManager.Instance.musicVolume;
        sfxSlider.value = AudioManager.Instance.sfxVolume;

    }

    public void ExitClick()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void ConfirmClick()
    {
        AudioManager.Instance.musicVolume = musicSlider.value;
        AudioManager.Instance.sfxVolume = sfxSlider.value;

        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void QuitClick()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
