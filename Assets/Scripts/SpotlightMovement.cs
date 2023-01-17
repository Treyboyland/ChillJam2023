using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMovement : MonoBehaviour
{
    [SerializeField]
    SpotlightStatsSO stats;

    bool waitFirst;

    private void Start()
    {
        waitFirst = Random.Range(0.0f, 1.0f) < 0.5f;
        StartCoroutine(Move());
    }

    SpotlightStatsSO.Directions ChooseRandomDirection()
    {
        float x = transform.position.x;
        float z = transform.position.z;

        List<SpotlightStatsSO.Directions> directions = new List<SpotlightStatsSO.Directions>();

        if (x - (stats.Speed * Time.deltaTime) > stats.Bounds.x)
        {
            directions.Add(SpotlightStatsSO.Directions.LEFT);
        }
        if (x + (stats.Speed * Time.deltaTime) < stats.Bounds.y)
        {
            directions.Add(SpotlightStatsSO.Directions.RIGHT);
        }
        if (z - (stats.Speed * Time.deltaTime) > stats.Bounds.z)
        {
            directions.Add(SpotlightStatsSO.Directions.DOWN);
        }
        if (z + (stats.Speed * Time.deltaTime) < stats.Bounds.w)
        {
            directions.Add(SpotlightStatsSO.Directions.UP);
        }

        if (directions.Count == 0)
        {
            return SpotlightStatsSO.Directions.UP;
        }

        int chosenIndex = UnityEngine.Random.Range(0, directions.Count);

        return directions[chosenIndex];
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (waitFirst)
            {
                yield return new WaitForSeconds(stats.SecondsBetweenMove);
            }
            else
            {
                waitFirst = true;
            }

            yield return StartCoroutine(MoveDirection(ChooseRandomDirection()));
        }
    }

    IEnumerator MoveDirection(SpotlightStatsSO.Directions direction)
    {
        bool useX = direction == SpotlightStatsSO.Directions.LEFT || direction == SpotlightStatsSO.Directions.RIGHT;
        float secondsToMove = stats.SecondsPerMove;

        float elapsed = 0;
        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            var pos = transform.position;
            if (useX)
            {
                pos.x += stats.Speed * Time.deltaTime * (direction == SpotlightStatsSO.Directions.RIGHT ? 1 : -1);
            }
            else
            {
                pos.z += stats.Speed * Time.deltaTime * (direction == SpotlightStatsSO.Directions.RIGHT ? 1 : -1);
            }
            if (pos.x < stats.Bounds.x || pos.y > stats.Bounds.y || pos.z < stats.Bounds.z || pos.z > stats.Bounds.w)
            {
                yield break;
            }

            transform.position = pos;
            yield return null;
        }
    }
}
