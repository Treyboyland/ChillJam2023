using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSound : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    Rigidbody body;

    [SerializeField]
    float walkThreshhold;

    [SerializeField]
    float sprintPitch;

    private void Start()
    {
        GameManager.Manager.OnPlayerSprint.AddListener(ChangePitch);
    }

    // Update is called once per frame
    void Update()
    {
        var magnitudeReached = body.velocity.sqrMagnitude > walkThreshhold;
        if (!source.isPlaying && magnitudeReached)
        {
            source.time = UnityEngine.Random.Range(0.0f, 1.0f) * source.clip.length;
            source.Play();
        }
        else if (source.isPlaying && !magnitudeReached)
        {
            source.Stop();
        }
    }

    void ChangePitch(bool sprint)
    {
        source.pitch = sprint ? sprintPitch : 1f;
    }
}
