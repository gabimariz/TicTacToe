#nullable disable

namespace TicTacToe.Classes
{
    public static class Game
    {
        public static short Counter = 1;
        public static void Start()
        {
            short column, line;
            string[,] screen = {
                {" ", " ", " " },
                {" ", " ", " " },
                {" ", " ", " " }
            };

            Player.Create();
            
            while(Counter < 6)
            {
                View(screen);
                Console.WriteLine($"{Player.PlayerOne} make your move [X]: ");

                Console.Write("Column: ");
                column = short.Parse(Console.ReadLine());

                Console.Write("Line: ");
                line = short.Parse(Console.ReadLine());

                screen[column, line] = "X";

                View(screen);
                Console.WriteLine($"{Player.PlayerTwo} make your move [O]: ");

                Console.Write("Column: ");
                column = short.Parse(Console.ReadLine());

                Console.Write("Line: ");
                line = short.Parse(Console.ReadLine());

                screen[column, line] = "O";

                Counter++;
            }
        }

        public static void GameOver(string[,] gameScreen)
        {
            var gameOver = -1;

            if (Counter == 5)
            {
                GameOverColorClear();
                Console.WriteLine($"GAME OVER!!! ");
                gameOver = 0;
            }

            if ((gameScreen[0, 0] == "X" && gameScreen[0, 1] == "X" && gameScreen[0, 2] == "X") ||
                (gameScreen[1, 0] == "X" && gameScreen[1, 1] == "X" && gameScreen[1, 2] == "X") ||
                (gameScreen[2, 0] == "X" && gameScreen[2, 1] == "X" && gameScreen[2, 2] == "X") ||
                (gameScreen[0, 0] == "X" && gameScreen[1, 0] == "X" && gameScreen[2, 0] == "X") ||
                (gameScreen[0, 1] == "X" && gameScreen[1, 1] == "X" && gameScreen[2, 1] == "X") ||
                (gameScreen[0, 2] == "X" && gameScreen[1, 2] == "X" && gameScreen[2, 2] == "X") ||
                (gameScreen[0, 0] == "X" && gameScreen[1, 1] == "X" && gameScreen[2, 2] == "X") ||
                (gameScreen[0, 2] == "X" && gameScreen[1, 1] == "X" && gameScreen[2, 0] == "X"))
            {
                WinColorClear();
                Console.WriteLine($"{Player.PlayerOne} WIN!!! ");
                gameOver = 0;
            }

            if ((gameScreen[0, 0] == "O" && gameScreen[0, 1] == "O" && gameScreen[0, 2] == "O") ||
                (gameScreen[1, 0] == "O" && gameScreen[1, 1] == "O" && gameScreen[1, 2] == "O") ||
                (gameScreen[2, 0] == "O" && gameScreen[2, 1] == "O" && gameScreen[2, 2] == "O") ||
                (gameScreen[0, 0] == "O" && gameScreen[1, 0] == "O" && gameScreen[2, 0] == "O") ||
                (gameScreen[0, 1] == "O" && gameScreen[1, 1] == "O" && gameScreen[2, 1] == "O") ||
                (gameScreen[0, 2] == "O" && gameScreen[1, 2] == "O" && gameScreen[2, 2] == "O") ||
                (gameScreen[0, 0] == "O" && gameScreen[1, 1] == "O" && gameScreen[2, 2] == "O") ||
                (gameScreen[0, 2] == "O" && gameScreen[1, 1] == "O" && gameScreen[2, 0] == "O"))
            {
                WinColorClear();
                Console.WriteLine($"{Player.PlayerTwo} WIN!!! ");
                gameOver = 0;
            }

            if(gameOver == 0)
            {
                Console.Write("[ ENTER ] return to menu! ");

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.ReadKey();
                }

                Menu();
            }
        }

        public static void View(string[,] gameScreen)
        {
            GameOver(gameScreen);

            Console.Clear();

            for (int column = 0; column <= 2; column++)
            {
                Console.WriteLine();

                for(int line = 0; line <= 2; line++)
                {
                    if(gameScreen[column, line] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{gameScreen[column, line]}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{gameScreen[column, line]}");
                    }

                    for(int bar = 0; bar <= 0; bar++)
                    {
                        if(line < 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" | ");
                        }

                    }
                }

                ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Menu()
        {
            ResetColor();
            Console.Clear();
            Counter = 1;
            short option;

            Console.WriteLine("#=================#");
            Console.WriteLine("|   TIC TAC TOE   |");
            Console.WriteLine("#=================#");
            Console.WriteLine("| 1 - New Game    |");
            Console.WriteLine("! 2 - Exit        |");
            Console.WriteLine("#=================#");

            Console.WriteLine();
            Console.Write(">> ");
            option = Convert.ToInt16(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Start();
                    break;
                }
                case 2:
                {
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                }
                default: Menu(); break;
            }
        }

        public static void WinColorClear()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void GameOverColorClear()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
