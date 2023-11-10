// See https://aka.ms/new-console-template for more information

//연습문제
//1-1,2
int level   = 50;         //레벨
int count   = 7;          //갯수

float percentage    = 70.0f;   //확률
float speed         = 2.1f;    //속도

string nickname     = "Post";      //별명
string description  = "설명글";    //설명


//1-3 숫자를 숫자로
int iTen = 10;
float fTen; // iTen 을 저장해보세요

fTen = (float)iTen;
fTen = iTen;

float fFive = 5.5f;
int iFive; // fFive 을 저장해보세요

iFive = (int)fFive;

//1-4   숫자를 문자로
int n = 10;
float f = 0.5f;

string strN = n.ToString();
string strF = f.ToString();

//1-5 문자를 숫자로
string strTen = "10";
string strSix = "6.2";

int Ten = Convert.ToInt32(strTen);
float Six = float.Parse(strSix);
int.TryParse(strTen, out Ten);


