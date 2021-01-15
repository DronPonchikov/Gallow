using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace Gallow
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vocabular = new string[9] { "physics", "code", "elephant","login", "understanding","punishment", "monster", "answer", "boob" };
            int rand = ChooseWord();
            int sizeWord = 0;
            char[] alphabet = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            SizeWord(rand, vocabular[rand], ref sizeWord);
            
            bool[] checker = new bool[26];
           
            char[] spaces = new char[sizeWord];

            FillSpaces(sizeWord, ref spaces);
            PrintSpaces(sizeWord, ref spaces);

            char[] letters = new char[sizeWord];

            fillLettersArray(sizeWord, ref letters, rand, vocabular);

            int gussedLetters = 0;
            int hearts = 9;

            do
            {
                AlphabetOperation(alphabet);
                PrintLifes(hearts);
                Comparation(letters, ref spaces, sizeWord, ref gussedLetters, ref hearts, ref alphabet);
                PrintSpaces(sizeWord, ref spaces);
            } while ((sizeWord - gussedLetters) != 0 && hearts != 0);

            if ((sizeWord - gussedLetters) == 0)
            {
                Console.WriteLine("You WON! Congrats!");
                BeepsWin();
            }
            else if (hearts == 0)
            {
                Console.WriteLine("You LOSE! Loooooser!");
                BeepsLose();
            }

            Console.ReadLine();
        }

        private static void AlphabetOperation(char [] alphabet)
        {
            Console.SetCursorPosition(0, 5);
            foreach (char a in alphabet)
            {
            Console.ForegroundColor=ConsoleColor.Red;
                Console.Write(a);
                Console.Write(" ");
                
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        private static void PrintLifes(int hearts)
        {
            for (int i = 0; i < hearts; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("<3");
                Console.Write("  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }

        private static void BeepsLose()
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }

        private static void BeepsWin()
        {
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(415, 300);
            Thread.Sleep(600);
            Console.Beep(415, 300);
            Console.Beep(330, 300);
            Console.Beep(415, 300);
            Console.Beep(330, 300);
            Console.Beep(415, 300);
            Console.Beep(440, 300);
            Console.Beep(440, 300);
            Thread.Sleep(600);
            Console.Beep(440, 300);
            Console.Beep(494, 300);
            Console.Beep(494, 100);
            Console.Beep(494, 100);
            Console.Beep(494, 300);
            Console.Beep(494, 300);
            Console.Beep(523, 300);
            Console.Beep(523, 100);
            Console.Beep(523, 100);
            Console.Beep(523, 300);
            Console.Beep(523, 300);
            Console.Beep(523, 300);
            Console.Beep(494, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(440, 800);
        }


        private static void FillSpaces(int sizeWord, ref char[] spaces)
        {
            for (int i = 0; i < sizeWord; i++)
            {
                spaces[i] = ' ';
            }
        }

        private static void Comparation(char[] letters, ref char[] spaces, int sizeWord, ref int guseedLetters, ref int hearts, ref char [] alphabet  )
        {
            char l;
            bool marker = true;
            Console.WriteLine("");
            Console.Write("Input letter:");
            do
            {
                
                 l = Char.Parse(Console.ReadLine());
                for (int z = 0; z < 26; z++)
                {
                    if (l == alphabet[z])
                    {
                        alphabet[z] = '-';
                        marker = true;
                        break;
                        
                    }
                    else if (l != alphabet[z])
                    {

                        marker = false;
                       

                    }
                    if (marker == true)
                    {
                        break;
                    }
                    else 
                        continue;
                }

            } while (marker!=true); 
            
            bool compar = false;
            for (int i = 0; i < sizeWord; i++)
            {
                if (l == letters[i]  )
                {
                    spaces[i] = letters[i];
                    guseedLetters++;
                    
                    compar = true;
                    
                    
                }
                
            }
            if (compar == false)
            {
                hearts--;
            }

        }

        private static void fillLettersArray(int sizeWord, ref char[] letters, int rand, string[] vocabular)
        {
            int i = 0;
            foreach (char a in vocabular[rand])
            {
                letters[i] = a;
                i++;
            }
        }

        private static void PrintSpaces(int sizeWord, ref char[] spaces)
        {
            Console.Clear();
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("Number of letters is {0}", sizeWord);
            Console.SetCursorPosition(10, 10);

            for (int i = 0; i < sizeWord; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(spaces[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            Console.Write("\n");
        }

        private static void SizeWord(int rand, string vocabular, ref int sizeWord)
        {
            foreach (char a in vocabular)
            {
                sizeWord++;
            }
        }

        private static int ChooseWord()
        {
            Random r = new Random();
            return r.Next(0, 8);
        }
    }
}
