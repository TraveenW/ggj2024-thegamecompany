using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainAmbient : MonoBehaviour
{
    AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GameObject.Find("Fountain Stream").GetComponent<AudioSource>();
        m_AudioSource.Play();
    }
}
