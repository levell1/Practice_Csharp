// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
Console.WriteLine("이제부터 C# 을 이용한 프로그래밍을 시작합니다.");
Console.WriteLine("무사히 마치고 이후 게임개발까지 즐겁게 보냈으면 합니다.");

Console.WriteLine(" 따움표' 백슬래시\\ 사용");
Console.WriteLine(" 큰따움표 \" 사용 ");

Console.WriteLine("1+5(문자)");
Console.WriteLine(1 + 5);
Console.WriteLine(10 - 4);
Console.WriteLine(5 * 5);


int i = 11;
do
{
    // 원래는 11이 10보다 크기 때문에 싱행되면 안됩니다.
    // 하지만 do while 에서는 무조건 한번은 실행됩니다.
    // 11을 한번 출력하고 종료됩니다.
    Console.WriteLine(i);
    i++;
}
while (i <= 10);


int hp = 3;

Attack();    // 데미지 : 1    현재체력 : 2
Attack();    // 데미지 : 1    현재체력 : 1
Attack();    // 데미지 : 1    현재체력 : 0
Attack();    // Console X

void Attack()
{
    if (hp < 1)
    {
        return;
    }
    --hp;
    Console.WriteLine("데미지 : 1    현재체력 : " + hp);
}



int testNum = Attack1();
// string testString = Attack();

int Attack1()
{
    Console.WriteLine("return 확인");
    return 100;
}

Console.WriteLine(testNum);

// testString();   //string 타입이 아니라서 오류

hp = 10;
void Attack3(int damage)
{
    hp -= damage;
    if (hp < 1)
    {
        //사망코드
        return;
    }

    Console.WriteLine("데미지 : " + damage + "    현재체력 : " + hp);
}

Attack3(3);
Attack3(6);
Attack3(4); // hp 1이하


void DisplayMyInfo(int level, string name, string job)
{
    Console.WriteLine("레벨 : " + level + "이름 : " + name + "직업 : " + job);
}
DisplayMyInfo(1, "kim", "pro");


Character myCharacter = new Character();
myCharacter.userName = "chad";
myCharacter.job = "전사";
myCharacter.level = 20;

myCharacter.IntroduceCharacter();


class Character
{
    public string userName;
    public string job;
    public int level;

    public void IntroduceCharacter()
    {
        Console.WriteLine("레벨 : " + level + "  이름 : " + userName + "  직업 : " + job);
    }
}