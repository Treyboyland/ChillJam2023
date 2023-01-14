using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static float Random(this Vector2 vector2)
    {
        return UnityEngine.Random.Range(vector2.x, vector2.y);
    }

    public static int Random(this Vector2Int vector2)
    {
        return UnityEngine.Random.Range(vector2.x, vector2.y);
    }

    public static Vector2 Random(this Vector4 vector4)
    {
        Vector2 x = new Vector2(vector4.x, vector4.y);
        Vector2 y = new Vector2(vector4.z, vector4.w);
        return new Vector2(x.Random(), y.Random());
    }

    public static void Shuffle<T>(this List<T> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            int chosenIndex = UnityEngine.Random.Range(i, items.Count);
            var temp = items[chosenIndex];
            items[chosenIndex] = items[i];
            items[i] = temp;
        }
    }

    public static T Random<T>(this List<T> items)
    {
        int index = UnityEngine.Random.Range(0, items.Count);
        return items[index];
    }
}
