using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 60f;

    public float damage;    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Hit();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void SeekTarget(Transform _target)
    {
        target = _target;
    }

    void Hit()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.OnHit(damage);
        Destroy(gameObject);
    }
}
