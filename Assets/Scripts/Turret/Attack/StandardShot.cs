using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShot : AttackTurret
{
    public override void Start()
    {
        SetStats(10,TurretType.ATTACK);
        FireRate = 1;
        damage = 1;
        Cost = 50f;
        base.Start();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
    }

    public override void Engage()
    {
        base.Engage();
        GameObject bullet = Instantiate(projectile, pointOfFire.position, Quaternion.identity);
        Projectile proj = bullet.GetComponent<Projectile>();
        if (proj)
        {
            proj.damage = damage;
            proj.SeekTarget(target.transform);
        }
    }
}
