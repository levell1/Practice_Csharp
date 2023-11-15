using System;
using Week5_SimpleRpg.Character;
using Week5_SimpleRpg.Item;

namespace Week5_SimpleRpg
{
    internal class Program
    {
        /*1. 
        
        
        
   
    - **`Stage`**라는 클래스를 만들어 주세요. 이 클래스는 플레이어와 몬스터, 그리고 보상 아이템들을 멤버 변수로 가지며,
        **`Start`**라는 메서드를 통해 스테이지를 시작하게 됩니다.
        - 스테이지가 시작되면, 플레이어와 몬스터가 교대로 턴을 진행합니다.
        - 플레이어나 몬스터 중 하나가 죽으면 스테이지가 종료되고, 그 결과를 출력해줍니다.
        - 스테이지가 끝날 때, 플레이어가 살아있다면 보상 아이템 중 하나를 선택하여 사용할 수 있습니다.
3. 추가적인 요구사항:
    - 모든 코드는 C# 언어로 작성해주세요.
    - 코드에는 적절한 주석을 달아주세요.
    - 각 스테이지가 시작할 때 플레이어와 몬스터의 상태를 출력해주세요.
    - 각 턴이 진행될 때 천천히 보여지도록 **`Thread.Sleep`**을 사용하여 1초의 대기시간을 추가해주세요.*/

        enum SelectAction
        {
            DoAttack =1,
            UseHealPotion,  
            UseStrengthPotion = 3 
        }

        class Stage {

            public void Start(Warrior warrior, Monster monster, List<IItem> item) {
                Console.WriteLine($"{warrior.Name}가 {monster.Name}과 마주쳤습니다. 전투를 준비해 주세요.(1.공격하기, 2.체력포션, 3.힘영약");

                
            }

            public void select() {

                int action = int.Parse(Console.ReadLine());
                SelectAction Doaction = (SelectAction)action;  // 정수를 열거형으로 변환
                switch (Doaction)
                {

                }

            }
        }

        static void Main(string[] args)
        {
            Stage stage1 = new Stage();
            Stage stage2 = new Stage();
            Warrior player = new Warrior("워리어");

            Monster monster = new Monster();
            Goblin goblin = new Goblin("작은 고블린");
            Dragon dragon = new Dragon("드래곤");

            HealthPotion healthPotion = new HealthPotion();
            StrengthPotion strengthPotion = new StrengthPotion();

            List<IItem> reward = new List<IItem> { healthPotion, strengthPotion };



            Console.WriteLine("기본적인 턴 기반 RPG 게임입니다.");
            Console.ReadLine();

            stage1.Start(player,goblin,reward);

        }

    }
}