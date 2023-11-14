using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.UsingTest
{
    public class Store
    {
        public string[] Name = new string[4];
        public int[] Health = new int[4];
        public int[] DEF = new int[4];
        public int[] ATK = new int[4];
        public int[] Gold = new int[4];

        public Store(EquipMentA[] equip)
        {

            for (int i = 0; i < equip.Length; i++)
            {
                Name[i] = equip[i].Name;
                ATK[i] = equip[i].ATK;
                Health[i] = equip[i].Health;
                DEF[i] = equip[i].DEF;
                Gold[i] = equip[i].Gold;
            }
        }
        public void StoreTxt()
        {
            var table = new ConsoleTable(" 이름 ", " 공격력 ", " 체력 ", " 방어력 ", " 골드 ");
            for (int i = 0; i < Name.Length; i++)
            {
                table.AddRow(Name[i], ATK[i], Health[i], DEF[i], Gold[i]);
            }
            table.Write();

            Console.WriteLine("===============");
            Console.WriteLine("= 1. 구매 =");
            Console.WriteLine("= 2. 나가기   =");
            Console.WriteLine("===============");
        }
        public void Buy(EquipMentA[] store)
        {

            var table = new ConsoleTable(" 번호 ", "        이름        ", " 공격력 ", " 체력 ", " 방어력 ", "골드");
            for (int i = 0; i < Name.Length; i++)
            {
                string Ename = store[i].Name;
                if (store[i].CheckHave == true)
                {
                    Ename = Ename + " [구매 완료] ";
                }
                table.AddRow($" {i + 1} ", $" {Ename} ", $"{store[i].ATK}", $"{store[i].Health}", $"{store[i].DEF}", store[i].Gold);
                Console.ResetColor();
            }
            table.Write();

            Console.WriteLine("==========================");
            Console.WriteLine("=       0. 돌아가기      =");
            Console.WriteLine($"=  장비번호 입력시 구매  =");
            Console.WriteLine("==========================");

        }
        public void PurchaseEquipment(EquipMentA[] store, Character player, int num)
        {

            Console.Clear();
            Console.Write($"소지금 : {player.Gold} G\n필요Gold : {store[num].Gold}\n");
            if (store[num].CheckEquip == true)
            {
                Console.WriteLine("이미 구매하신 장비입니다.");
                return;
            }

            Console.Write("장비를 구매하시겠습니까? (y/n): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                if (player.Gold >= store[num].Gold)
                {
                    Console.WriteLine("장비를 구매합니다!");
                    store[num].CheckHave = true;
                    player.Gold -= store[num].Gold;
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }

            }
            else
            {
                Console.WriteLine("장비 구매를 취소했습니다.");
            }

        }
    }
}
