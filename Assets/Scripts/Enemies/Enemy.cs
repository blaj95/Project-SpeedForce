using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    
    public float Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0)
            {
                Die(gameObject);
            }
        }
    }

    private float experience;

    public float Experience
    {
        get => experience;
        set => experience = value;
    }

    public virtual void Die(GameObject gameObject)
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
