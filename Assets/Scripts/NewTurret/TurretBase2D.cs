using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase2D : MonoBehaviour
{
    public TestSwipeConnect swipeManager;

    public SpriteRenderer highlight;
    
    public enum TurretType
    {
        FIRE,
        POISON,
        WATER
    }
    
    public enum ConnectionState
    {
        NONE,
        CONNECTED
    }

    public ConnectionState connectionState = ConnectionState.NONE;
    public TurretType turretType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            swipeManager.TurretEntered(this);   
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            swipeManager.TurretLeft(this);
        }
    }
}
