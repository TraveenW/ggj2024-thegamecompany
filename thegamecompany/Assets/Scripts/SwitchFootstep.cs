using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFootstep : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("SwitchFootstepsMetal");
            //AudioManager.Instance.SwitchFootstepsMetal();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("SwitchFootstepsStreet");
            // AudioManager.Instance.SwitchFootstepsStreet();
        }
    }
}
