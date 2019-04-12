using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShot : AttackTurret
{
    public override void Start()
    {
        base.Start();
        SetStats(10,TurretType.ATTACK);
        FireRate = 1;
        damage = 1;
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
        if (proj != null)
        {
            proj.damage = damage;
            proj.SeekTarget(target.transform);
        }
    }
}
