using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : OnLeftClickTrigger
{
    public float maxDistance;
    public LayerMask layerMask;

    public float targetTime = 3.0f;
    private float timer;
    private bool isCounting = false;

    void FixedUpdate()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;
            Debug.Log(targetTime);

            if (timer <= 0.0f)
            {
                isCounting = false;
                Debug.Log("Hide");
                canvas.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    public override void MyEvent()
    {
        timer = targetTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            Debug.Log("Did Hit");
            canvas.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 1;
            isCounting = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            Debug.Log("Did not Hit");
        }
    }
}