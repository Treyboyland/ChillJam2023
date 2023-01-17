using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioRandomizer randomizer;

    [SerializeField]
    Vector2 secondsToWait;

    private void Start()
    {
        StartCoroutine(AudioLoop());
    }

    IEnumerator AudioLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsToWait.Random());
            source.clip = randomizer.Clip;
            source.volume = randomizer.Volume;
            source.pitch = randomizer.Pitch;
            source.Play();
            while (source.isPlaying)
            {
                yield return null;
            }
        }
    }
}
