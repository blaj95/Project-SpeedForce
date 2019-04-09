using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    private Enemy grunt;

    public float _health
    {
        get => grunt.health;
        set
        {
            grunt.health = value;
            if (grunt.health <= 0)
            {
                grunt.Die(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        grunt = new Enemy();
        grunt.health = 3f;
    }

    public override void OnHit(float damage)
    {
        base.OnHit();
        _health -= damage;
    }
}
