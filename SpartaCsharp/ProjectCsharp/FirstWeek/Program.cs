namespace FirstWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UserInfo();
            //Calculator();
            //Temperature();
            Bmi();
            void UserInfo() // 1. 입력받기
            {
                Console.Write("이름: ");
                string name = Console.ReadLine();

                Console.Write("나이: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine($"이름 :\t {name}\n나이 :\t {age}");
            }

            void Calculator() // 2. 사칙연산 계산기
            {
                Console.Write("두 수를 입력해주세요(\" \") : ");
                string nums = Console.ReadLine();
                string[] num = nums.Split(' ');
                int num1 = int.Parse(num[0]);
                int num2 = int.Parse(num[1]);

                Console.WriteLine($"덧셈(+)\t\t{num1} + {num2} = {num1 + num2}");
                Console.WriteLine($"뺄셈(-)\t\t{num1} - {num2} = {num1 - num2}");
                Console.WriteLine($"곱셈(x)\t\t{num1} * {num2} = {num1 * num2}");
                Console.WriteLine($"나눗셈(/)\t{num1} / {num2} = 몫{num1 / num2} 나머지{num1 % num2}");
            }

            void Temperature() // 3. 온도 변환기
            {
                Console.Write("섭씨온도(°C) 를 입력해 주세요 : ");
                float Celsius = float.Parse(Console.ReadLine());
                float Fahrenheit = (Celsius * 9 / 5) + 32;

                Console.WriteLine($"섭씨온도 : {Celsius}°C\n화씨온도 : {Fahrenheit}°F");
            }

            void Bmi() // 4. BMI
            {
                Console.Write("몸무게(Kg) 를 입력해 주세요 : ");
                float kg= float.Parse(Console.ReadLine());

                Console.Write("키(Cm) 를 입력해 주세요 : ");
                float cm = float.Parse(Console.ReadLine());

                float bmi= kg/((cm/100) * (cm/100));
                Console.WriteLine("BMI : {0:N2}",bmi);
            }
        }

    }
}