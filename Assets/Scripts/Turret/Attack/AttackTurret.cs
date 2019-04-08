using UnityEngine;

namespace Turret
{
    public class AttackTurret : TurretBase
    {
        public int fireRate { get; set; }
        
        public AttackTurret(): base()
        {
            
        }

        public override void Action()
        {
            base.Action();
            //Action is meant to attack enemy targets
            Debug.Log("attack action");
        }

    }
}
