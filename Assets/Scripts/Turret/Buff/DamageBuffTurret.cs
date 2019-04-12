using System.Collections;
using System.Collections.Generic;
using Turret;
using UnityEngine;

//On placement, turret will detect attack turrets in it's radius and buff the damage
//Only do one SphereCast on placement.
public class DamageBuffTurret : BuffTurret
{
    public List<GameObject> affectedTurrets;
    // Start is called before the first frame update
    void Start()
    {
        SetStats(10, TurretType.BUFF);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].CompareTag("Turret") && hitColliders[i].gameObject!= gameObject)
            {
                affectedTurrets.Add(hitColliders[i].gameObject);
            }

            i++;
        }

        foreach (GameObject turret in affectedTurrets)
        {
            TurretBase t = turret.GetComponent<TurretBase>();
            t.damage = t.damage * 1.5f;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere (transform.position, 5);
    }
    
   
}
