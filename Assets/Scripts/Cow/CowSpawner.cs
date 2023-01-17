using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoPool<Cow>
{
    [SerializeField]
    Vector4 bounds;

    [SerializeField]
    Vector2Int numToSpawn;

    [SerializeField]
    float distanceBetweenCows;

    [SerializeField]
    float spawnY;

    List<Vector2> points = new List<Vector2>();
    List<Vector2> pointsUsed = new List<Vector2>();

    private void Start()
    {
        CalculatePoints();
        SpawnCows();
        SelectWinner();
    }


    void CalculatePoints()
    {
        float x = bounds.x;
        float y = bounds.z;

        while (x <= bounds.y)
        {
            while (y <= bounds.w)
            {
                points.Add(new Vector2(x, y));
                y += distanceBetweenCows;
            }
            y = bounds.z;
            x += distanceBetweenCows;
        }

        points.Shuffle();
    }

    void SpawnCows()
    {
        int spawnCount = numToSpawn.Random();
        for (int i = 0; i < spawnCount; i++)
        {
            if (i >= points.Count)
            {
                Debug.LogWarning("Need more points. Points: " + points.Count + " Spawns: " + spawnCount);
                break;
            }

            var chosen = points[i];
            Vector3 pos = new Vector3(chosen.x, spawnY, chosen.y);

            var cow = GetObject();
            cow.transform.position = pos;
            cow.gameObject.SetActive(true);
        }
    }

    void SelectWinner()
    {
        var cows = GetActiveObjects();
        cows.Shuffle();
        cows[0].IsWinner = true;
    }
}
