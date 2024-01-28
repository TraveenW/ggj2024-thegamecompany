using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightByDistance : MonoBehaviour
{
    private GameObject player;
    private Vector3 lightPosition;
    private Light light;

    [SerializeField]
    private float activateDistance;

    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lightPosition = this.transform.position;
        light = this.GetComponent<Light>();
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        float distance = Vector3.Distance(playerPos, lightPosition);

        if(distance <= activateDistance)
        {
            light.enabled = true;
        }else light.enabled = false;
    }
}
