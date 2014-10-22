using FarseerPhysics.Dynamics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBlack.Utilities;

namespace ProjectBlack
{
    public class CharacterComponent : Component
    {
        public Transformable Transform;
        public Body PhysicsBody;
        
#region Stats
        public FloatStat Strength;
        public FloatStat Agility;
        public FloatStat Vitality;
        public FloatStat Dexterity;
        public FloatStat Wisdom;
        public FloatStat Intelligence;
        public FloatStat Perception;
        public FloatStat Luck;

        public FloatStat WalkSpeed;
        public FloatStat RunSpeed;
        public FloatStat SwimSpeed;
        public FloatStat JumpSpeed;
        public FloatStat FlySpeed;

        public FloatStat MeleeDamage;
        public FloatStat MeleeSpeed;
        public FloatStat MeleeAccuracy;
        public FloatStat RangedDamage;
        public FloatStat RangedSpeed;
        public FloatStat RangedAccuracy;

        public FloatStat MeleeDodge;
        public FloatStat RangedDodge;
        public FloatStat MeleeBlock;
        public FloatStat RangedBlock;

        public FloatStat Hunger;
        public FloatStat HungerRate;
        public FloatStat Thirst;
        public FloatStat ThirstRate;
        public FloatStat Sleep;
        public FloatStat SleepRate;
        public FloatStat Fatigue;
        public FloatStat FatigueRate;
        public FloatStat Breath;
        public FloatStat BreathRate;
        public FloatStat Morale;
        public FloatStat MoraleRate;
        public FloatStat Breath;
        public FloatStat BreathRate;

#endregion
        public override void Start()
        {
            Transform = GetComponent<TransformComponent>().Transform;
            PhysicsBody = GetComponent<Physics.RigidBodyComponent>().Body;
        }

        protected void Update() { 
            
        }
    }
}
