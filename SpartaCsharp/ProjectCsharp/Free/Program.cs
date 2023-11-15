using System;

namespace TextGame
{


    // 게임 캐릭터 생성 및 상태 변경 감지

    class Program
    {
        static void Main()
        {
            // Nullable 형식 변수 선언
            int? nullableInt = null;
            double? nullableDouble = 3.14;
            bool? nullableBool = true;

            // 값 할당 및 접근
            nullableInt = 10;
            int intValue = nullableInt.Value;

            // null 값 검사
            if (nullableDouble.HasValue)
            {
                Console.WriteLine("nullableDouble 값: " + nullableDouble.Value);
            }
            else
            {
                Console.WriteLine("nullableDouble은 null입니다.");
            }

            // null 병합 연산자 사용
            // nullableInt ?? 0과 같이 사용되며, nullableInt가 null이면 0을 반환합니다.
            int nonNullableInt = nullableInt ?? 0;
            Console.WriteLine("nonNullableInt 값: " + nonNullableInt);
            Console.WriteLine(intValue);
        }
    }
}
