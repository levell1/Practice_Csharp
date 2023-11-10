using System.Collections.Generic;
using System.Numerics;

namespace SecondWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            int position;       //1~9 위치
            int user = 2;       // player 1, 2
            int player = 50;    // 50 = O , 51 = X
            bool checkPosition = true;
            bool gameend = true;

            TicTacToc tic = new TicTacToc();    // 인스턴스화 
            tic.DrawMap();                      // 맵그리기   
            
            // player1 = 50  
            // player2 = 51  

            while (gameend)
            {
                PlayGame();
                CheckWin();
            }
            
            void PlayGame()     // 게임 플레이.
            {
                if (user == 1) { user = 2; } else if (user == 2) { user = 1; }
                if (user == 1) { player = 50; } else if (user == 2) { player = 51; }
                Console.Write("자리를 정해주세요.(1 ~ 9) \nPlayer" + user + " : ");
                position = int.Parse(Console.ReadLine());
                CheckPosition(position);
                tic.DoOX(position, player);
                Console.Clear();
                tic.DrawMap();
            }

            void CheckWin() {
                int[] playercheck = { 50, 51 };
                foreach (int ox in playercheck)
                {
                    if (((tic.map[2, 2] == ox) && (tic.map[2, 6] == ox)&&(tic.map[2, 10] == ox))
                       || ((tic.map[6, 2] == ox) && (tic.map[6, 6] == ox) && (tic.map[6, 10] == ox))
                       || ((tic.map[10, 2] == ox) && (tic.map[10, 6] == ox) && (tic.map[10, 10] == ox))
                       || ((tic.map[10, 2] == ox) && (tic.map[6, 2] == ox) && (tic.map[2, 2] == ox))
                       || ((tic.map[2, 6] == ox) && (tic.map[6, 6] == ox) && (tic.map[10, 6] == ox))
                       || ((tic.map[2, 10] == ox) && (tic.map[6, 10] == ox) && (tic.map[10, 10] == ox))
                       || ((tic.map[2, 2] == ox) && (tic.map[6, 6] == ox) && (tic.map[10, 10] == ox))
                       || ((tic.map[2, 10] == ox) && (tic.map[6, 6] == ox) && (tic.map[10, 2] == ox)))
                    {
                        if (user == 1)
                        {
                            Console.WriteLine("Player 1가 승리하였습니다!");
                            gameend = false;
                        }
                        else 
                        {
                            Console.WriteLine("Player 2가 승리하였습니다!");
                            gameend = false;
                        }
                        break;
                    }
                }
            }

            void CheckPosition(int position){
                if (0 < position && position > 10)
                {
                    Console.WriteLine("\n1~9 숫자를 입력해주세요\n");
                    if (user == 1) { user = 2; } else if (user == 2) { user = 1; }
                    PlayGame();
                }
                int[] playercheck = { 50, 51 };
                foreach (int ox in playercheck)
                {
                    if ((position == 1 && tic.map[2, 2] == ox)
                        || (position == 2 && tic.map[2, 6] == ox)
                        || (position == 3 && tic.map[2, 10] == ox)
                        || (position == 4 && tic.map[6, 2] == ox)
                        || (position == 5 && tic.map[6, 6] == ox)
                        || (position == 6 && tic.map[6, 10] == ox)
                        || (position == 7 && tic.map[10, 2] == ox)
                        || (position == 8 && tic.map[10, 6] == ox)
                        || (position == 9 && tic.map[10, 10] == ox))
                    {
                        Console.WriteLine("\n잘못된 자리입니다 다시 입력해 주세요\n");
                        if (user == 1) { user = 2; } else if (user == 2) { user = 1; }
                        PlayGame();
                    }
                }
            }
            Console.WriteLine("게임이 종료되었습니다.");
        }
    }

    /// <summary>
    /// 맵에 테두리, OX표시
    /// </summary>
    public class TicTacToc 
    {
        // 배치 자리
        // map[2, 2],  map[2, 6],  map[2, 10]
        // map[6, 2],  map[6, 6],  map[6, 10]
        // map[10, 2], map[10, 6], map[10, 10]
        
        // 1~9 배치 자리
        // 21~31 맵 테두리
        // 50,51 player, com 배치위치
        public int[,] map = new int[13, 13]
            {
                    { 22, 28, 28, 28, 23, 28, 28, 28, 23, 28, 28, 28, 24 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 21, 0, 1, 0, 21, 0, 2, 0, 21, 0, 3, 0, 21 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 25, 28, 28, 28, 26, 28, 28, 28, 26, 28, 28, 28, 27 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 21, 0, 4, 0, 21, 0, 5, 0, 21, 0, 6, 0, 21 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 25, 28, 28, 28, 26, 28, 28, 28, 26, 28, 28, 28, 27 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 21, 0, 7, 0, 21, 0, 8, 0, 21, 0, 9, 0, 21 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 31, 28, 28, 28, 29, 28, 28, 28, 29, 28, 28, 28, 30 },
            };
        
        /// <summary>
        /// 맵 그리기 
        /// </summary>
        public void DrawMap()
        {
            for (int i = 0; i < 13; i++)
            {

                for (int j = 0; j < 13; j++)
                {
                    if (map[i, j] == 21)
                    {
                        Console.Write("│ ");
                    }
                    else if (map[i, j] == 22)
                    {
                        Console.Write("┌ ");
                    }
                    else if (map[i, j] == 23)
                    {
                        Console.Write("┬ ");
                    }
                    else if (map[i, j] == 24)
                    {
                        Console.Write("┐ ");
                    }
                    else if (map[i, j] == 25)
                    {
                        Console.Write("├ ");
                    }
                    else if (map[i, j] == 26)
                    {
                        Console.Write("┼ ");
                    }
                    else if (map[i, j] == 27)
                    {
                        Console.Write("┤ ");
                    }
                    else if (map[i, j] == 28)
                    {
                        Console.Write("─");
                    }
                    else if (map[i, j] == 29)
                    {
                        Console.Write("┴ ");
                    }
                    else if (map[i, j] == 30)
                    {
                        Console.Write("┘ ");
                    }
                    else if (map[i, j] == 31)
                    {
                        Console.Write("└ ");
                    }
                    else if (0 < map[i, j] && map[i, j] < 10)
                    {
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == 50)       //Player 1
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == 51)       //Player 2
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 자리에 OX 표시하기
        /// </summary>
        /// <param name="position"></param>
        /// <param name="player"></param>
        public void DoOX(int position,int player) 
        {

            // 배치 자리
            // map[2, 2],  map[2, 6],  map[2, 10]
            // map[6, 2],  map[6, 6],  map[6, 10]
            // map[10, 2], map[10, 6], map[10, 10]

            switch (position) 
            {
                case 1:
                    map[2, 2] = player;
                    break;
                case 2:
                    map[2, 6] = player;
                    break;
                case 3:
                    map[2, 10] = player;
                    break;
                case 4:
                    map[6, 2] = player;
                    break;
                case 5:
                    map[6, 6] = player;
                    break;
                case 6:
                    map[6, 10] = player;
                    break;
                case 7:
                    map[10, 2] = player;
                    break;
                case 8:
                    map[10, 6] = player;
                    break;
                case 9:
                    map[10, 10] = player;
                    break;
            }
        }
    }
}