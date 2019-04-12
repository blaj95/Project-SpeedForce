using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTurret : TurretBase
{
    private float fireRate;

    public float FireRate
    {
        get => fireRate;
        set => fireRate = value;
    }
    
    private float cooldown;

    public float Cooldown
    {
        get => cooldown;
        set => cooldown = value;
    }
    
    private float step;

    public float speed;

    public float snapSpeed;


    public Transform pointOfFire;

    public Transform rotatePoint;

    private Transform startPosition;
    
    public GameObject projectile;

    public GameObject target;
    
    public FOV fov;


    public virtual void Start()
    {
        startPosition = gameObject.transform;
    }

    public virtual void FixedUpdate()
    {
        if (fov.targetting)
        {
            target = fov.target;
            LockOn();
            if (Cooldown <= 0)
            {
                Engage();
                Cooldown = 1 / FireRate;
            }

            Cooldown -= Time.deltaTime;
        }
        else
        {
            rotatePoint.transform.localRotation = Quaternion.Slerp(rotatePoint.transform.localRotation,startPosition.rotation, snapSpeed * Time.deltaTime );
        }
    }

    public virtual void LockOn()
    {
        if (target != null)
        {
            step = speed * Time.deltaTime;
            var lookPos = target.transform.position - rotatePoint.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            rotatePoint.transform.localRotation = Quaternion.Slerp(rotatePoint.transform.localRotation, rotation,  speed * Time.deltaTime);   
        } 
    }

    public virtual void Engage()
    {
        
    }
}
