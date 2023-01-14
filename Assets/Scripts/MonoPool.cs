using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T prefab;

    [SerializeField]
    int initialCount;

    List<T> pool = new List<T>();

    private void Awake()
    {
        if (initialCount > 0)
        {
            for (int i = 0; i < initialCount; i++)
            {
                CreateObject();
            }
        }
    }

    T CreateObject()
    {
        var newObject = Instantiate(prefab, transform);
        newObject.gameObject.SetActive(false);

        pool.Add(newObject);

        return newObject;
    }

    public T GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public List<T> GetActiveObjects()
    {
        List<T> objs = new List<T>();
        foreach (var obj in pool)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                objs.Add(obj);
            }
        }

        return objs;
    }
}
