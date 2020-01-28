using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireType : TurretBase2D
{
    public override void Awake()
    {
        base.Awake();
        turretType = TurretType.FIRE;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
