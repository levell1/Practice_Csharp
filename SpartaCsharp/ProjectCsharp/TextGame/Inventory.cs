using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Inventory
    {
        public string[] Name = new string[4];
        public int[] Health = new int[4];
        public int[] DEF = new int[4];
        public int[] ATK = new int[4];

        public Inventory(EquipMentA[] equip)
        {

            for (int i = 0; i < equip.Length; i++)
            {
                Name[i] = equip[i].Name;
                ATK[i] = equip[i].ATK;
                Health[i] = equip[i].Health;
                DEF[i] = equip[i].DEF;
            }
        }
        public void InventoryTxt(EquipMentA[] StoreEquip)
        {
            var table = new ConsoleTable(" 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < Name.Length; i++)
            {
                table.AddRow(Name[i], ATK[i], Health[i], DEF[i]);

            }
            for (int i = 0; i < StoreEquip.Length; i++)
            {
                if (StoreEquip[i].CheckHave == true)
                {
                    table.AddRow(StoreEquip[i].Name, StoreEquip[i].ATK, StoreEquip[i].Health, StoreEquip[i].DEF);
                }
            }

            table.Write();

            Console.WriteLine("===============");
            Console.WriteLine("= 1. 장착관리 =");
            Console.WriteLine("= 2. 나가기   =");
            Console.WriteLine("===============");
        }
        public void InventoryEquip(EquipMentA[] equip, EquipMentA[] StoreEquip)
        {
            string checkE = "";
            var table = new ConsoleTable(" 번호 ", "        이름        ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < equip.Length; i++)
            {
                string Ename = equip[i].Name;
                checkE = Ename.Substring(Ename.Length - 2);
                if (equip[i].CheckEquip == true && checkE != "E")
                {
                    Ename = Ename + " [E]";
                }
                else if (equip[i].CheckEquip == false && checkE == "E")
                {
                    Ename = Ename.Substring(0, Ename.Length - 4);
                }
                table.AddRow($" {i + 1} ", $" {Ename} ", $"{equip[i].ATK}", $"{equip[i].Health}", $"{equip[i].DEF}");
            }

            for (int i = 0; i < StoreEquip.Length; i++)
            {
                if (StoreEquip[i].CheckHave == true)
                {
                    string Ename = StoreEquip[i].Name;
                    checkE = Ename.Substring(Ename.Length - 2);
                    if (StoreEquip[i].CheckEquip == true && checkE != "E")
                    {
                        Ename = Ename + " [E]";
                    }
                    else if (StoreEquip[i].CheckEquip == false && checkE == "E")
                    {
                        Ename = Ename.Substring(0, Ename.Length - 4);
                    }
                    table.AddRow($" {i + equip.Length+1} ", $" {Ename} ", $"{StoreEquip[i].ATK}", $"{StoreEquip[i].Health}", $"{StoreEquip[i].DEF}");
                }
            }
            table.Write();

            Console.WriteLine("==========================");
            Console.WriteLine("=       0. 돌아가기      =");
            Console.WriteLine($"=  장비번호 입력시 장착  =");
            Console.WriteLine("==========================");

        }
        public void EquipCheck(EquipMentA[] equip, EquipMentA[] store, int num)
        {
            if (num <= 3)
            {
                equip[num].CheckEquip = !equip[num].CheckEquip;
            }
            else
            {
                store[num - 4].CheckEquip = !store[num - 4].CheckEquip;
            }

        }

    }

}
