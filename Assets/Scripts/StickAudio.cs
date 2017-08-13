//This script manages the audio component of the player's sword. In order to make the sword sound more realistic, the volume
//and pitch are controlled by the speed in which the sword moves

using UnityEngine;

//This script requires an Audio Source
[RequireComponent(typeof(AudioSource))]
public class StickAudio : MonoBehaviour 
{
    [SerializeField] float smoothing = 20f;     //Amount of smoothing applied to the change in the audio

    [Header("Value Ranges")]
    [SerializeField] float minSpeed = 0.15f;        //The minimum speed required for audio
    [SerializeField] float maxSpeed = 50f;      //The speed required for maximum audio
    [SerializeField] float minVolume = 0f;      //Minimum volume
    [SerializeField] float maxVolume = .6f;     //Maximum volume
    [SerializeField] float minPitch = .3f;      //Minimum pitch
    [SerializeField] float maxPitch = 1f;       //Maximum pitch

    AudioSource stickAudio;                     //Reference to the audio source
    Stick stick;                                //Reference to the sword script
    bool isActive;                              //Is the sword active?


    void Start () 
    {
        //Get references to the sword and audio source components
        stick = GetComponent<Stick> (); 
        stickAudio = GetComponent<AudioSource> ();

        //Set the initial volume and pitch
        stickAudio.volume = 0f;
        stickAudio.pitch = 0f;
    }

    void Update () 
    {
        //Get the current speed of the sword
        float currentSpeed = stick.Speed;

        //If the speed is below the required speed and the audio isn't active, exit
        if (currentSpeed < minSpeed && !isActive)
            return;

        //Set the sword to active
        isActive = true;

        //Calculate the percentage the current speed is between the minimum and maximum
        float percentage = Mathf.Clamp((currentSpeed - minSpeed) / (maxSpeed - minSpeed), 0f, 1f);

        //Calculate the desired volume and pitch based on the speed percentage
        float targetPitch = Mathf.Lerp (minPitch, maxPitch, percentage);
        float targetVolume = Mathf.Lerp (minVolume, maxVolume, percentage);

        //Lerp the current volume and pitch based on the desired values
        float appliedPitch = Mathf.Lerp(stickAudio.pitch, targetPitch, smoothing * Time.deltaTime);
        float appliedVolume = Mathf.Lerp(stickAudio.volume, targetVolume, smoothing * Time.deltaTime);

        //If the volume is below a very small amount, apply it
        if (appliedVolume >= .01f)
        {
            stickAudio.pitch = appliedPitch;
            stickAudio.volume = appliedVolume;
        }
        //...otherwise set the values to their minimum and set the audio to inactive
        else
        {
            stickAudio.pitch = minPitch;
            stickAudio.volume = minVolume;

            isActive = false;
        }
    }
}
