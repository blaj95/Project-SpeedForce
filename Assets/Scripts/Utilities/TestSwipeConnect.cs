using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipeConnect : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer line;
    public TrailRenderer trail;
    public Transform cursor;
    public GameObject linePrefab;
    public int currentLineIndex;
    public float distanceThreshold;
    public float pointDistance;

    public bool inTurret;
    public bool inBattery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        cursor.position = screenPos; 
        
        //First click down
        if (Input.GetMouseButtonDown(0))
        {
            if (inBattery)
            {
                line.enabled = true;
                line.positionCount = 2;
                line.SetPosition(0,screenPos);   
                Debug.Log("Battery Selected");
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            // Vector3 screenPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            // cursor.position = screenPos;
            line.SetPosition(currentLineIndex,cursor.position);
            
            pointDistance = Vector3.Distance(line.GetPosition(currentLineIndex-1), line.GetPosition(currentLineIndex));
            
            if (pointDistance > distanceThreshold)
            {
                line.positionCount+=1;
                line.SetPosition(currentLineIndex + 1,screenPos);
                currentLineIndex += 1;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (inTurret)
            {
                // line.enabled = false;
                line.transform.parent = null;
                LineRenderer newLine = Instantiate(linePrefab, cursor.position, Quaternion.identity, cursor).GetComponent<LineRenderer>();
                line = newLine;
                currentLineIndex = 1;   
            }
            else
            {
                currentLineIndex = 1;   
                line.positionCount = 0;
                line.enabled = false;
            }
        }
        
    }

    public void TurretEntered(TurretBase2D turret)
    {
        inTurret = true;
    }
    
    public void TurretLeft(TurretBase2D turret)
    {
        inTurret = false;
    }

    public void BatteryEntered(BatteryBase battery)
    {
        inBattery = true;
    }
    
    public void BatteryLeft(BatteryBase battery)
    {
        inBattery = false;
    }
}
