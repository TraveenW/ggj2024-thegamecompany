using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvent : MonoBehaviour
{
    //public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);

        this.transform.Find("GameOver").GetComponent<CanvasGroup>().alpha = 0;
        this.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 0;
    }
}
