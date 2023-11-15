using System;
using System.ComponentModel;
using Week5_SimpleRpg.Character;

namespace Week5_SimpleRpg.Item
{
    interface IItem
    {
        public String Name { get; set; }

        public void Use(Warrior warrior) { 
            
        }
    }
    
    

}
