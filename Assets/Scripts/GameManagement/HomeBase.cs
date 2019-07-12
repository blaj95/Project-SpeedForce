using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    public static float baseHealth = 25;
    public static float currentHealth;

    private void Awake()
    {
        currentHealth = baseHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();
            currentHealth -= hitEnemy.Damage;
            UI.OnBaseHit();
            hitEnemy.Die();
        }
    }
    
}
