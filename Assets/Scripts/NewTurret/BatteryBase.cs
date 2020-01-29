using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBase : MonoBehaviour
{
    public TestSwipeConnect swipeManager;
    public List<TurretBase2D> connectedTurrets;
    public int connectionCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnConnectionMade(TurretBase2D turret)
    {
        Debug.Log(turret.name +" has been connected");
        connectedTurrets.Add(turret);
        connectionCount++;
        if (connectionCount >= 2)
        {
            Debug.Log("Attempting Merge");
            var tur1 = connectedTurrets[0];
            var tur2 = connectedTurrets[1];
            if(tur1.mergeTypes.Contains(tur2.turretType) && tur2.mergeTypes.Contains(tur1.turretType))
            {
                Debug.Log("MERGE SUCCESSFUL");
                tur1.highlight.color = tur2.spriteColor;
                tur2.highlight.color = tur1.spriteColor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        swipeManager.BatteryEntered(this);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        swipeManager.BatteryLeft(this);
    }
}
