using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week5_SimpleRpg.Character
{
    class Dragon : Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }
        public Dragon(string name)
        {
            Name = name;
            Health = 1000; // 초기 체력
            Attack = 70; // 초기 공격력
            IsDead = false;
        }
    }
}
