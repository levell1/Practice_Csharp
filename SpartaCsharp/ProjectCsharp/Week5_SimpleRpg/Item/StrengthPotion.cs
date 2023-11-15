using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5_SimpleRpg.Character;

namespace Week5_SimpleRpg.Item
{
    class StrengthPotion : IItem
    {
        public String Name { get; set; }
        public StrengthPotion()
        {
            Name = "힘영약";
        }
        public void Use(Warrior warrior)
        {
            int increasePower = 10;
            warrior.Attack += increasePower;
            Console.WriteLine($"힘영약 사용. {warrior.Name} 의 공격력이 {increasePower}증가합니다.\n공격력 : {warrior.Attack}");

        }
    }
    }
}
