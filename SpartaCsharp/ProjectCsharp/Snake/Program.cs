using System;
using System.Drawing;

namespace Snake
{
    class Snack
    {
        const int map_X = 30;
        const int map_Y = 20;

        char bodyS = '+';
        char foodS = '=';

        Random rand = new Random();
        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            int score = 0;
            _drawMap();

            // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
            Point p = new Point(7, 7, '+');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // 음식의 위치를 무작위로 생성하고, 그립니다.
            FoodCreator foodCreator = new FoodCreator(map_X, map_Y, '=');
            Point food = foodCreator.CreateFood(map_X, map_Y);
            food.Draw();

            // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
            while (true)
            {
                // 키 입력이 있는 경우에만 방향을 변경합니다.
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo;
                    keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.UP;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.DOWN;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.RIGHT;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.LEFT;
                            break;
                    }
                    food.Draw();
                }
                // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
                if (snake.Eat(food))
                {
                    score++;
                    food.Draw();
                    food = foodCreator.CreateFood(map_X, map_Y);

                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.

                if (snake.IsHitTail() || snake.IsHitWall())
                {
                    break;
                }

                Thread.Sleep(100); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)

                Console.SetCursorPosition(0, 23);
                Console.WriteLine($"먹이 : {score}");
                Console.WriteLine($"길이 : {score+4}");
            }
            Console.Clear();

            Console.SetCursorPosition(27, 4);
            Console.WriteLine($"게임오버");
            Console.SetCursorPosition(26, 5);
            Console.WriteLine($"점수 : {score}점 ");
            Console.ReadLine();


            void _drawMap()
            {
                for (int i = 1; i < (map_X + 2); i++)
                {
                    Console.SetCursorPosition(i, 1);
                    Console.Write("*");
                }
                for (int i = 1; i < (map_X + 2); i++)
                {
                    Console.SetCursorPosition(i, map_Y + 2);
                    Console.Write("*");
                }
                for (int i = 1; i < (map_Y + 2); i++)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write("*");
                }
                for (int i = 1; i < (map_Y + 2); i++)
                {
                    Console.SetCursorPosition(map_X + 2, i);
                    Console.Write("*");
                }
            }

        }

        class Snake
        {
            char bodyS = '+';
            public List<Point> Body = new List<Point>();
            public Direction Direction;
            // 뱀의 상태와 이동, 음식 먹기, 자신의 몸에 부딪혔는지 

            public Snake(Point p, int count, Direction d)
            {
                Direction = d;
                for (int i = 0; i < count; i++)
                {
                    Point point = new Point(p.x, p.y, bodyS);
                    Body.Add(point);
                    p.x += 1;
                }
            }
            public void Move()
            {
                Point tail = Body.First();
                Body.Remove(tail);
                Point head = NextMove();
                Body.Add(head);

                tail.Clear();   
                head.Draw();
            }
            public Point NextMove()
            {
                Point head = Body.Last();
                Point nextPoint = new Point (head.x, head.y,head.sym);
                switch (Direction)
                {
                    case Direction.LEFT:
                        nextPoint.x -= 1;
                        break;
                    case Direction.RIGHT:
                        nextPoint.x += 1;
                        break;
                    case Direction.UP:
                        nextPoint.y -= 1;
                        break;
                    case Direction.DOWN:
                        nextPoint.y += 1;
                        break;
                }
                return nextPoint;
            }
            public bool IsHitTail()
            {
                var head = Body.Last();
                for (int i = 0; i < Body.Count - 2; i++)
                {
                    if (head.IsHit(Body[i]))
                        return true;
                }
                return false;
            }

            public bool IsHitWall()
            {
                var head = Body.Last();
                if (head.x <= 1 || head.x >= 31 || head.y <= 1 || head.y >= 21)
                    return true;
                return false;
            }

            public void Draw()
            {
                foreach (Point p in Body)
                {
                    p.Draw();
                }
            }

            public bool Eat(Point food)
            {
                Point head = NextMove();
                if (head.IsHit(food))
                {
                    food.sym = head.sym;
                    Body.Add(food);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FoodCreator
        {
            int Max_X;
            int Max_Y;
            char foodS = '=';
            public FoodCreator(int a, int b, char c)
            {
                this.Max_X = a;
                this.Max_Y = b;
                this.foodS = c;
            }
            public Point CreateFood(int Max_X, int Max_Y)
            {
                
                Random rand = new Random();
                int x = rand.Next(2, Max_X-2);
                int y = rand.Next(2, Max_Y-2);
                Point point = new Point(x, y, foodS);

                return point;
            }

            public void Draw(Point p)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                p.Draw();
                Console.ResetColor();
            }

        }

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public char sym { get; set; }

            // Point 클래스 생성자
            public Point(int _x, int _y, char _sym)
            {
                x = _x;
                y = _y;
                sym = _sym;
            }

            // 점을 그리는 메서드
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }

            // 점을 지우는 메서드
            public void Clear()
            {
                sym = ' ';
                Draw();
            }

            // 두 점이 같은지 비교하는 메서드
            public bool IsHit(Point p)
            {
                return p.x == x && p.y == y;
            }
        }
        // 방향을 표현하는 열거형입니다.
        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }
    }
}