using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyTrigger : Trigger
{
    /*public UnityEvent myEvent;
    public Canvas canvas;

    void Start()
    {
        if(myEvent == null)
            myEvent = new UnityEvent();

        myEvent.AddListener(ClickMoney);
    }

    void Update()
    {
        if(myEvent != null && Input.GetMouseButtonDown(0))
        {
            myEvent.Invoke();
        }
    }*/

    public override void MyEvent()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "Cube")
                canvas.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}