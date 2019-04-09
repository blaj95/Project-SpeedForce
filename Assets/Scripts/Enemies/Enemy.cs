using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health
    {
        get; 
        set;
    }

    public void Die(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    
    

    public virtual void OnHit()
    {
        Debug.Log("HIT");
    }
    
    public virtual void OnHit(float damage)
    {
        Debug.Log("HIT WITH DAMAGE");
    }

   
}
