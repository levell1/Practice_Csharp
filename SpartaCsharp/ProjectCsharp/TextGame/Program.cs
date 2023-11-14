using ConsoleTables;
using System;
using System.Security.Claims;
using System.Xml.Linq;
using TextGame.UsingTest;   // 폴더 using으로 사용해보기

namespace TextGame
{
    internal class Program
    {
        // 2 . 상점의 아이템 중에서 나만의 장비를 구성하는 부분이 포인트입니다.
        // 3 . 장비는 여러개의 데이터가 함께 있는 만큼 객체나 구조체를 활용하는 편이 효율적 입니다.
        // (이름, 가격, 효과, 설명 등…)
        // 4 . 관련된 여러 데이터를 다루는 부분은 배열이 도움이 됩니다.
        enum FirstView
        {
            ViewStat = 1,
            ViewInven,   // ->11 이전값의 +1
            ViewStore,
            ViewEnd = 4
        }
        static void Main(string[] args)
        {
            int firstView = (int)FirstView.ViewStat;
            FirstView enumValue = (FirstView)firstView;
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
            EquipMentA[] equipment = new EquipMentA[4];
            EquipMentA[] storeEquipment = new EquipMentA[4];
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
                
                equipment[0] = new EquipMentA("무쇠갑옷", 0, 80, 10,1000, true,true);
                equipment[1] = new EquipMentA("쇠 투구", 0, 70, 7,700, false, true);
                equipment[2] = new EquipMentA("낡은 검", 5, 0, 0,500, true, true);
                equipment[3] = new EquipMentA("쇠 검", 13, 0, 0,1500, false, true);
            }
            void _storeSet()
            {
                storeEquipment[0] = new EquipMentA("천 장갑", 0, 30, 5,1000, false, false);
                storeEquipment[1] = new EquipMentA("낡은 활", 3, 0, 0,300, false, false);
                storeEquipment[2] = new EquipMentA("낡은 신발", 0, 20, 3,400, false, false);
                storeEquipment[3] = new EquipMentA("방패", 0, 100, 0,1200, false, false);
            }

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

}

