using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Vector3 direction = transform.position - target.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
