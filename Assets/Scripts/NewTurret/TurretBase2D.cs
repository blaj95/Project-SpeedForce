using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase2D : MonoBehaviour
{
    public TestSwipeConnect swipeManager;

    public SpriteRenderer highlight;
    
    [HideInInspector]
    public List<TurretType> mergeTypes;

    public Color spriteColor;
    
    public enum TurretType
    {
        BASIC,
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

    public virtual void Awake()
    {
        swipeManager = FindObjectOfType<TestSwipeConnect>();
        spriteColor = GetComponent<SpriteRenderer>().color;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            swipeManager.TurretEntered(this);   
        }
    }
    
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            swipeManager.TurretLeft(this);
        }
    }
}
