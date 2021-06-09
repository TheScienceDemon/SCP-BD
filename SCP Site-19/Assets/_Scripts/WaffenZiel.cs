using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffenZiel : MonoBehaviour
{
    public float health;

    public void TakingDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
