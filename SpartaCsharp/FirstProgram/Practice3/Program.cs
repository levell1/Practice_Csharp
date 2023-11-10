// See https://aka.ms/new-console-template for more information

// 연습문제 3
using System.Diagnostics;
{/*
    // 연습문제 3
    // 1. 입력받은 데이터가 숫자인지 문자열인지 판단
    // 2. 입력받은 데이터가 숫자인지 문자열인지 불리언인지 판단
    // 3. 입력받은 데이터가 숫자라면 100 보다 큰지 작은지 알려주는 프로그램 만들기
    // 4. 입력받은 데이터가 숫자라면 짝수인지 홀수인지 알려주는 프로그램 만들기

    string input = Console.ReadLine(); // 데이터를 입력하고 Enter 를 누르면 다음으로 넘어갑니다.
                                       //  Console.WriteLine("입력받은 데이터는 " + input + " 입니다.");
    int num;
    bool isInt = int.TryParse(input, out num);

    bool b;
    bool isbool = bool.TryParse(input, out b);

    if (isInt)
    {
        if (num >= 100) //100 이상 이하 확인
        {
            Console.WriteLine(num + "은 100보다 같거나 큰수입니다.");
        }
        else
        {
            Console.WriteLine(num + "은 100보다 작은수입니다.");
        }

        if (num % 2 == 1) //짝수 홀수 확인
        {
            Console.WriteLine(num + "는 홀수 입니다.");
        }
        else
        {
            Console.WriteLine(num + "는 짝수 입니다.");
        }
    }
    else if (isbool)
    {
        Console.WriteLine("불리언 입니다.");
    }
    else
    {
        Console.WriteLine("문자열입니다.");
    }
    */
}

// 연습문제 4
{/*
    // 연습문제 4
    // 1. 숫자를 두번 입력받아서 두번 다 숫자인지 확인
    // 2. 숫자를 두번 입력받아서 두번 다 숫자인지 하나만 숫자인지 확인
    // 3. 숫자를 두번 입력받아서 두 수를 비교
    Console.WriteLine("첫번째 수를 입력해 주세요.");
    string input = Console.ReadLine();
    Console.WriteLine("두번째 수를 입력해 주세요.");
    string input1 = Console.ReadLine();

    int num;
    bool isInt = int.TryParse(input, out num);
    int num1;
    bool isInt1 = int.TryParse(input1, out num1);

    if (isInt && isInt1)
    {
        Console.WriteLine("두 데이터는 모두 숫자입니다.");
        if (num == num1)
        {
            Console.WriteLine(num +" 와 "+ num1 + " 는 같은 수 입니다.");
        }
        else if (num > num1)
        {
            Console.WriteLine(num + " 은 " + num1 + " 보다 큰 수 입니다.");
        }
        else if (num < num1)
        {
            Console.WriteLine(num + " 은 " + num1 + " 보다 작은 수 입니다.");
        }
    }
    else if (isInt || isInt1)
    {
        Console.WriteLine("하나만 숫자입니다.");
    }
    else
    {
        Console.WriteLine("모두 숫자가 아닙니다.");
    }
    */
}

// 연습문제 5
{
    // 1. 퀴즈를 내서 정답을 맞추는 프로그램 작성
    // 2. 주어진 보기를 선택하면 해당하는 선택지에 맞는 메시지 출력
    Console.WriteLine("Q. 대한민국의 수도는 어디인가요?");
    Console.WriteLine("1.인천 2.평창 3.서울 4.부산");
    string input = Console.ReadLine();
    int num;
    bool isInt = int.TryParse(input, out num);

    if (isInt)
    {
        switch (num)
        {
            case 1:
                Console.WriteLine("오답입니다.");
                break;
            case 2:
                Console.WriteLine("오답입니다.");
                break;
            case 3:
                Console.WriteLine("정답입니다.");
                break;
            case 4:
                Console.WriteLine("오답입니다.");
                break;

            default:
                Console.WriteLine("1~4 의 숫자를 입력해주세요.");
                break;
        }
        if (num>=1 && num <=4)
        {
            if (num == 3)
            {
                Console.WriteLine("정답입니다.");
            }
            else
            {
                Console.WriteLine("오답입니다.");
            }
        }
        else
        {
            Console.WriteLine("1~4 의 숫자를 입력해주세요.");
        }
    }
    else
    {
        Console.WriteLine("숫자가 아닙니다.");
    }
}
