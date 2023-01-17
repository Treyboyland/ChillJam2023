using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoPool<PlayerDamager>
{
    private void Start()
    {
        GameManager.Manager.OnSpawnExplosion.AddListener(MakeExplosion);
    }

    void MakeExplosion(Vector3 pos)
    {
        var explosion = GetObject();
        explosion.transform.position = pos;
        explosion.gameObject.SetActive(true);
    }
}
