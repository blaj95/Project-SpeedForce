using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{

    public float _health
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

    // Start is called before the first frame update
    void Start()
    {
        _health = 3;
    }

    public override void OnHit(float damage)
    {
        base.OnHit();
        _health -= damage;
    }
}
