using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    private float experience;
    private float damage;
    
    public float speed;
    
    public float Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0)
            {
                Killed();
            }
        }
    }

    public float Experience
    {
        get => experience;
        set => experience = value;
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }


    public virtual void Killed()
    {
        Destroy(gameObject);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void OnHit()
    {
        
    }

    public virtual void OnHit(float damage)
    {

    }
}
