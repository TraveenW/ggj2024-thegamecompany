using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    public Vector3 target;

    private bool isFalling = true;

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            Vector3 direction = transform.position - target;
            transform.rotation = Quaternion.LookRotation(direction);

            if (transform.position == target)
            {
                isFalling = false;
            }
        }
        
    }
}
