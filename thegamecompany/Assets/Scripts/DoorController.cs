using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    private Animator door;

    public void OpenDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            if(hit.collider.gameObject.name == "Door" && hit.transform.parent.GetComponent<LimitedUseItem>().canUse)
            {
                ExecuteAnimation("DoorOpen", hit.transform);
            }
            if (hit.collider.gameObject.name == "Building" && hit.transform.parent.GetComponent<LimitedUseItem>().canUse)
            {
                ExecuteAnimation("BuildingRotate", hit.transform);
            }
        }
    }

    void ExecuteAnimation(string animationName, Transform target)
    {
        door = target.parent.GetComponent<Animator>();
        door.Play(animationName, 0, 0.0f);
        target.parent.GetComponent<LimitedUseItem>().canUse = false;
    }
}
