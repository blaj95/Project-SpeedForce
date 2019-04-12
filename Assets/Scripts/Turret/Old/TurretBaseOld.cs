namespace Turret
{
    public class TurretBaseOld
    {
        public enum TurretType
        {
            ATTACK,
            DEFENSE,
            BUFF
        }

        public TurretType type;

        public float Health { get; set; }

        private float experience;

        public float Experience
        {
            get => experience;
            set => experience = value;
        }

        public float TurretLevel
        {
            get => experience / 1000f;
            set => experience = value * 1000f;
        }

        //Static variables are constant across all classes, if it's changed in one place its changed in the rest
        //Can be called without reference to a class, even if it's a method
        public static int turretCount = 0;

        public void SetUp(TurretType _type)
        {
            _type = type;
            experience = 0;
        }

        public virtual void Action()
        {
            //Action that a turret automatically produces
        }
    }
}
