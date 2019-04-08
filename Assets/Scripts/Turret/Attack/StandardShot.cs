using System.Collections;
using System.Collections.Generic;
using Turret;
using UnityEngine;

public class StandardShot : MonoBehaviour
{
    private AttackTurret aTurret;
    
    private int testInt;
    private int enemyMask = 1 << 19;
    public int speed;
    public GameObject rotatePoint;
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Setting Attack Turret");
        aTurret = new AttackTurret();
        aTurret.SetUp(TurretBase.TurretType.ATTACK);
        Debug.Log(aTurret.type.ToString());
        aTurret.Experience = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, Vector3.forward, out hit, 10000f, enemyMask))
        {
            Debug.Log("Found enemy");
            float step = speed * Time.deltaTime;
            var lookPos = hit.transform.position - rotatePoint.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            rotatePoint.transform.localRotation = Quaternion.Slerp(rotatePoint.transform.localRotation, rotation, Time.deltaTime * speed);
        }
        
        Debug.DrawRay(firePoint.transform.position,transform.forward);
    }
}
