using ConsoleTables;
using System;
using System.Security.Claims;
using System.Xml.Linq;
using static TextGame.Program;

namespace TextGame
{
    internal class Program
    {

        // 인터페이스 1
        public class NegativeNumberException : Exception
        {
            public NegativeNumberException(string message) : base(message)
            {
            }
        }



// 게임 실행
static void Main()
        {
            try
            {
                int number = -10;
                if (number < 0)
                {
                    throw new NegativeNumberException("음수는 처리할 수 없습니다.");
                } //throw 일부러 예외처리 던질때
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("예외가 발생했습니다: " + ex.Message);
            }
        }
    }
}
