using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        Health = 3;
        Experience = 5;
        Damage = 2;
        speed = 3;
        
    }

    public override void Killed()
    {
        PlayerResources.Money += Experience;
        UI.OnEnemyKilled();
        base.Killed();
    }

    public override void Die()
    {
        base.Die();
    }

    public override void OnHit(float damage)
    {
        base.OnHit();
        Health -= damage;
    }
}
