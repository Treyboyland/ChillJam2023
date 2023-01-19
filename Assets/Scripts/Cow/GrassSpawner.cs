using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoPool<Grass>
{
    [SerializeField]
    Vector4 bounds;

    [SerializeField]
    Vector2Int numToSpawn;

    [SerializeField]
    float spawnY;


    // Start is called before the first frame update
    void Start()
    {
        int count = numToSpawn.Random();
        for (int i = 0; i < count; i++)
        {
            var grass = GetObject();
            var pos = bounds.Random();
            grass.transform.position = new Vector3(pos.x, spawnY, pos.y);
            grass.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
