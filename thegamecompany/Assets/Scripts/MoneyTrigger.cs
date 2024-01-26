using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyTrigger : Trigger
{
    public float maxDistance;

    public override void MyEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, 1000))
        {
            Debug.Log("Did Hit");
            canvas.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            Debug.Log("Did not Hit");
        }
    }
}