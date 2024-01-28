using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] GameObject moneySpawnPoint;
    [SerializeField] GameObject money;
    [SerializeField] GameObject player;

    [SerializeField] float maxDistance;

    [SerializeField] LayerMask layerMask;

    [SerializeField] Transform targetTransform;

    [SerializeField] Canvas canvas;

    [SerializeField] float targetTime = 3.0f;
    private float timer;
    [SerializeField] int maxCounter = 5;
    private int counter = 0;
    private bool isCounting = false;
    [HideInInspector] public bool isFinished = false;

    void FixedUpdate()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                isCounting = false;
                canvas.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    public void LoseMoney()
    {
        timer = targetTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            if(hit.collider.gameObject.name == "Fountain")
            {
                canvas.transform.Find("DuringGame").GetComponent<CanvasGroup>().alpha = 1;
                isCounting = true;

                Instantiate(money, moneySpawnPoint.transform.position, moneySpawnPoint.transform.rotation);
                counter += 1;
            }
        }

        if (counter > maxCounter - 1 && isFinished == false)
        {
            player.transform.position = targetTransform.position;
            isFinished = true;
        }
    }
}