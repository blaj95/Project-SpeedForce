using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shockwave Turret, damages all enemies in area with a chance to slow
public class ShockwaveTurret : AttackTurret
{
    public GameObject ShockArea;

    public override void Start()
    {
        SetStats(10,TurretType.ATTACK);
        FireRate = .33f;
        damage = 1.5f;
        Cost = 35f;
        base.Start();
    }
    
    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown <= 0)
        {
            StartCoroutine(Shockwave());
            Cooldown = 1 / FireRate;
        }

        Cooldown -= Time.deltaTime;
    }

    IEnumerator Shockwave()
    {
        ShockArea.SetActive(true);
        yield return new WaitForSeconds(.5f);
        ShockArea.SetActive(false);
    }
}
