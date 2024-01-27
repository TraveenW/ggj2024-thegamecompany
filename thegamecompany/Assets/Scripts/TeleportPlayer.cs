using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public bool canTeleport = true;
    [SerializeField] bool preserveX;
    [SerializeField] bool preserveZ;
    [SerializeField] GameObject tpExit;

    private Vector3 tpExitPoint;
    private Vector3 tpLocation;

    private void OnTriggerEnter(Collider other)
    {
        // If other collision is tagged "Player", execute teleport command
        if (other.CompareTag("Player") && canTeleport)
        {
            tpExitPoint = tpExit.GetComponentInChildren<Transform>().position;
            tpLocation = other.transform.position;

            // If X and/or Z isn't preserved, change tpLocation according to the tpExitPoint
            if (preserveX == false)
            {
                tpLocation.x = tpExitPoint.x;
            }
            if (preserveZ == false)
            {
                tpLocation.z = tpExitPoint.z;
            }

            // Warp player to tpLocation
            other.transform.parent.position = tpLocation;
        }
    }
}
