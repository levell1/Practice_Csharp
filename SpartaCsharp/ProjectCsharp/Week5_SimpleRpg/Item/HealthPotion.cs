using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5_SimpleRpg.Character;

namespace Week5_SimpleRpg.Item
{
    class HealthPotion : IItem
    {
        public String Name { get; set; }

        public HealthPotion()
        {
            Name = "체력포션";
        }
        public void Use(Warrior warrior)
        {
            int heal = 50;
            warrior.Health += heal;
            if (warrior.Health > 100)
            {
                heal = 50 - (warrior.Health - 100);
                warrior.Health = 100;
            }
            Console.WriteLine($"체력포션 사용. {warrior.Name} 의 체력이 {heal}회복됩니다.\n체력 : {warrior.Health}");
            
        }
    }
}
