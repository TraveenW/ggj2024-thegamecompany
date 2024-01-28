using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLimitedUse : MonoBehaviour
{
    [SerializeField] string audioSourceName;

    [SerializeField] float timeUntilFadeOut;
    [SerializeField] float fadeOutAmount;

    LimitedUseItem useState;
    AudioSource audioSource;
    bool hasPlayed;

    private void Start()
    {
        audioSource = GameObject.Find(audioSourceName).GetComponent<AudioSource>();
        useState = GetComponent<LimitedUseItem>();

        hasPlayed = false;
    }

    private void Update()
    {
        if (!hasPlayed && useState.canUse == false)
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
