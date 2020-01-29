using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonType : TurretBase2D
{
    public override void Awake()
    {
        base.Awake();
        turretType = TurretType.POISON;
        
        mergeTypes = new List<TurretType>{TurretType.FIRE};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
