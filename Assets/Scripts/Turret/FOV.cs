using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public bool targetting;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (target == null)
        {
            target = null;
            targetting = false;
        }
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            targetting = true;
            target = other.gameObject;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            targetting = false;
            target = null;
        }
    }
}
