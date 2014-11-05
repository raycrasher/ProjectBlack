using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Combat
{
    public class AttackMode
    {

        public AttackMode() { }
        public AttackMode(string name, AttackType type, string desc, IEnumerable<string> announcements, IEnumerable<DamageProfile> profile)
        {
            Name = name;
            Description = desc;
            Announcements = announcements.ToArray();
            Profile = profile.ToArray();
            Type = type;
        }

        public string Name;
        public AttackType Type;
        public string Description;
        public string[] Announcements;
        public DamageProfile[] Profile;

        public void Attack(IDamageable obj)
        {

        }
    }
}
