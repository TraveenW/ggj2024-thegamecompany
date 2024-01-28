using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFootstep : MonoBehaviour
{

    private void Start()
    {
        AudioManager.Instance.SwitchFootstepsStreet();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.SwitchFootstepsMetal();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.Instance.SwitchFootstepsStreet();
        }
    }
}
