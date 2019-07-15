using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shockwave Turret, damages all enemies in area with a chance to slow
public class ShockwaveTurret : AttackTurret
{
    public GameObject ShockArea;

    private SphereCollider shockCollider;
    private MeshRenderer shockMesh;
    
    public override void Start()
    {
        shockMesh = transform.GetChild(0).GetComponent<MeshRenderer>();
        SetStats(10,TurretType.ATTACK);
        FireRate = .33f;
        damage = 1f;
        Cost = 75f;
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
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
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
        shockMesh.enabled = true;
        yield return new WaitForSeconds(.5f);
        shockMesh.enabled = false;
    }
    
    public override float CheckCost()
    {
        float cost = 75f;
        return cost;
    }
}
