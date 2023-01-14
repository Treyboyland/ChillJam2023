using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioRandomizer", menuName = "Game/Audio Randomizer")]
public class AudioRandomizer : ScriptableObject
{
    [SerializeField]
    List<AudioClip> clips;

    public AudioClip Clip => clips.Random();

    [SerializeField]
    Vector2 pitch;

    public float Pitch => pitch.Random();

    [SerializeField]
    Vector2 volume;

    public float Volume => volume.Random();
}
