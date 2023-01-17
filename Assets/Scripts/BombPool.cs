using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoPool<Bomb>
{
    private void Start()
    {
        GameManager.Manager.OnSpawnBomb.AddListener(MakeBomb);
    }

    void MakeBomb(Vector3 pos)
    {
        var bomb = GetObject();
        bomb.transform.position = pos;
        bomb.gameObject.SetActive(true);
    }
}
