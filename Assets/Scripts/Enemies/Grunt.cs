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
        speed = 3;
    }

    public override void Die(GameObject gameObject)
    {
        PlayerResources.Money += Experience;
        base.Die(gameObject);
    }

    public override void OnHit(float damage)
    {
        base.OnHit();
        Health -= damage;
    }
}
