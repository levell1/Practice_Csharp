using ConsoleTables;
using System;
using System.Security.Claims;
using System.Xml.Linq;
using static TextGame.Program;

namespace TextGame
{
    internal class Program
    {


        enum MyEnum
        {
            Value1 = 10,
            Value2,
            Value3 = 20
        }



        // 게임 실행
        static void Main()
        {
            int intValue = (int)MyEnum.Value1;  // 열거형 값을 정수로 변환
            intValue = int.Parse(Console.ReadLine());
            MyEnum enumValue = (MyEnum)intValue;  // 정수를 열거형으로 변환
            
            switch (enumValue)
            {
                case MyEnum.Value1:
                    Console.WriteLine("10"+MyEnum.Value1);
                    break;
                case MyEnum.Value2:
                    Console.WriteLine("11"+MyEnum.Value2);
                    break;
                case MyEnum.Value3:
                    Console.WriteLine("20"+MyEnum.Value3);
                    break;
                default:
                    // 기본 처리
                    break;
            }
            Console.WriteLine(intValue);
            Console.WriteLine(enumValue);
            enumValue = MyEnum.Value2;
            Console.WriteLine(MyEnum.Value1);
            Console.WriteLine(MyEnum.Value2);
            Console.WriteLine(MyEnum.Value3);
        }
    }
}
