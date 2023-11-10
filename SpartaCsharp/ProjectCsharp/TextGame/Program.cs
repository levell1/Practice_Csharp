using ConsoleTables;
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
            int _chooseAction;
            bool _checkNum = true;

            name = _consoleText.InputName();

            Player _player = new Player(name);
            _consoleText.StartTxt();

            _chooseAction = _consoleText.GoDungeonTxt();

            while (_checkNum) {
                if (_chooseAction == 1)
                {
                    _checkNum = false;
                    _player.PlayerStat();
                }
                else if (_chooseAction == 2)
                {
                    _checkNum = false;
                    _consoleText.StartTxt();
                }
                else {
                    Console.WriteLine("다시 입력해주세요( 1 ~ 2 )");
                    _chooseAction = _consoleText.GoDungeonTxt();

                }
            }

        }

        
    }
    public class ConsoleText {

        public string Name { get; set; }
        public int ChooseAction { get; set; }
        public void StartTxt() {
            Console.WriteLine("==================================================");
            Console.WriteLine($"====== {Name}님 마을에 오신것을 환영합니다. =======");
            Console.WriteLine("==================================================\n\n\n");
        }
        public String InputName()
        {
            Console.Write("이름을 입력해 주세요\n이름 : ");
            Name = Console.ReadLine();
            Console.Clear();
            return Name;
        }
        public int GoDungeonTxt()
        {
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========");
            Console.WriteLine("  ┏   ┓");
            Console.WriteLine(" |      |");
            Console.WriteLine("|        |");
            Console.WriteLine("========== \n\n");
            Console.WriteLine("1. 상태 보기 ");
            Console.WriteLine("2. 인벤토리 ");
            Console.WriteLine("========== ");
            ChooseAction = int.Parse(Console.ReadLine());
            Console.Clear();
            return ChooseAction;
        }  
    }

    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }
        public int Gold { get; set; }
        

        public Player(string name) // 플레이어 초기값
        {
            Level = 0;
            Name = name;
            Class = "전사";
            ATK = 10;
            DEF = 5;
            Health = 100;
            Gold = 1500;
        }

        public void PlayerStat()
        {
            var table = new ConsoleTable("stats ", "point");
            table.AddRow(1, 2)
                 .AddRow($"{Name}", $"{Class}")
                 .AddRow($"공격력", $"{ATK}")
                 .AddRow($"방어력", $"{DEF}")
                 .AddRow($"체  력", $"{Health}")
                 .AddRow($"골  드", $"{Gold}");
            table.Write();
        }
        public void Stat() 
        { 
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} took {damage} damage. Current health: {Health}");
        }
    }
}