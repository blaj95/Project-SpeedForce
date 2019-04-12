using System.Collections;
using System.Collections.Generic;
using Turret;
using UnityEngine;

public class StandardShotOld : MonoBehaviour
{
    private AttackTurretOld standardShot;
    
    private int testInt;
    private int enemyMask = 1 << 19;
    public float speed;
    public float snapSpeed;
    public GameObject rotatePoint;
    public GameObject projectile;
    public Transform firePoint;
    private FOV _fov;
    private float step;
    private float cooldown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        standardShot = new AttackTurretOld();
        standardShot.SetUp(TurretBaseOld.TurretType.ATTACK);
        
        standardShot.Experience = 0f;
        standardShot.firePoint = firePoint;
        standardShot.startPosition = transform;
        _fov = GetComponentInChildren<FOV>();
        standardShot.fireRate = 4f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_fov.targetting)
        {
            standardShot.target = _fov.target;
            LockOn();
            if (cooldown <= 0)
            {
                Engage();
                cooldown = 1f / standardShot.fireRate;
            }

            cooldown -= Time.deltaTime;
        }
        else
        {
            rotatePoint.transform.localRotation = Quaternion.Slerp(rotatePoint.transform.localRotation,standardShot.startPosition.rotation, snapSpeed * Time.deltaTime );
        }
    }

    private void LockOn()
    {
        if (standardShot.target != null)
        {
            step = speed * Time.deltaTime;
            var lookPos = standardShot.target.transform.position - rotatePoint.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            rotatePoint.transform.localRotation = Quaternion.Slerp(rotatePoint.transform.localRotation, rotation,  speed * Time.deltaTime);   
        } 
    }

    private void Engage()
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
        Projectile proj = bullet.GetComponent<Projectile>();
        if (proj != null)
        {
            proj.SeekTarget(standardShot.target.transform);
        }
    }
}
