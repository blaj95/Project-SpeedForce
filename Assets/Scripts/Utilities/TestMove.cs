using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float speed;

    public Transform pos1;

    public Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        pos2 = GameObject.Find("Pos2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,pos2.position,speed*Time.deltaTime);
    }
}
