using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public enum TurretType
    {
        ATTACK,
        DEFENSE,
        BUFF
    }
    
    public TurretType type;
    
    private float _health;

    public float Health
    {
        get => _health;
        set => _health = value;
    }
    
    public float damage;

    private float cost;

    public float Cost
    {
        get => cost;
        set => cost = value;
    }
    
    public virtual void Start()
    {
        PlayerResources.Money -= cost;
    }

    // Start is called before the first frame update
    
    public virtual void SetStats(float health, TurretType _type)
    {
        Health = health;
        type = _type;
    }

    public virtual float CheckCost()
    {
        return 0;
    }
}
