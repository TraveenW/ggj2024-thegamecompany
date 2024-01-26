using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent myEvent;
    public Canvas canvas;

    void Start()
    {
        if(myEvent == null)
            myEvent = new UnityEvent();

        myEvent.AddListener(MyEvent);
    }

    void Update()
    {
        if (myEvent != null && Input.GetMouseButtonDown(0))
        {
            myEvent.Invoke();
        }
    }

    public virtual void MyEvent()
    {

    }
}