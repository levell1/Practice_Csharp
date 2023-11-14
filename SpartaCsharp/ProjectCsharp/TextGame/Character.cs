using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }
        public int Gold { get; set; }

        public Character(string name, string class1, int level, int atk, int def, int health, int gold) // 플레이어 초기값
        {
            Level = level;
            Name = name;
            Class = class1;
            ATK = atk;
            DEF = def;
            Health = health;
            Gold = gold;
        }

        public void PlayerStat(EquipMentA[] equip)
        {
            int[] eqiopStats = new int[7];
            String[] eqiopName = new String[7] { " (미착용) ", " (미착용) ", " (미착용) ", " (미착용) ", " (미착용) ", " (미착용)", "(미착용) " };
            for (int i = 0; i < equip.Length; i++)
            {
                if (equip[i].CheckEquip == true)
                {
                    eqiopName[i] = equip[i].Name;
                    eqiopStats[0] += equip[i].ATK;
                    eqiopStats[1] += equip[i].DEF;
                    eqiopStats[2] += equip[i].Health;
                }
            }
            var table = new ConsoleTable($" ", $" {Name} ", $" {Class} ", "  ");
            table.AddRow(" 스탯 ", " 총스탯 ", " 기본스탯 ", " + 장비")
                 .AddRow(" 공격력 ", $"{ATK + eqiopStats[0]} ", $" {ATK} ", $" ({eqiopStats[0]})")
                 .AddRow(" 방어력 ", $"{DEF + eqiopStats[1]}", $" {DEF} ", $" ({eqiopStats[1]}) ")
                 .AddRow(" 체  력 ", $"{Health + eqiopStats[2]}", $" {Health} ", $" ({eqiopStats[2]}) ")
                 .AddRow("", " ", " ", " ")
                 .AddRow(" 장비 ", $" {eqiopName[0]} ", $" {eqiopName[1]} ", $" {eqiopName[2]} ")
                 .AddRow($" {eqiopName[3]} ", $" {eqiopName[4]} ", $" {eqiopName[5]} ", $" {eqiopName[6]} ")
                 .AddRow("", " ", " ", " ")
                 .AddRow(" 소지금 ", " 골드(G) ", " ", " ")
                 .AddRow("   ", $" {Gold} G ", "", "");
            table.Write();
            Console.WriteLine("=============");
            Console.WriteLine("= 1. 나가기 =");
            Console.WriteLine("=============");
        }
    }

}
