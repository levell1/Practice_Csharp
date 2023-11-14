using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class EquipMentA
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }

        public int Gold { get; set; }
        public bool CheckEquip { get; set; }
        public bool CheckHave { get; set; }

        public EquipMentA(String name, int atk, int Hp, int Def, int gold, bool equip, bool have)
        {
            Name = name;
            ATK = atk;
            Health = Hp;
            DEF = Def;
            Gold = gold;
            CheckEquip = equip;
            CheckHave = have;
        }
    }

}
