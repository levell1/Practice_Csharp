using week4;

namespace week4
{
    internal class Program
    {
        // 아이템을 사용할 수 있는 인터페이스
        public interface IUsable
        {
            void Use();
        }

        // 아이템 클래스
        public class Item : IUsable
        {
            public string Name { get; set; }

            public void Use()
            {
                Console.WriteLine("아이템 {0}을 사용했습니다.", Name);
            }
        }

        // 플레이어 클래스
        public class Player
        {
            public void UseItem(IUsable item)
            {
                item.Use();
            }
        }
        // 월 열거형
        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        // 처리하는 함수
        static void ProcessMonth(int month)
        {
            if (month >= (int)Month.January && month <= (int)Month.December)
            {
                Month selectedMonth = (Month)month;
                Console.WriteLine("선택한 월은 {0}입니다.", selectedMonth);
                // 월에 따른 처리 로직 추가
            }
            else
            {
                Console.WriteLine("올바른 월을 입력해주세요.");
            }
        }

        delegate void MyDelegate(string message);

        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message);
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message);
        }
        // 게임 실행
        static void Main()
        {
            Player player = new Player();
            Item item = new Item { Name = "Health Potion" };
            player.UseItem(item);

            int userInput = 7; // 사용자 입력 예시
            ProcessMonth(userInput);

            // 델리게이트 인스턴스 생성 및 메서드 등록
            MyDelegate myDelegate = Method1;
            myDelegate += Method2;

            // 델리게이트 호출
            myDelegate("Hello!");

            Console.ReadKey();

        }
    }
}