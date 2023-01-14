using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioRandomizer randomizer;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(PlayThenDisable());
        }
    }

    IEnumerator PlayThenDisable()
    {
        RandomizeSettings();
        source.Play();

        while (source.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }

    void RandomizeSettings()
    {
        source.clip = randomizer.Clip;
        source.volume = randomizer.Volume;
        source.pitch = randomizer.Pitch;
    }
}
