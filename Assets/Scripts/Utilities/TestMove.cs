using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float speed;

    private Transform targetPoint;

    private int wavePointIndex = 0;

    private Enemy enemy;
//    public Transform pos1;
//
//    public Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = Waypoints.points[0];
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position,pos2.position,speed*Time.deltaTime);
        Vector3 dir = targetPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetPoint.position) <= .2f)
        {
            NextWaypoint();
        }
    }

    private void NextWaypoint()
    {
        if(wavePointIndex>=Waypoints.points.Length-1)
            return;
        
        wavePointIndex++;
        targetPoint = Waypoints.points[wavePointIndex];
    }
}
