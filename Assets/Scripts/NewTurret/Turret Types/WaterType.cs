using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterType : TurretBase2D
{
    public override void Awake()
    {
        base.Awake();
        turretType = TurretType.WATER;
        
        mergeTypes = new List<TurretType>{TurretType.POISON};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
