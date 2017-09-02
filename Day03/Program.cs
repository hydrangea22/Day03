using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
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
            //여기는 처리
            if (key == "UpArrow")
            {
                if (map[playerY - 1, playerX] == 0)
                {
                    playerY--;
                }
            }
            else if (key == "DownArrow")
            {
                if (map[playerY + 1, playerX] == 0)
                {
                    playerY++;
                }
            }
            else if (key == "LeftArrow")
            {
                if (map[playerY, playerX - 1] == 0)
                {
                    playerX--;
                }
            }
            else if (key == "RightArrow")
            {
                if (map[playerY, playerX + 1] == 0)
                {
                    playerX++;
                }
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
                        Console.Write("P");
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
