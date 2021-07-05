using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp_Game_DiceRoller_WithComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int balancePlayer = 0;
            int balanceComputer = 0;
            int raund = 0;
            int bonus = 0;
            BackgroundColor = ConsoleColor.Green;
            Clear();
            ForegroundColor = ConsoleColor.Black;
            WriteLine("Hello in Our Game, Good Luck");
            WriteLine("Please enter your Name Or \"Q\" To Quit: ");
            Write("Player name is: ");
            string player = ReadLine().ToUpper();
            if (player.ToUpper() == "Q")
                goto Finish;

            string computer = "Computer";
            WriteLine(player + " you play wiht " + computer.ToUpper());

            ForegroundColor = ConsoleColor.Red;

            WriteLine(player.CompareTo(computer) < 0 ? "\n1\t" + player +
                "\n2\t" + computer : "\n1\t" + computer + "\n2\t" + player);

            ForegroundColor = ConsoleColor.Black;

        Start: WriteLine("\nStart playing");
            WriteLine("Minimal bet is: 100, Maximal bet is 500");
            Write($"\nDo your bet {player}: ");
        NewBet: int betPlayer = int.Parse(ReadLine());
            if (betPlayer < 100 || betPlayer > 500)
            {
                WriteLine("! Minimal bet is: 100, Maximal bet is 500, Plese do correct bet!");
                betPlayer = 0;
                goto NewBet;
            }

            int betComputer = rd.Next(100, 501);
            Write($"Bet of {computer}: {betComputer}\n");
            int totalBet = betPlayer + betComputer;

            raund++;
            WriteLine($"Raund: {raund}");
            int playerZar = rd.Next(1, 7) + rd.Next(1, 7);
            WriteLine($"Sum of Dices of {player} is: {playerZar}");
            int computerZar = rd.Next(1, 7) + rd.Next(1, 7);
            WriteLine($"Sum of Dices of {computer} is: {computerZar}");
            //Thread.Sleep(1000);

            WriteLine(playerZar > computerZar ? $"\nWinner of raund {raund} is {player}"
              : (playerZar == computerZar) ? "Draw" : $"\nWinner of raund {raund} is {computer}");

            if (playerZar < computerZar)
            {
                balancePlayer = (balancePlayer - betPlayer);
                WriteLine($"Current balance of {player} is: {balancePlayer}");
                balanceComputer = (balanceComputer + totalBet);
                WriteLine($"Current balance of {computer} is: {balanceComputer}");
            }
            else if (playerZar > computerZar)
            {
                balancePlayer = (balancePlayer + totalBet);
                WriteLine($"Current balance of {player} is: {balancePlayer}");
                balanceComputer = (balanceComputer - betComputer);
                WriteLine($"Current balance of {computer} is: {balanceComputer}");
            }

            if (balancePlayer >= 3000)
            {
                while (bonus == 0)
                {
                    balancePlayer = (balancePlayer + 300);
                    WriteLine($"Congrats {player} your balance is more than 3000, and you get Bounus 300 AMD");
                    bonus++;
                }

            }

            Write("If you want to Quit game enter \"Q\" To Quit or press Enter for playing:");
            string quit = ReadLine();
            if (quit.ToUpper() == "Q")
                goto Finish;

            WriteLine(new string('-', 45));

            goto Start;

        Finish: WriteLine("\nGame Over");
            WriteLine($"Thank You {player} for Playing ");
        }
    }
}
