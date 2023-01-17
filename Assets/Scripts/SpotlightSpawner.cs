using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightSpawner : MonoPool<SpotlightGame>
{
    [SerializeField]
    int numToSpawn;

    [SerializeField]
    float spawnY;

    [SerializeField]
    SpotlightStatsSO spawnBounds;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        var light = GetObject();
        var pos = spawnBounds.Bounds.Random();
        light.transform.position = new Vector3(pos.x, spawnY, pos.y);
        light.gameObject.SetActive(true);
    }
}
