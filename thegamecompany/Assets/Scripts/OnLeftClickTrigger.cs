using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnLeftClickTrigger : MonoBehaviour
{
    public UnityEvent myEvent;

    void Start()
    {
        if(myEvent == null)
            myEvent = new UnityEvent();
    }

    void Update()
    {
        if (myEvent != null && Input.GetMouseButtonDown(0))
        {
            myEvent.Invoke();
        }
    }
}