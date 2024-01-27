using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Volumes")]
    [SerializeField] float musicVolume = 1;
    [SerializeField] float sfxVolume = 1;

    [Header("Music")]
    public AudioSource backgroundMusic;
    [SerializeField] float fadeOutTimeMusic = 4;
    private bool isMusicPlaying = false;

    [Header("Footsteps")]
    [SerializeField] float footstepPitchRange = 0.15f;
    public AudioSource footstepsSource;
    [SerializeField] AudioClip[] streetFootsteps;
    [SerializeField] AudioClip[] metalFootsteps;
    private int footstepSurface = 0;

    [Header("Meteor Sounds")]
    public AudioSource meteorFall;
    public AudioSource meteorCrash;

    [Header("Audience Sounds")]
    public AudioSource crowdLaugh;
    public AudioSource crowdSad;
    public AudioSource crowdCheer;

    [Header("Misc")]
    public AudioSource fountainStream;
    public AudioSource woodHit;

    // Create audio manager as a singleton that lasts between scenes
    // Access audiomanager functions in other scripts using: AudioManager.Instance.[public function/variable]
    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);

        // If another manager is present, delete that manager

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.volume = musicVolume;
        }
    }

    // Start background music if it isn't playing already
    public void PlayMusic()
    {
        if (backgroundMusic.isPlaying!)
        {
            backgroundMusic.Play();
            isMusicPlaying = true;
        }
    }

    // Play random footstep depending on surface type
    public void PlayFootsteps()
    {
        int clipIndex;

        footstepsSource.pitch = Random.Range(1 - footstepPitchRange / 2, 1 + footstepPitchRange / 2);
        footstepsSource.volume = sfxVolume;

        switch (footstepSurface)
        {
            case 1:
                clipIndex = Random.Range(0, metalFootsteps.Length);
                footstepsSource.PlayOneShot(metalFootsteps[clipIndex]);
                break;
            default:
                clipIndex = Random.Range(0, streetFootsteps.Length);
                footstepsSource.PlayOneShot(streetFootsteps[clipIndex]);
                break;
        }
    }

    // Switch footstepSurface to street or metal depending on which is called
    public void SwitchFootstepsStreet() { footstepSurface = 0; }
    public void SwitchFootstepsMetal() {  footstepSurface = 1; }


    // Start fountain stream sounds if it isn't playing already
    public void PlayStream()
    {
        if (fountainStream.isPlaying!)
        {
            fountainStream.volume = sfxVolume;
            fountainStream.Play();
            isMusicPlaying = true;
        }
    }

    // Stops fountain stream sounds if it hasn't stopped yet
    public void StopStream()
    {
        if (fountainStream.isPlaying)
        {
            fountainStream.Stop();
            isMusicPlaying = false;
        }
    }

    // Fade out music over time
    public void StartFadeOutMusic()
    {
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        float fadeAmount = musicVolume * fadeOutTimeMusic * Time.deltaTime;

        while (backgroundMusic.volume > 0)
        {
            backgroundMusic.volume -= fadeAmount;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}
