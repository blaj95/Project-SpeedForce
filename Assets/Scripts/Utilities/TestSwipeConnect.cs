﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipeConnect : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer line;
    public TrailRenderer trail;
    public Transform cursor;
    public Rigidbody2D cursorRB;
    public GameObject linePrefab;
    public int currentLineIndex;
    public float distanceThreshold;
    public float pointDistance;

    public bool inTurret;
    public bool inBattery;

    // TODO: MOVE TO SEPARATE TURRET MANAGER AND CALL STATIC
    public TurretBase2D selectedTurret;
    public BatteryBase selectedBattery;

    public BatteryBase currentBattery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        cursorRB.MovePosition(screenPos);

        Touch touch = Input.touches.Length > 0 ? Input.GetTouch(0) : new Touch();
        //First click down
        if (Input.GetMouseButtonDown(0) || touch.phase == TouchPhase.Stationary)
        {
            if (inBattery)
            {
                selectedBattery = currentBattery;
                if (selectedBattery.connectionCount >= selectedBattery.countMax)
                {
                    Debug.Log("Battery Maxed Out");
                    return;   
                }

                Debug.Log("Battery Selected");
                line.enabled = true;
                line.positionCount = 2;
                line.SetPosition(0,selectedBattery.transform.position);
                line.SetPosition(1,cursor.position);
            }
        }
        else if (Input.GetMouseButton(0) ) // || touch.phase == TouchPhase.Moved)
        {
            //If inTurret, line position snaps to it, if not, follow cursor
            line.SetPosition(currentLineIndex, !inTurret ? cursor.position : selectedTurret.transform.position);

            pointDistance = Vector3.Distance(line.GetPosition(currentLineIndex-1), line.GetPosition(currentLineIndex));
            
            // CAN EVENTUALLY USE THIS LOGIC FOR CONNECTION DISTANCE RULES
            // if (pointDistance > distanceThreshold)
            // {
            //     line.positionCount+=1;
            //     line.SetPosition(currentLineIndex + 1,screenPos);
            //     currentLineIndex += 1;
            // }
        }
        else if (Input.GetMouseButtonUp(0) && line.enabled)// || touch.phase == TouchPhase.Ended)
        {
            if (inTurret)
            {
                //Check to see if the turret already has a connection
                if (selectedTurret.connectionState == TurretBase2D.ConnectionState.CONNECTED)
                {
                    Debug.Log(selectedTurret.name + " is already connected to a battery");
                    return;
                }
                //If not set connection
                selectedTurret.connectionState = TurretBase2D.ConnectionState.CONNECTED;
                selectedTurret.highlight.enabled = true;
                line.transform.parent = null;
                LineRenderer newLine = Instantiate(linePrefab, cursor.position, Quaternion.identity, cursor).GetComponent<LineRenderer>();
                line = newLine;
                currentLineIndex = 1;   
                selectedBattery.OnConnectionMade(selectedTurret);
            }
            else
            {
                currentLineIndex = 1;   
                line.positionCount = 0;
                line.enabled = false;
            }
            selectedBattery = null;
        }
    }

    public void TurretEntered(TurretBase2D turret)
    {
        inTurret = true;
        selectedTurret = turret;
    }
    
    public void TurretLeft(TurretBase2D turret)
    {
        inTurret = false;
        selectedTurret = null;
    }

    public void BatteryEntered(BatteryBase battery)
    {
        currentBattery = battery;
        inBattery = true;
    }
    
    public void BatteryLeft(BatteryBase battery)
    { 
        currentBattery = null;
        inBattery = false;
    }
}
