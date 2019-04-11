using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBaseV2 : MonoBehaviour
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

    // Start is called before the first frame update
    
    public virtual void SetStats(float health, TurretType _type)
    {
        Health = health;
        type = _type;
    }
}
