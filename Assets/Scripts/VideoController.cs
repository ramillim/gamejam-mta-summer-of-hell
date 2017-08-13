using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    private long totalFrames;
    private bool isDonePlaying = false;

    public bool IsDonePlaying { get; private set; }

    private void Start()
    {
        player.loopPointReached += EndReached;
        player.prepareCompleted += OnPlayerReady;
    }

    private void Update()
    {
        if (player.isPlaying)
        {
            //Debug.Log("Frame: " + player.frame + " / " + totalFrames);
        }
    }

    public void SetClip(VideoClip clip)
    {
        player.clip = clip;
    }

    public void PlayClip()
    {
        ResetPlayer();
        player.Prepare();
    }

    public void OnPlayerReady(VideoPlayer player)
    {
        totalFrames = (long)player.frameCount;
        player.Play();
    }

    private void EndReached(VideoPlayer player)
    {
        IsDonePlaying = true;
    }

    private void ResetPlayer()
    {
        IsDonePlaying = false;
    }
}
