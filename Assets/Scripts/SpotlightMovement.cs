using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMovement : MonoBehaviour
{
    [SerializeField]
    SpotlightStatsSO stats;

    [SerializeField]
    SpotlightStatsSO statsHard;



    bool waitFirst;

    static PlayerController player;

    static ExplosionPool explosionPool;

    private void Start()
    {
        if (!player)
        {
            player = GameObject.FindObjectOfType<PlayerController>();
        }
        if (!explosionPool)
        {
            explosionPool = GameObject.FindObjectOfType<ExplosionPool>();
        }
        waitFirst = Random.Range(0.0f, 1.0f) < 0.5f;
        StartCoroutine(Move());
    }

    SpotlightStatsSO statsToUse
    {
        get
        {
            if (explosionPool)
            {
                return explosionPool.AreAnyActive() ? statsHard : stats;
            }
            else
            {
                return stats;
            }
        }
    }

    SpotlightStatsSO.Directions ChooseRandomDirection()
    {
        float x = transform.position.x;
        float z = transform.position.z;

        List<SpotlightStatsSO.Directions> directions = new List<SpotlightStatsSO.Directions>();

        if (x - (statsToUse.Speed * Time.deltaTime) > statsToUse.Bounds.x)
        {
            directions.Add(SpotlightStatsSO.Directions.LEFT);
        }
        if (x + (statsToUse.Speed * Time.deltaTime) < statsToUse.Bounds.y)
        {
            directions.Add(SpotlightStatsSO.Directions.RIGHT);
        }
        if (z - (statsToUse.Speed * Time.deltaTime) > statsToUse.Bounds.z)
        {
            directions.Add(SpotlightStatsSO.Directions.DOWN);
        }
        if (z + (statsToUse.Speed * Time.deltaTime) < statsToUse.Bounds.w)
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

    SpotlightStatsSO.Directions GetDirectionToPlayer()
    {
        if (player == null)
        {
            return ChooseRandomDirection();
        }

        float x = Mathf.Abs(transform.position.x - player.transform.position.x);
        float z = Mathf.Abs(transform.position.z - player.transform.position.z);

        //Debug.LogWarning("X: " + x.ToString("N2") + " Z: " + z.ToString("N2"));

        if (x > z)
        {
            //TODO: Math

            return transform.position.x < player.transform.position.x ? SpotlightStatsSO.Directions.RIGHT : SpotlightStatsSO.Directions.LEFT;
        }
        else
        {
            return transform.position.z < player.transform.position.z ? SpotlightStatsSO.Directions.UP : SpotlightStatsSO.Directions.DOWN;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (waitFirst)
            {
                yield return StartCoroutine(WaitForMove(statsToUse.SecondsBetweenMove));
            }
            else
            {
                waitFirst = true;
            }

            if (statsToUse.ShouldMoveTowardsPlayer)
            {
                yield return StartCoroutine(MoveDirectionPlayer(GetDirectionToPlayer()));
            }
            else
            {
                yield return StartCoroutine(MoveDirection(ChooseRandomDirection()));
            }
        }
    }

    IEnumerator WaitForMove(float seconds)
    {
        float elapsed = 0;
        var currentStats = statsToUse;
        while (elapsed < seconds)
        {
            if (statsToUse == statsHard)
            {
                yield break;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MoveDirection(SpotlightStatsSO.Directions direction)
    {
        bool useX = direction == SpotlightStatsSO.Directions.LEFT || direction == SpotlightStatsSO.Directions.RIGHT;
        float secondsToMove = statsToUse.SecondsPerMove;

        float elapsed = 0;
        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            var pos = transform.position;
            if (useX)
            {
                pos.x += statsToUse.Speed * Time.deltaTime * (direction == SpotlightStatsSO.Directions.RIGHT ? 1 : -1);
            }
            else
            {
                pos.z += statsToUse.Speed * Time.deltaTime * (direction == SpotlightStatsSO.Directions.UP ? 1 : -1);
            }
            if (pos.x < statsToUse.Bounds.x || pos.y > statsToUse.Bounds.y || pos.z < statsToUse.Bounds.z || pos.z > statsToUse.Bounds.w)
            {
                yield break;
            }

            transform.position = pos;
            yield return null;
        }
    }

    bool WouldPassPlayer(Vector3 pos, SpotlightStatsSO.Directions direction)
    {
        bool wouldPass;
        switch (direction)
        {
            case SpotlightStatsSO.Directions.UP:
                wouldPass = pos.z > player.transform.position.z;
                break;
            case SpotlightStatsSO.Directions.DOWN:
                wouldPass = pos.z < player.transform.position.z;
                break;
            case SpotlightStatsSO.Directions.LEFT:
                wouldPass = pos.x < player.transform.position.x;
                break;
            case SpotlightStatsSO.Directions.RIGHT:
                wouldPass = pos.x > player.transform.position.x;
                break;
            default:
                return true;
        }

        //Debug.LogWarning("Would pass: " + wouldPass + " Direction: " + direction);

        return wouldPass;
    }

    IEnumerator MoveDirectionPlayer(SpotlightStatsSO.Directions direction)
    {
        //Debug.LogWarning(direction);
        bool useX = direction == SpotlightStatsSO.Directions.LEFT || direction == SpotlightStatsSO.Directions.RIGHT;
        float secondsToMove = statsToUse.SecondsPerMove;

        float elapsed = 0;
        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            var pos = transform.position;
            if (useX)
            {
                pos.x += statsToUse.Speed * Time.deltaTime * (direction == SpotlightStatsSO.Directions.RIGHT ? 1 : -1);
            }
            else
            {
                pos.z += statsToUse.Speed * Time.deltaTime * (direction == SpotlightStatsSO.Directions.UP ? 1 : -1);
            }
            if (pos.x < statsToUse.Bounds.x || pos.y > statsToUse.Bounds.y || pos.z < statsToUse.Bounds.z || pos.z > statsToUse.Bounds.w || WouldPassPlayer(pos, direction))
            {
                yield break;
            }

            transform.position = pos;
            yield return null;
        }
    }
}
