using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTurret : NewDefenseTurret
{
    // Start is called before the first frame update
    void Start()
    {
        SetStats(10, TurretType.DEFENSE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.OnHit(1);
        Debug.Log("Wall has hit enemy");
    }
}
