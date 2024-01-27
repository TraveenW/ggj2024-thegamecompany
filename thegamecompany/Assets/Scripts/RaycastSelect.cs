using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelect : MonoBehaviour
{
    public float selectionDistance = 1f;
    public LayerMask layerMask;

    private GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit , selectionDistance, layerMask))
        {
            if(currentTarget == null)
            {
                currentTarget = hit.transform.gameObject;
            }
            else if(currentTarget != hit.transform.gameObject)
            {
                currentTarget = hit.transform.gameObject;
            }

            OnRaycast(hit.transform.gameObject);
        }
    }

    protected virtual void OnRaycast(GameObject target)
    {

    }
}
