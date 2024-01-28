using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFountainLaugh : MonoBehaviour
{
    [SerializeField] float timeUntilFadeOut;
    [SerializeField] float fadeOutAmount;

    Money useState;
    AudioSource audioSource;
    bool hasPlayed;

    private void Start()
    {
        audioSource = GameObject.Find("Crowd Laugh").GetComponent<AudioSource>();
        useState = GetComponent<Money>();

        hasPlayed = false;
    }

    private void Update()
    {
        if (!hasPlayed && useState.isFinished == true)
        {
            audioSource.Play();
            audioSource.volume = AudioManager.Instance.sfxVolume;
            StartCoroutine(FadeOutMusic());
            hasPlayed = true;
        }
    }

    IEnumerator FadeOutMusic()
    {
        yield return new WaitForSeconds(timeUntilFadeOut);

        while (audioSource.volume > 1)
        {
            audioSource.volume -= fadeOutAmount;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
