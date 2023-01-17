using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO stats;

    int currentHealth;

    public int CurrentHealth { get => currentHealth; }

    private void Awake()
    {
        currentHealth = stats.MaxLives;
    }

    public void TakeDamage()
    {
        currentHealth = Mathf.Max(currentHealth - 1, 0);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.LogWarning("Death");
    }
}
