namespace TicTacToe.Classes
{
    public static class Player
    {
        public static string? PlayerOne;
        public static string? PlayerTwo;

        public static void Create()
        {
            Console.Clear();
            Console.Write("Player one name: ");
            PlayerOne = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Player two name: ");
            PlayerTwo = Console.ReadLine();

            Console.Clear();
        }
    }
}
