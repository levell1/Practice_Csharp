using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PracticeClass ins = new PracticeClass();
            //ins.CreateMap();

            void _findNum()
            {
                int targetNumber = new Random().Next(1, 101); ;
                int guess = 0;
                int count = 0;

                Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");

                while (guess != targetNumber)
                {
                    Console.Write("추측한 숫자를 입력하세요: ");
                    guess = int.Parse(Console.ReadLine());
                    count++;

                    if (guess < targetNumber)
                    {
                        Console.WriteLine("좀 더 큰 숫자를 입력하세요.");
                    }
                    else if (guess > targetNumber)
                    {
                        Console.WriteLine("좀 더 작은 숫자를 입력하세요.");
                    }
                    else
                    {
                        Console.WriteLine("축하합니다! 숫자를 맞추셨습니다.");
                        Console.WriteLine("시도한 횟수: " + count);
                    }
                }
            }
            //_findNum();


        }
    }

/// <summary>
/// 클래스 연습
/// </summary>
    public class PracticeClass
    {
        /// <summary>
        /// 2차원 배열 5x5로 만든 맵
        /// </summary>
        public void CreateMap()
        {
            int[,] map = new int[5, 5]
    {
                 { 1, 1, 1, 1, 1 },
                 { 1, 0, 0, 0, 1 },
                 { 1, 0, 1, 0, 1 },
                 { 1, 0, 0, 0, 1 },
                 { 1, 1, 1, 1, 1 }
    };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (map[i, j] == 1)
                    {
                        Console.Write("■ ");
                    }
                    else
                    {
                        Console.Write("□ ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void PracticeList()
        {
            List<int> list = new List<int>();
            Console.WriteLine(list.Capacity);
            list.AddRange(new int[4] { 1, 2, 3, 4 });
            Console.WriteLine(list.Capacity);
            list.Add(1);
            Console.WriteLine(list.Capacity);
            list.Add(1); list.Add(1); list.Add(1); list.Add(1);
            Console.WriteLine(list.Capacity);
        }

        void _useDictionary()
        {
            Dictionary<string, int> scores = new Dictionary<string, int>(); // 빈 딕셔너리 생성
            scores.Add("Alice", 100); // 딕셔너리에 데이터 추가
            scores.Add("Bob", 80);
            scores.Add("Charlie", 90);
            scores.Remove("Bob"); // 딕셔너리에서 데이터 삭제

            foreach (KeyValuePair<string, int> pair in scores) // 딕셔너리 데이터 출력
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        void _practiceLoop()
        {
            Console.WriteLine("게임을 시작합니다.");
            Console.WriteLine("1: 전사 / 2: 마법사 / 3: 궁수");
            Console.Write("직업을 선택하세요: ");
            string job = Console.ReadLine();

            switch (job)
            {
                case "1":
                    Console.WriteLine("전사를 선택하셨습니다.");
                    break;
                case "2":
                    Console.WriteLine("마법사를 선택하셨습니다.");
                    break;
                case "3":
                    Console.WriteLine("궁수를 선택하셨습니다.");
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    break;
            }

            Console.WriteLine("게임을 종료합니다.");

            string[] inventory = { "검", "방패", "활", "화살", "물약" };
            foreach (string item in inventory)
            {
                Console.WriteLine(item);
            }
        }

        void _week1() // 입출력
        {
            Console.WriteLine("Name\tAge");
            Console.WriteLine("Kero\t30");
            Console.WriteLine("Young\t25");
            // 출력결과
            // Name    Age
            // Kero    30
            // Young   25

            Console.WriteLine("We learn \"C# Programming\"");
            // 출력결과
            // The book is called "C# Programming"

            Console.WriteLine("He said, \'Hello\' to me.");
            // 출력결과
            // He said, 'Hello' to me.

            Console.WriteLine("C:\\MyDocuments\\Project\\");
            // 출력결과
            // C:\MyDocuments\Project\

            Console.Write("Enter two numbers: ");
            string input = Console.ReadLine();    // "10 20"과 같은 문자열을 입력받음

            string[] numbers = input.Split(' ');  // 문자열을 공백으로 구분하여 배열로 만듦
            int num1 = int.Parse(numbers[0]);     // 첫 번째 값을 정수로 변환하여 저장
            int num2 = int.Parse(numbers[1]);     // 두 번째 값을 정수로 변환하여 저장

            int sum = num1 + num2;                // 두 수를 더하여 결과를 계산

            Console.WriteLine("The sum of {0} and {1} is {2}.", num1, num2, sum);

            //검색
            string str = "Hello, World!";
            int index = str.IndexOf("World");
            Console.WriteLine(index);

            //대체
            string str0 = "Hello, World!";
            string newStr = str0.Replace("World", "Universe");

            //변환
            string str11 = "123";
            int num11 = int.Parse(str);

            int num12 = 123;
            string str12 = num12.ToString();

            //비교
            string str1 = "Apple";
            string str2 = "Banana";
            int compare = string.Compare(str1, str2);

            //문자열 포멧팅
            string name = "John";
            int age = 30;
            string message = string.Format("My name is {0} and I'm {1} years old.", name, age);

            string name1 = "John";
            int age1 = 30;
            string message1 = $"My name is {name} and I'm {age} years old.";
        }

        void _checkLise() {
            List<int> list = new List<int>();
            Console.WriteLine("Capacity : " + list.Capacity);
            list.AddRange(new int[4] { 1, 2, 3, 4 });
            Console.WriteLine("Capacity : " + list.Capacity);
            list.Add(1);
            Console.WriteLine("Capacity : " + list.Capacity);
            list.Add(1); list.Add(1); list.Add(1); list.Add(1);
            Console.WriteLine("Capacity : " + list.Capacity);
            Console.WriteLine("Count : " + list.Count);
        }
    }
}



