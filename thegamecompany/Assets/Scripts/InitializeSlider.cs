using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeSlider : MonoBehaviour
{
    Slider musicSlider;
    Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider = transform.Find("MusicSlider").GetComponent<Slider>();
        sfxSlider = transform.Find("SFXSlider").GetComponent<Slider>();

        musicSlider.value = AudioManager.Instance.musicVolume;
        sfxSlider.value = AudioManager.Instance.sfxVolume;
    }
}
