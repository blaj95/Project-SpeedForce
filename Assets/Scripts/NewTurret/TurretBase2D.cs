using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase2D : MonoBehaviour
{
    public TestSwipeConnect swipeManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        swipeManager.TurretEntered(this);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        swipeManager.TurretLeft(this);
    }
}
