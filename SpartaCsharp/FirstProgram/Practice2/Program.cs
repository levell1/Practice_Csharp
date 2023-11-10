// See https://aka.ms/new-console-template for more information

// 1. 숫자의 사칙연산
int ten = 10;

int result = ten + 7;           // 7 더하기
int result1 = ten - 3;          // 3 빼기
int result2 = ten * 2;          // 2 곱하기
float result3 = ten * 1.5f;     // 1.5 곱하기
float result4 = ten / 3;        // 3 으로 나누기
float result5 = ten % 4;        // 4 로 나눴을때 나머지

Console.WriteLine(result);
Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);
Console.WriteLine(result4);
Console.WriteLine(result5);

// 2. 문자의 계산
string name = "김종욱"; 
int year = 2023;

string introduce = "안녕하세요. 제 이름은 "+ name +" 입니다"; // 안녕하세요. 제 이름은 "chad" 입니다.
string thisYear = "올해는 " + year +"년 입니다."; // 올해는 '2023년' 입니다.

Console.WriteLine(introduce);
Console.WriteLine(thisYear);

// 3. 논리 연산
ten = 10;

bool result_1 = ten == 10;    // ten 이 10 이랑 같다
bool result_2 = ten != 11;    // ten 이 11 이랑 같지 않다
bool result_3 = ten <  20;    // ten 이 20 보다 작다
bool result_4 = ten >   5;    // ten 이 5 보다 크다

Console.WriteLine(result_1);
Console.WriteLine(result_2);
Console.WriteLine(result_3);
Console.WriteLine(result_4);


