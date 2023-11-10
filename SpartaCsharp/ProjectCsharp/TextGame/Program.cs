using ConsoleTables;
using System;
using System.Security.Claims;
using System.Xml.Linq;

namespace TextGame
{
    internal class Program
    {


        // 2 . 상점의 아이템 중에서 나만의 장비를 구성하는 부분이 포인트입니다.
        // 3 . 장비는 여러개의 데이터가 함께 있는 만큼 객체나 구조체를 활용하는 편이 효율적 입니다.
        // (이름, 가격, 효과, 설명 등…)
        // 4 . 관련된 여러 데이터를 다루는 부분은 배열이 도움이 됩니다.
        static void Main(string[] args)
        {

            ConsoleText _consoleText = new ConsoleText();

            String name;
            int _actionFirst = 0;
            int _actionIn = 0;
            bool _checkNum = true;
            bool _gamgeEnd = false;

            name = _consoleText.InputName();

            Character _player = new Character(name, "전사", 1, 10, 5, 100, 1500);
            _consoleText.StartTxt();
            // 배열부분 LIST로 변경할 생각.
            EquipmentA[] equipment = new EquipmentA[4];
            equipment[0] = new EquipmentA("무쇠갑옷", 0 ,100, 10,true);
            equipment[1] = new EquipmentA("쇠 투구", 0, 70, 7, false);
            equipment[2] = new EquipmentA("낡은 검", 2, 0, 0, true);
            equipment[3] = new EquipmentA("쇠 검", 13, 0, 0, false);
            Inventory inventory = new Inventory(equipment);
            while (_gamgeEnd == false)
            {
                _actionFirst = 0;
                _actionIn = 0;
                _checkNum = true;
                _consoleText.GoDungeonTxt();
                _actionFirst = _consoleText.SelectAction();
                switch (_actionFirst)
                {
                    case 1:
                        while (_checkNum)
                        {
                            _player.PlayerStat(equipment);
                            _actionIn = _consoleText.SelectAction();
                            if (_actionIn == 1)
                            {
                                _checkNum = false;
                            }
                        }
                        break;

                    case 2:
                        while (_checkNum)
                        {
                            inventory.InventoryTxt();
                            _actionIn = _consoleText.SelectAction();
                            if (_actionIn == 1)
                            {
                                while (_actionIn != 0)
                                {
                                    inventory.InventoryEquip(equipment);
                                    _actionIn = _consoleText.SelectAction();
                                    while (_actionIn > equipment.Length)
                                    {
                                        inventory.InventoryEquip(equipment);
                                        _actionIn = _consoleText.SelectAction();
                                        Console.WriteLine($" 다시 입력해주세요( 1 ~ {equipment.Length} )");
                                    }
                                    if (_actionIn != 0) {
                                        inventory.EquipCheck(equipment, _actionIn - 1);
                                    }
                                    
                                }
                                //장비관리
                            }
                            if (_actionIn == 2)
                            {
                                _checkNum = false;
                            }
                        }
                        break;

                    case 3:
                        _gamgeEnd = true;
                        break;
                    default:
                        Console.WriteLine("          다시 입력해주세요( 1 ~ 2 )");
                        break;
                }

            }
            Console.WriteLine("게임종료");
            Console.ReadLine();
        }


    }
    public class ConsoleText
    {

        public string Name { get; set; }
        public int ChooseAction { get; set; }
        public void StartTxt()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"       {Name}님 마을에 오신것을 환영합니다.       ");
            Console.WriteLine("==================================================\n\n\n");
        }
        public String InputName()
        {
            Console.Write("이름을 입력해 주세요\n이름 : ");
            Name = Console.ReadLine();
            Console.Clear();
            return Name;
        }
        public void GoDungeonTxt()
        {
           
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆");
            Console.WriteLine(" |      |          └┼┐ ");
            Console.WriteLine("|        |         ┌│  ");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("===============");
            Console.WriteLine("= 1. 상태보기 =");
            Console.WriteLine("= 2. 인벤토리 =");
            Console.WriteLine("===============");

        }

        public int SelectAction()
        {
            ChooseAction = int.Parse(Console.ReadLine()); // 숫자 아닐경우 예외처리 하면 좋을 거 같다.if대신 예외처리 배우면 활용
            Console.Clear();
            return ChooseAction;
        }
    }

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

        public void PlayerStat(EquipmentA[] equip)
        {
            int[] eqiopStats = new int[7];
            String[] eqiopName = new String[7] { " (미착용) ", " (미착용) ", " (미착용) ", " (미착용) ", " (미착용) ", " (미착용)", "(미착용) "};
            for (int i = 0; i < equip.Length; i++)
            {
                
                if (equip[i].Isequip ==true)
                {
                    eqiopName[i] = equip[i].Name;
                    eqiopStats[0] += equip[i].ATK;
                    eqiopStats[1] += equip[i].DEF;
                    eqiopStats[2] += equip[i].Health;
                }
            }
            var table = new ConsoleTable($" ", $" {Name} ", $" {Class} ", "  ");
            table.AddRow(" 스텟 ", " 기본스텟 ", " 장비스텟 ", " 총스텟 ")
                 .AddRow($" 공격력 ", $"{ATK}" , $" ({eqiopStats[0]}) ", $" {ATK + eqiopStats[0]} ")
                 .AddRow($" 방어력 ", $"{DEF}", $" ({eqiopStats[1]}) ", $" {DEF + eqiopStats[1]} ")
                 .AddRow($" 체  력 ", $"{Health}", $" ({eqiopStats[2]}) ", $" {Health + eqiopStats[2]} ")
                 .AddRow($"", $" ", $" ", $" ")
                 .AddRow($" 장비 ", $" {eqiopName[0]} ", $" {eqiopName[1]} ", $" {eqiopName[2]} ")
                 .AddRow($" {eqiopName[3]} ", $" {eqiopName[4]} " , $" {eqiopName[5]} ", $" {eqiopName[6]} ")
                 .AddRow($"", $" ", $" ", $" ")
                 .AddRow($" 소지금 ", $" 골드(G) ", $" ", $" ")
                 .AddRow($"   ", $" {Gold} G ", "","");
            table.Write();
            Console.WriteLine("=============");
            Console.WriteLine("= 1. 나가기 =");
            Console.WriteLine("=============");
        }
    }
    public class Weapons
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public Weapons(string name, int aTK)
        {
            Name = name;
            ATK = aTK;
        }
    }



    public class EquipmentA
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }

        public bool Isequip { get; set; }

        public EquipmentA(String name, int atk, int Hp, int Def,bool equip)
        {
            Name = name;
            ATK = atk;
            Health = Hp;
            DEF = Def;
            Isequip = equip;
        }
    }

    public class Inventory
    {

        public string[] Name = new string[4];
        public int[] Health = new int[4];
        public int[] DEF = new int[4];
        public int[] ATK = new int[4];

        public Inventory(EquipmentA[] equip) { 

            for (int i = 0; i < equip.Length; i++)
            {
                Name[i] = equip[i].Name;
                ATK[i] = equip[i].ATK;
                Health[i] = equip[i].Health;
                DEF[i] = equip[i].DEF;
            }
        }
        public void InventoryTxt()
        {
            var table = new ConsoleTable(" 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < Name.Length; i++)
            {
                table.AddRow($"{Name[i]}", $"{ATK[i]}", $"{Health[i]}", $"{DEF[i]}");
            }
            table.Write();

            Console.WriteLine("===============");
            Console.WriteLine("= 1. 장착관리 =");
            Console.WriteLine("= 2. 나가기   =");
            Console.WriteLine("===============");
        }
        public void InventoryEquip(EquipmentA[] equip)
        {
            string checkE = "";
            var table = new ConsoleTable(" 장비번호 ", " 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < Name.Length; i++)
            {
                string Ename = equip[i].Name;
                checkE = Ename.Substring(Ename.Length-2);
                if (equip[i].Isequip == true && checkE != "E")
                {
                    Ename = Ename + " [E]";
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (equip[i].Isequip == false && checkE == "E") 
                {
                    Ename = Ename.Substring(0, Ename.Length - 4);
                }
                table.AddRow($" {i+1} ",$" {Ename} ", $"{equip[i].ATK}", $"{equip[i].Health}", $"{equip[i].DEF}");
                Console.ResetColor();
            }
            table.Write();

            Console.WriteLine("==========================");
            Console.WriteLine("=       0. 돌아가기      =");
            Console.WriteLine($"=  장비번호 입력시 장착  =");
            Console.WriteLine("==========================");


        }
        public void EquipCheck(EquipmentA[] equip, int num)
        {
            equip[num].Isequip = !equip[num].Isequip;
        }
    }
}
