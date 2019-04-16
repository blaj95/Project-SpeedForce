using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shockwave Turret, damages all enemies in area with a chance to slow
public class ShockwaveTurret : AttackTurret
{
    public GameObject ShockArea;

    private SphereCollider shockCollider;
    
    public override void Start()
    {
        shockCollider = GetComponentInChildren<SphereCollider>();
        Debug.Log(shockCollider.name);
        SetStats(10,TurretType.ATTACK);
        FireRate = .33f;
        damage = 1f;
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
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, shockCollider.radius * shockCollider.transform.localScale.z);
            foreach (Collider enemy in hitColliders)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    Enemy e = enemy.GetComponent<Enemy>();
                    e.OnHit(damage);
                    //slow
                    e.speed = e.speed * .66f;

                }
            }
            

            Cooldown = 1 / FireRate;
        }

        Cooldown -= Time.deltaTime;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere (transform.position, 3);
    }

    IEnumerator Shockwave()
    {
        ShockArea.SetActive(true);
        yield return new WaitForSeconds(.5f);
        ShockArea.SetActive(false);
    }
}
