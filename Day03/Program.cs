using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static bool isRunning = true;
        static int monsterX = 1;
        static int monsterY = 1;

        static void Main(string[] args)
        {
            int[,] map =
            {
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            }; // 10 x 10 Array

            int playerX = 1;
            int playerY = 1;

            Random gRandom = new Random();
            int goalX = gRandom.Next(1, 9);
            int goalY = gRandom.Next(1, 9);
            map[goalY, goalX] = 2;

            // 적 시작 위치 설정
            monsterX = gRandom.Next(1, 9);
            monsterY = gRandom.Next(1, 9);


            while (isRunning)
            {
                string key = Input();
                Process(key, ref playerX, ref playerY, map);
                Clear();
                //Console.Write(key.ToString());
                Render(map, playerX, playerY);
            }
        }

        static string Input()
        {
            ConsoleKeyInfo info = Console.ReadKey();

            return info.Key.ToString();
        }

        static int Process(string key, ref int playerX, ref int playerY, int[,] map)
        {
            //여기는 주인공 이동 처리
            if (key == "UpArrow")
            {
                if (map[playerY - 1, playerX] != 1)
                {
                    playerY--;
                }
            }
            else if (key == "DownArrow")
            {
                if (map[playerY + 1, playerX] != 1)
                {
                    playerY++;
                }
            }
            else if (key == "LeftArrow")
            {
                if (map[playerY, playerX - 1] != 1)
                {
                    playerX--;
                }
            }
            else if (key == "RightArrow")
            {
                if (map[playerY, playerX + 1] != 1)
                {
                    playerX++;
                }
            }

            // 적 움직임 처리
            Random mRandom = new Random();
            int direction = mRandom.Next(1, 5);


            switch(direction)
            {
                case 1: // Up
                    if (map[monsterY+1, monsterX] != 1)
                    {
                        monsterY++;
                    }
                    break;
                case 2: // Down
                    if (map[monsterY-1, monsterX] != 1)
                    {
                        monsterY--;
                    }
                    break;
                case 3: // Left
                    if (map[monsterY, monsterX-1] != 1)
                    {
                        monsterX--;
                    }
                    break;
                case 4: // Right
                    if (map[monsterY, monsterX+1] != 1)
                    {
                        monsterX++;
                    }
                    break;
            }


            // 게임 로직 처리
            if (map[playerY, playerX] == 2)
            {
                isRunning = false;
            }

            // 적과 마주치면 죽는다
            if (playerX == monsterX && playerY == monsterY)
            {
                isRunning = false;
            }

            return 0;
        }

        static void Clear()
        {
            Console.Clear();
        }

        static void Render(int[,] _map, int playerX, int playerY)
        {
            for (int y = 0; y < 10; ++y)
            {
                for (int x = 0; x < 10; ++x)
                {
                    if (_map[y,x] == 1)
                    {   // 맵 데이터에 1이면 출력
                        Console.Write(_map[y, x]);
                    }
                    else if (playerX == x && playerY == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("P");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (_map[y, x] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("G");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (monsterX == x && monsterY == y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("M");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {   // 맵 데이터에 0이면 공백 출력
                        Console.Write(" ");
                    }



                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}