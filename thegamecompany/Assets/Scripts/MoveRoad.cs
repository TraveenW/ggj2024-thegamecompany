using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    [SerializeField] GameObject road;
    [SerializeField] Transform targetTransform;
    [SerializeField] float speed;
    bool isMoving = false;

    void Update()
    {
        if(isMoving)
            road.transform.position = Vector3.Lerp(road.transform.position, targetTransform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Capsule")
            isMoving = true;
    }
}
