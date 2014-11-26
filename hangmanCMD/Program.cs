using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hangmanCMD
{
    class Program
    {
        static string tempWord = "guru"; //default word for demonstration


        static string word;
        static char[] show;

        static char input;
        const int livesMax = 5;
        static int lives = livesMax;
        static int left;

        static char[] entered;
        static bool running;

        static void Main(string[] args)
        {
            initialize(tempWord);
            controlLoop();
        }

        static void controlLoop()
        {
            running = true;
            while (running)
            {
                output();
                string _input;
                _input = Console.ReadLine();
                if (_input.Length == 1)
                {
                    input = _input[0];
                    processInput();
                }
                else
                {
                    Console.WriteLine("Only one letter please.");
                }
            }
        }

        static void processInput()
        {
            if (entered.Contains(input))
            {
                Console.WriteLine("You have already entered that letter.\n");
                return;
            }
            else
            {
                int i = 0;
                while(entered[i] != ' ')
                {
                    i++;
                }
                entered[i] = input;
            }
            if (substituteLetter(input))
            {
                if (left == 0)
                {
                    win();
                }
            }
            else
            {
                lives--;
                if (lives == 0)
                {
                    loose();
                }
            }

        }

        static void output()
        {
            Console.WriteLine("Word: " + new string(show));
            Console.WriteLine("Attempts left: " + lives);
            Console.Write("Letters entered: ");
            for (int i = 0; i < 26; i++)
            {
                if (entered[i] != ' ')
                {
                    Console.Write(entered[i] + ", ");
                }
            }
            Console.Write("\n\n");
        }

        static bool substituteLetter(char l)
        {
            bool found = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == l)
                {
                    show[i] = l;
                    left--;
                    found = true;
                }
            }
            return found;
        }

        static void initialize(string newWord)
        {
            entered = new char[26];
            lives = livesMax;
            word = newWord;
            show = new char[word.Length];
            for (int i = 0; i < show.Length; i++)
            {
                show[i] = '*';
            }
            for (int i = 0; i < 26; i++)
            {
                entered[i] = ' ';
            }
            left = word.Length;
        }

        static void win()
        {
            Console.Out.WriteLine("Congrats!!");
            running = continueQuerry();
        }

        static void loose()
        {
            Console.Out.WriteLine("You lost, play again?");
            running = continueQuerry();

        }

        static bool continueQuerry()
        {
            Console.WriteLine("Continue playing?(1/0)");
            int cont = Console.Read();
            if (cont == '1')
            {
                initialize(tempWord);
                return true;
            }
            else if (cont == '0')
            {
                return false;
            }
            else
            {
                return continueQuerry();
            }
        }
    }
}
