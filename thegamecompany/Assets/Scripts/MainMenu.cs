using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    Button[] Buttons;
    public Canvas canvas;

    void Awake()
    {
        canvas.gameObject.SetActive(true);

        canvas.transform.Find("MainMenu").GetComponent<CanvasGroup>().alpha = 1;
        canvas.transform.Find("GameOver").GetComponent<CanvasGroup>().alpha = 0;
    }

    void FixedUpdate()
    {
        Buttons = FindObjectsOfType<Button>();
        foreach (var item in Buttons)
        {
            item.onClick.AddListener(() => OnButtonClicked(item));
        }
    }

    void OnButtonClicked(Button item)
    {
        switch (item.name)
        {
            case "Play":
                canvas.transform.Find("MainMenu").GetComponent<CanvasGroup>().alpha = 0;
                break;
            case "Settings":
                break;
            case "Quit":
                Application.Quit(); //?
                break;
        }

    }
}
