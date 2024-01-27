using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    bool canOpen = true;

    public void OpenDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            if(hit.collider.gameObject.name == "Door" && canOpen)
            {
                door.Play("DoorOpen", 0, 0.0f);
                canOpen = false;
            }
        }
    }
}
