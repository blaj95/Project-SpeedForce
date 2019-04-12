using UnityEngine;

namespace Turret
{
    public class AttackTurretOld : TurretBaseOld
    {
        public float fireRate { get; set; }

        public Transform firePoint;

        public Transform startPosition;

        public Collider FOV;

        public GameObject target;
        
       

        public override void Action()
        {
            base.Action();
            //Action is meant to attack enemy targets
           
            
        }
        
        
        
    }
}
