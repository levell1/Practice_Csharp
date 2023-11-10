// See https://aka.ms/new-console-template for more information


/*{
    // 연습문제 6

    // 1. 구구단 2단을 만들기
    //for문
    for (int i = 2; i < 10; i++)
    {
        Console.WriteLine("2 x " + i + " = " + 2 * i);
    }

    //while문
    int x = 2;
    while (x < 10)
    {
        Console.WriteLine("2 x " + x + " = " + 2 * x);
        x++;
    }

    // 2. 입력받은 데이터로 구구단 만들기
    Console.WriteLine("출력하고 싶은 단을 입력해주세요."); 
    string input = Console.ReadLine();
    int num;
    bool isInt = int.TryParse(input, out num);

    if (isInt)
    {
        for (int y = 2; y < 9; y++)
        {
            Console.WriteLine(num + " x " + y + " = " + num * y);
        }
    }
    else
    {
        Console.WriteLine("문자열입니다.");
    }

    // 3. 피보나치 수열 구하기 
   

    int num1 = 1;
    int num2 = 0;
    int num3 = 0;

    for (int z = 1; z <= 10; z++)
    {
        num3 = num2 + num1;
        Console.Write(num3 + " ");
        num1 = num2;
        num2 = num3;
    }

    Console.WriteLine("");


    // 4. 입력받은 수만큼 피보나치 수열 구하기 

    Console.WriteLine("몇개의 피보나치 수열을 출력하고 싶으신가요?");
    string input1 = Console.ReadLine();
    int count;
    bool isInt1 = int.TryParse(input1, out count);
    Console.Write(count + " ");

    num1 = 1;
    num2 = 0;
    num3 = 0;

    if (isInt)
    {
        if (count > 0)
        {
            if (count <= 46)
            {
                for (int re = 0; re < count; re++)
                {
                    num3 = num2 + num1;
                    Console.Write(num3 + " ");
                    num1 = num2;
                    num2 = num3;
                }
            }
            else
            {
                Console.WriteLine("숫자가 너무 큽니다.");
            }
        }
        else
        {
            Console.WriteLine("양수를 입력해주세요");
        }

    }
    else
    {
        Console.WriteLine("문자열입니다.");
    }



}
*/
{
    // 연습문제 7
    // 1. 이름 입력하기
    // 2. 조건에 맞을때 까지 이름 입력    
    // 3. 반복시 기존 내용 지우기

    bool x = true;
    while (x)
    {
        Console.WriteLine("이름을 입력해주세요. (3~10글자)");
        string name = Console.ReadLine();
        int length = name.Length;

        if (3 <= length && length <= 10)
        {
            Console.WriteLine("안녕하세요! 제 이름은 " + name + " 입니다.");
            x = false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("이름을 확인해주세요");
        }
    }
    
}