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
            EquipmentA[] equipment = new EquipmentA[2];
            equipment[0] = new EquipmentA("갑옷", 0 ,100, 10,true);
            equipment[1] = new EquipmentA("투구", 0, 50, 5,false);
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
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========");
            Console.WriteLine("  ┏   ┓             ◆");
            Console.WriteLine(" |      |          └┼┐ ");
            Console.WriteLine("|        |         ┌│  ");
            Console.WriteLine("==================================================  \n\n");
            Console.WriteLine("1. 상태보기 ");
            Console.WriteLine("2. 인벤토리 ");
            Console.WriteLine("=========== ");

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
            int[] eqiopstats = new int[3];
            for (int i = 0; i < equip.Length; i++)
            {
                eqiopstats[0] += equip[i].ATK;
                eqiopstats[1] += equip[i].DEF;
                eqiopstats[2] += equip[i].Health;
            }
            var table = new ConsoleTable($"{Name}", $"({Class})", " "," ");
            table.AddRow(" 스텟 ", " 기본스텟 ", "장비스텟 ", "총스텟")
                 .AddRow($"공격력", $"{ATK}",$" ({eqiopstats[0]})", $"{ATK}")
                 .AddRow($"방어력", $"{DEF}", $" ({eqiopstats[1]})", $"{DEF})
                 .AddRow($"체  력", $"{Health}", $" ({eqiopstats[2]})", $"{Health})
                 .AddRow($"골  드", $"{Gold}" , " G");
            table.Write();
            Console.WriteLine("1. 나가기");
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

        public string[] Name = new string[2];
        public int[] Health = new int[2];
        public int[] DEF = new int[2];
        public int[] ATK = new int[2];

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
            var table = new ConsoleTable(" 이름 ", " 공격력", "체력", "방어력");
            for (int i = 0; i < Name.Length; i++)
            {
                table.AddRow($"{Name[i]}", $"{ATK[i]}", $"{Health[i]}", $"{DEF[i]}");
            }
            table.Write();

            Console.WriteLine("1. 장착관리");
            Console.WriteLine("2. 나가기");
        }
        public void InventoryEquip(EquipmentA[] equip)
        {
            string checkE = "";
            var table = new ConsoleTable(" 이름 ", " 공격력", "체력", "방어력");
            for (int i = 0; i < Name.Length; i++)
            {
                string Ename = equip[i].Name;
                checkE = Ename.Substring(Ename.Length-1);
                if (equip[i].Isequip == true && checkE != "E")
                {
                    Ename = Ename + " E";
                }
                else if (equip[i].Isequip == false && checkE == "E") 
                {
                    Ename = Ename.Substring(0, Ename.Length - 2);
                }
                table.AddRow($"{Ename}", $"{equip[i].ATK}", $"{equip[i].Health}", $"{equip[i].DEF}");
            }
            table.Write();

            Console.WriteLine("장착할 아이템의 번호를 눌러주세요. (0. 돌아가기)");

        }
        public void EquipCheck(EquipmentA[] equip, int num)
        {
            equip[num].Isequip = !equip[num].Isequip;
        }
    }
}
