//This script records the speed of the sword based on the change of position of the tip over time. This is used for cutting, bullet
//deflection, and audio. This script also demonstrates how to use trigger inputs to play a graphical
//effect on the sword

using UnityEngine;
using UnityEngine.VR;

public class Stick : MonoBehaviour 
{
    [SerializeField] Transform stickTip;        //A reference to the tip of the sword
    [SerializeField] float initialDelay = .5f;  //Initial delay before speed recording begins
    [SerializeField] float repeatDelay = .01f;  //The time delay between checking velocity

    float speed;                                //The current speed of the sword
    float maxSpeed = 0;
    float minSpeed = 100;
    public float Speed                          //A public property to make the speed accessible (read only)
    {
        get{ return speed; }
    }
        
    Vector3 lastPos;                            //The last good position of the sword tip
    bool isReady;                               //Is the sword speed ready to be measured?

    void Start () 
    {
        //Invoke the Initialize method after a delay. This is done so that the sword speed isn't being measured
        //as soon as the scene starts. After the first frame, VR tracking becomes enabled which will make
        //the sword position jump and have a high speed
        //Invoke ("Initialize", initialDelay);
        lastPos = stickTip.position;

    }

    void Initialize()
    {
        //Record the "initial" position of the sword tip here so that future
        //calculations will be accurate
        lastPos = stickTip.position;

        //Set up the CalculateSpeed method to run at regular intervals.
        //This allows the sword enough time to provide useful speed data without
        //be so long that the data is wrong
        //InvokeRepeating ("CalculateSpeed", 0f, repeatDelay);
    }

    void Update() {
        CalculateSpeed ();
    }

    void CalculateSpeed()
    {
        //Calculate the speed of the sword
        float tempSpeed = Vector3.Distance(stickTip.transform.position, lastPos) / Time.deltaTime;

        //Set the speed and last position of the sword tip
        speed = tempSpeed;
        lastPos = stickTip.transform.position;
        //Debug.LogFormat ("Speed: {0}",speed);
        if (speed > 0f)
            minSpeed = Mathf.Min (minSpeed, speed);
        maxSpeed = Mathf.Max (maxSpeed, speed);
        Debug.LogFormat ("Max: {0}, Min: {1}",maxSpeed, minSpeed);
    }
}
