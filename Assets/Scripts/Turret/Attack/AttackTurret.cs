using UnityEngine;

namespace Turret
{
    public class AttackTurret : TurretBase
    {
        public float fireRate { get; set; }

        public Transform firePoint;

        public Transform startPosition;

        public Collider FOV;

        public GameObject target;
        
        public AttackTurret(): base()
        {
            
        }

        public override void Action()
        {
            base.Action();
            //Action is meant to attack enemy targets
           
            
        }
        
        
        
    }
}
