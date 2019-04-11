using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShotv2 : NewAttackTurret
{
    public override void Start()
    {
        base.Start();
        FireRate = 1;
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
            proj.SeekTarget(target.transform);
        }
    }
}
