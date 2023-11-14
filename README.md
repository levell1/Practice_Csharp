

<BR><BR>

<center><H1> 개인과제 Text Game  </H1></center>



<br><br>

# TextGame
(C# - Console App)  
마을에서 시작해 상태, 인벤, 상점을 통하여 정비하는 기능을 만든 개인과제입니다.

<br>

# 1. 게임화면

**시작화면**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/78b9629b-93f0-4297-a7ee-28e6250cc86e)

**상태창**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/dc77df57-4a62-4861-a440-ba08e1088d68)

**장비장착**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/960ab939-fa5a-4957-aaac-ac48464bdbe2)

**상점**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/aa77cb7d-e154-45bd-ae8a-ebc8e4ba3f24)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b534aea9-30a3-4bf7-8bfa-eea409496d35)

<br>



# 2. 코드, 기능

> **기능** 
> - 캐릭터 정보창( 장비 스탯 반영 )  스탯, 장비, 소지금 보여주기
> - 인벤토리, 장착 관리 
> - 장비 구매 -> 인벤토리에 반영
> - 구매한 장비 장착 (배열미숙 버그확인)

<br>

<details>
<summary>전체 코드</summary>

<div class="notice--primary" markdown="1"> 

```c# 
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
            //List<EquipmentA> equipment = new List<EquipmentA>();
            EquipmentA[] equipment = new EquipmentA[4];
            EquipmentA[] storeEquipment = new EquipmentA[4];
            _equipSet();
            _storeSet();
            Inventory inventory = new Inventory(equipment);
            Store store = new Store(storeEquipment);

            // 배열부분 LIST로 변경할 생각.
            //List<EquipmentA> equipment1 = new List<EquipmentA>(equipment);
            //EquipmentA a = new EquipmentA("1", 1, 1, 1,1, true);
            //equipment1.Add(a);
            
            
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
                            _callStat();
                            if (_actionIn == 1)
                            {
                                _checkNum = false;
                            }
                        }
                        break;

                    case 2:
                        _selectEquip();
                        break;

                    case 3:
                        _selectStoreEquip();
                        break;

                    case 4:
                        _gamgeEnd = true;
                        break;
                    default:
                        Console.WriteLine("          다시 입력해주세요( 1 ~ 2 )");
                        break;
                }
            }
            Console.WriteLine("게임종료");
            Console.ReadLine();

            void _callEquip() {
                inventory.InventoryEquip(equipment,storeEquipment);
                _actionIn = _consoleText.SelectAction();
            }
            void _callStore()
            {
                store.Buy(storeEquipment);
                _actionIn = _consoleText.SelectAction();
            }

            void _callStat()
            {
                _player.PlayerStat(equipment);
                _actionIn = _consoleText.SelectAction();
            }

            void _selectEquip()
            {
                while (_checkNum)
                {
                    inventory.InventoryTxt(storeEquipment);
                    _actionIn = _consoleText.SelectAction();
                    if (_actionIn == 1)
                    {
                        while (_actionIn != 0)
                        {
                            _callEquip();
                            int count = 0;
                            for (int i = 0; i < storeEquipment.Length; i++)
                            {
                                if (storeEquipment[i].CheckHave==true)
                                {
                                    count++;
                                }
                            }

                            count = equipment.Length + count;
                            while (_actionIn > count)
                            {
                                _callEquip();
                                
                                Console.WriteLine($" 다시 입력해주세요( 1 ~ {count} )");
                            }
                            if (_actionIn != 0)
                            {
                                inventory.EquipCheck(equipment, storeEquipment, _actionIn - 1);

                            }

                        }
                        //장비관리
                    }
                    if (_actionIn == 2)
                    {
                        _checkNum = false;
                    }
                }
            }

            void _selectStoreEquip() {
                while (_checkNum)
                {
                    store.StoreTxt();
                    _actionIn = _consoleText.SelectAction();
                    if (_actionIn == 1)
                    {
                        while (_actionIn != 0)
                        {
                            _callStore();
                            while (_actionIn > storeEquipment.Length)
                            {
                                _callStore();
                                Console.WriteLine($" 다시 입력해주세요( 1 ~ {storeEquipment.Length} )");
                            }
                            if (_actionIn != 0)
                            {
                                store.PurchaseEquipment(storeEquipment,_player, _actionIn - 1);

                            }
                            

                        }
                        //장비관리
                    }
                    if (_actionIn == 2)
                    {
                        _checkNum = false;
                    }
                }
            }
            void _equipSet() {
                
                equipment[0] = new EquipmentA("무쇠갑옷", 0, 80, 10,1000, true,true);
                equipment[1] = new EquipmentA("쇠 투구", 0, 70, 7,700, false, true);
                equipment[2] = new EquipmentA("낡은 검", 5, 0, 0,500, true, true);
                equipment[3] = new EquipmentA("쇠 검", 13, 0, 0,1500, false, true);
            }
            void _storeSet()
            {
                storeEquipment[0] = new EquipmentA("천 장갑", 0, 30, 5,1000, false, false);
                storeEquipment[1] = new EquipmentA("낡은 활", 3, 0, 0,300, false, false);
                storeEquipment[2] = new EquipmentA("낡은 신발", 0, 20, 3,400, false, false);
                storeEquipment[3] = new EquipmentA("방패", 0, 100, 0,1200, false, false);
            }
            static int CheckValidInput(int min, int max)
            {
                while (true)
                {
                    string input = Console.ReadLine();

                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (parseSuccess)
                    {
                        if (ret >= min && ret <= max)
                            return ret;
                    }

                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
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
            Console.WriteLine("  ┏   ┓             ◆ ;");
            Console.WriteLine(" |      |          └┼┐ == ");
            Console.WriteLine("|        |         ┌│  ==");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("===============");
            Console.WriteLine("= 1. 상태보기 =");
            Console.WriteLine("= 2. 인벤토리 =");
            Console.WriteLine("= 3. 장비상점 =");
            Console.WriteLine("= 4. 게임종료 =");
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
                if (equip[i].CheckEquip ==true)
                {
                    eqiopName[i] = equip[i].Name;
                    eqiopStats[0] += equip[i].ATK;
                    eqiopStats[1] += equip[i].DEF;
                    eqiopStats[2] += equip[i].Health;
                }
            }
            var table = new ConsoleTable($" ", $" {Name} ", $" {Class} ", "  ");
            table.AddRow(" 스탯 ", " 총스탯 ", " 기본스탯 ", " + 장비")
                 .AddRow(" 공격력 ", $"{ATK + eqiopStats[0]} " , $" {ATK} ", $" ({eqiopStats[0]})")
                 .AddRow(" 방어력 ", $"{DEF + eqiopStats[1]}", $" {DEF} ", $" ({eqiopStats[1]}) ")
                 .AddRow(" 체  력 ", $"{Health + eqiopStats[2]}", $" {Health} ", $" ({eqiopStats[2]}) ")
                 .AddRow("", " ", " ", " ")
                 .AddRow(" 장비 ", $" {eqiopName[0]} ", $" {eqiopName[1]} ", $" {eqiopName[2]} ")
                 .AddRow($" {eqiopName[3]} ", $" {eqiopName[4]} " , $" {eqiopName[5]} ", $" {eqiopName[6]} ")
                 .AddRow("", " ", " ", " ")
                 .AddRow(" 소지금 ", " 골드(G) ", " ", " ")
                 .AddRow("   ", $" {Gold} G ", "","");
            table.Write();
            Console.WriteLine("=============");
            Console.WriteLine("= 1. 나가기 =");
            Console.WriteLine("=============");
        }
    }
   /*public class Weapons
   {
      public string Name { get; set; }
      public int ATK { get; set; }
      public Weapons(string name, int aTK)
      {
         Name = name;
         ATK = aTK;
      }
   }*/



    public class EquipmentA
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }

        public int Gold { get; set; }
        public bool CheckEquip { get; set; }
        public bool CheckHave { get; set; }

        public EquipmentA(String name, int atk, int Hp, int Def, int gold ,bool equip,bool have)
        {
            Name = name;
            ATK = atk;
            Health = Hp;
            DEF = Def;
            Gold = gold;
            CheckEquip = equip;
            CheckHave = have;
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
        public void InventoryTxt(EquipmentA[] StoreEquip)
        {
            var table = new ConsoleTable(" 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < Name.Length; i++)
            {
                table.AddRow(Name[i], ATK[i], Health[i], DEF[i]);

            }
            for (int i = 0; i < StoreEquip.Length; i++) {
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
        public void InventoryEquip(EquipmentA[] equip , EquipmentA[] StoreEquip)
        {
            string checkE = "";
            var table = new ConsoleTable(" 번호 ", "        이름        ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < equip.Length; i++)
            {
                string Ename = equip[i].Name;
                checkE = Ename.Substring(Ename.Length-2);
                if (equip[i].CheckEquip == true && checkE != "E")
                {
                    Ename = Ename + " [E]";
                }
                else if (equip[i].CheckEquip == false && checkE == "E") 
                {
                    Ename = Ename.Substring(0, Ename.Length - 4);
                }
                table.AddRow($" {i+1} ",$" {Ename} ", $"{equip[i].ATK}", $"{equip[i].Health}", $"{equip[i].DEF}");
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
                    table.AddRow($" {i + equip.Length} ", $" {Ename} ", $"{StoreEquip[i].ATK}", $"{StoreEquip[i].Health}", $"{StoreEquip[i].DEF}");
                }
            }
            table.Write();

            Console.WriteLine("==========================");
            Console.WriteLine("=       0. 돌아가기      =");
            Console.WriteLine($"=  장비번호 입력시 장착  =");
            Console.WriteLine("==========================");

        }
        public void EquipCheck(EquipmentA[] equip, EquipmentA[] store, int num)
        {
            if (num<=3)
            {
                equip[num].CheckEquip = !equip[num].CheckEquip;
            }
            else
            {
                store[num-4].CheckEquip = !store[num-4].CheckEquip;
            }

        }

    }

    public class Store
    {
        public string[] Name = new string[4];
        public int[] Health = new int[4];
        public int[] DEF = new int[4];
        public int[] ATK = new int[4];
        public int[] Gold = new int[4];

        public Store(EquipmentA[] equip)
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
        public void Buy(EquipmentA[] store)
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
        public void PurchaseEquipment(EquipmentA[] store,Character player, int num)
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


```
</div>

</details>

<br>

> **클래스**
> - **`class ConsoleText`**  
입, 출력부분으로 이루어진 메서드들이 포함된 클래스입니다.  
> - **`class Character`**  
생성자로 플레이어 초기값을 정하고, 플레이어 스탯을 보여주는 메서드로 구성되어 > - 있습니다.  
> - **`class EquipmentA`**  
장비의 정보를 담는 클래스입니다.  
> - **`class Inventory`**   
가지고 있는 장비를 보여주고, 장착, 스탯에 반영을 도와주는 클래스입니다.  
> - **`class Store`**   
상점의 장비를 보여주고, 구매를 진행하는 메서드로 구성된 클래스입니다.

<details>
<summary>class ConsoleText</summary>

<div class="notice--primary" markdown="1"> 

```c# 
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
        Console.WriteLine("  ┏   ┓             ◆ ;");
        Console.WriteLine(" |      |          └┼┐ == ");
        Console.WriteLine("|        |         ┌│  ==");
        Console.WriteLine("==================================================");
        Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
        Console.WriteLine("===============");
        Console.WriteLine("= 1. 상태보기 =");
        Console.WriteLine("= 2. 인벤토리 =");
        Console.WriteLine("= 3. 장비상점 =");
        Console.WriteLine("= 4. 게임종료 =");
        Console.WriteLine("===============");
    }

    public int SelectAction()
    {
        ChooseAction = int.Parse(Console.ReadLine()); // 숫자 아닐경우 예외처리 하면 좋을 거 같다.if대신 예외처리 배우면 활용
        Console.Clear();
        return ChooseAction;
    }
}
```
</div>
</details>

<details>
<summary>class Character</summary>

<div class="notice--primary" markdown="1"> 

```c# 
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
            if (equip[i].CheckEquip ==true)
            {
                eqiopName[i] = equip[i].Name;
                eqiopStats[0] += equip[i].ATK;
                eqiopStats[1] += equip[i].DEF;
                eqiopStats[2] += equip[i].Health;
            }
        }
        var table = new ConsoleTable($" ", $" {Name} ", $" {Class} ", "  ");
        table.AddRow(" 스탯 ", " 총스탯 ", " 기본스탯 ", " + 장비")
             .AddRow(" 공격력 ", $"{ATK + eqiopStats[0]} " , $" {ATK} ", $" ({eqiopStats[0]})")
             .AddRow(" 방어력 ", $"{DEF + eqiopStats[1]}", $" {DEF} ", $" ({eqiopStats[1]}) ")
             .AddRow(" 체  력 ", $"{Health + eqiopStats[2]}", $" {Health} ", $" ({eqiopStats[2]}) ")
             .AddRow("", " ", " ", " ")
             .AddRow(" 장비 ", $" {eqiopName[0]} ", $" {eqiopName[1]} ", $" {eqiopName[2]} ")
             .AddRow($" {eqiopName[3]} ", $" {eqiopName[4]} " , $" {eqiopName[5]} ", $" {eqiopName[6]} ")
             .AddRow("", " ", " ", " ")
             .AddRow(" 소지금 ", " 골드(G) ", " ", " ")
             .AddRow("   ", $" {Gold} G ", "","");
        table.Write();
        Console.WriteLine("=============");
        Console.WriteLine("= 1. 나가기 =");
        Console.WriteLine("=============");
    }
}
    
```
</div>
</details>

<details>
<summary>class EquipmentA</summary>

<div class="notice--primary" markdown="1"> 

```c# 
public class EquipmentA
{
    public string Name { get; set; }
    public int ATK { get; set; }
    public int Health { get; set; }
    public int DEF { get; set; }

    public int Gold { get; set; }
    public bool CheckEquip { get; set; }
    public bool CheckHave { get; set; }

    public EquipmentA(String name, int atk, int Hp, int Def, int gold ,bool equip,bool have)
    {
        Name = name;
        ATK = atk;
        Health = Hp;
        DEF = Def;
        Gold = gold;
        CheckEquip = equip;
        CheckHave = have;
    }
}

```
</div>
</details>
<details>
<summary>class Inventory</summary>

<div class="notice--primary" markdown="1"> 

```c# 
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
    public void InventoryTxt(EquipmentA[] StoreEquip)
    {
        var table = new ConsoleTable(" 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
        for (int i = 0; i < Name.Length; i++)
        {
            table.AddRow(Name[i], ATK[i], Health[i], DEF[i]);

        }
        for (int i = 0; i < StoreEquip.Length; i++) {
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
    public void InventoryEquip(EquipmentA[] equip , EquipmentA[] StoreEquip)
    {
        string checkE = "";
        var table = new ConsoleTable(" 번호 ", "        이름        ", " 공격력 ", " 체력 ", " 방어력 ");
        for (int i = 0; i < equip.Length; i++)
        {
            string Ename = equip[i].Name;
            checkE = Ename.Substring(Ename.Length-2);
            if (equip[i].CheckEquip == true && checkE != "E")
            {
                Ename = Ename + " [E]";
            }
            else if (equip[i].CheckEquip == false && checkE == "E") 
            {
                Ename = Ename.Substring(0, Ename.Length - 4);
            }
            table.AddRow($" {i+1} ",$" {Ename} ", $"{equip[i].ATK}", $"{equip[i].Health}", $"{equip[i].DEF}");
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
                table.AddRow($" {i + equip.Length} ", $" {Ename} ", $"{StoreEquip[i].ATK}", $"{StoreEquip[i].Health}", $"{StoreEquip[i].DEF}");
            }
        }
        table.Write();

        Console.WriteLine("==========================");
        Console.WriteLine("=       0. 돌아가기      =");
        Console.WriteLine($"=  장비번호 입력시 장착  =");
        Console.WriteLine("==========================");

    }
    public void EquipCheck(EquipmentA[] equip, EquipmentA[] store, int num)
    {
        if (num<=3)
        {
            equip[num].CheckEquip = !equip[num].CheckEquip;
        }
        else
        {
            store[num-4].CheckEquip = !store[num-4].CheckEquip;
        }

    }

}

```
</div>
</details>
<details>
<summary>class Store</summary>

<div class="notice--primary" markdown="1"> 

```c# 
public class Store
{
    public string[] Name = new string[4];
    public int[] Health = new int[4];
    public int[] DEF = new int[4];
    public int[] ATK = new int[4];
    public int[] Gold = new int[4];

    public Store(EquipmentA[] equip)
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
    public void Buy(EquipmentA[] store)
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
    public void PurchaseEquipment(EquipmentA[] store,Character player, int num)
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
```
</div>
</details>

<br>

> **Main**  
변수, 캐릭터초기값 지정, 인벤, 상점의(`_storeSet`, `_euipSet`) 장비들 배열(`equipment`, `storeEquipment`)에 저장, -> 번호를 입력하여 진행, 
잡담방에 올려주신 nuget(Console Table) 사용

<br>

# 3. 느낀점
게임 진행부분의 while, if의 조건을 단축할 수 없을까 고민했고, list, 상속, 클래스, 매서드 등 잘 사용하지 못하여 아쉬웠고, 사용하면서 조금 더 배운 과제였습니다.  
생각을 코드로 적고 코드들이 길어지며 클래스, 메서드, 변수명의 중요성을 꺠닫고, 중간에 수정 시 힘듦이 있어 처음부터 추가할 기능을 정하고, 코드의 구조를 짜고 시작하면 좋겠다고 느꼈습니다.

<br><br><br><br>

**11.14 피드백 후**

# 4. 피드백
<details>
<summary>피드백 내용</summary>
<div class="notice--primary" markdown="1"> 

```
필수기능과 추가기능에 대한 요청사항을 잘 이해하고 적절히 구현하였습니다.  
기능을 최대한 스스로 해결하려 한 모습이 느껴져서 좋습니다. 또한 기능개발에 따른 자료구조에 대한 고민까지 나아간 점이 좋습니다.  
Class에 필요한 정보(Data)와 기능(Function)을 적절하게 사용하셨습니다.  
코드에 필요한 클래스를 잘 생성하였지만 별도의 파일로 만들고 분리해보시길 추천드립니다.  
Items 클래스의 경우 상속을 이용해 부모-자식 클래스 관계로 재설계 해보세요. 해당 내용은 개인과제 설명의 예시 코드를 참고해보세요.  
swith문은 Enum을 활용해서 작성하면 가독성 측면에서 더 나은 코드가 됩니다.  
깃 커밋의 내용을 직관적이고 명확하게 적는 연습을 해보세요. Git commit message 규칙 이라는 키워드를 통해 학습하고 적용시켜보세요.  
ex)  
[ADD] 인벤토리 기능 추가  
[FIX] 정보출력 기능 버그 수정  
Readme 작성은 해당 프로젝트를 전반적으로 파악하기 양호하게 잘 작성하셨습니다.  
```
</div>

</details>

<br>

**개선점, 느낀점**  

> **개선점**  
&nbsp;&nbsp; [o] **1.&nbsp;Class 파일 나누기**  
&nbsp;&nbsp; [o] **2.&nbsp;EquipMent 경우 상속 재설계**  
&nbsp;&nbsp; [o] **3.&nbsp;깃 커밋 설명 잘 적기**  
&nbsp;&nbsp; [o] **4.&nbsp;switch enum 사용하기**   




> **개선**  
> **1.&nbsp;Class 파일 나누기** ( 팀장님이 알려주셨다. 🙇 )   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/683eb753-04e1-435c-8aa1-06579ba12052) &nbsp;&nbsp;
![image](https://github.com/levell1/levell1.github.io/assets/96651722/db76d506-d5fe-4fe5-9240-4cde375f62d6)  


> **2.&nbsp;EquipMent 경우 상속 재설계**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a92c4bfd-23db-46fe-841f-48db4d8f3cda)  


> **3.&nbsp;깃 커밋 설명 잘 적기**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/0668936c-cbfb-4554-bed3-3cd5cfd8f1f9)  

> **4.&nbsp;switch enum 사용하기**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/39da54db-0cf6-4d83-bfbf-ca9cc827a6f5) &nbsp;&nbsp;
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9cfb272a-78c5-41dc-ab32-da4ef4cba574)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f2564269-2671-4c22-89df-5acdcfbb6e6d)

<BR>

> **느낀점**  
**<u>파일을 나누니까</u>** 개발 도중 원하는 내용을 보고 싶을 때 기존 방식에 비해 너무 편하고 쉬웠습니다.  
(저희조 팀장님이 이해하기 쉽게 설명해 주셨습니다. 감사합니다.🙇)  
**<u>상속</u>** 의 경우 코드 기획? 설계부분이 미숙해 아직 완벽하게 이해하지 못하고 사용해 보았습니다, 많이 사용해 보며 확실하게 알 수 있게 하는 게 목표입니다.  
**<u>깃 커밋</u>** 설명을 적고 협업 시 원활한 소통이 가능할 거 같다고 느꼈습니다.  
**<u>switch enum 사용</u>** 후 가독성이 좋아진 거 같다, case 1~4보단 무슨 기능을 하는지 보기 좋았다.   

과제에 대한 피드백을 받고 잘 하고있는지, 부족한부분, 수정하면 좋은부분을 알게되어 좋았습니다.  
튜터님 감사합니다.  


<br><br><br><br><br><br>
- - - 

[C#] TEXT GAME

<br>