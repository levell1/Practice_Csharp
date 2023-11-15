using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_SimpleRpg.Character
{
    interface ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health<=0)
            {
                IsDead = true;
                Console.WriteLine($"{Name} 가사망하셨습니다.");
            }
            else
            {
                Console.WriteLine($"{Name} 가 {damage}의 데미지를 받았습니다.\nHP : {Health}");
            }
        }
    }
}
