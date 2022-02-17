using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleClone
{
    class Program
    {
        static void Main(string[] args)
        {
            int remainingTries = 5;
            

            List<string> wordList = new List<string>();
            //List For all 5 letter Words -> credit https://github.com/charlesreid1/five-letter-words/blob/master/sgb-words.txt
            using (StreamReader sr = File.OpenText($"{AppDomain.CurrentDomain.BaseDirectory}\\wordDictionary.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    wordList.Add(s);
                }
            }
            
            Random rand = new Random();
            int ranPick = rand.Next(0, wordList.Count);
            string wordToGuess = wordList[ranPick];

            Console.WriteLine($"You'll guess {wordToGuess}.");
             //Capital = correct spot, correct letter, lower case is incorrect spot, correct letter. - is not found in word");

            Console.WriteLine("Welcome to C# Wordle");
            while (remainingTries > 0)
            {
                Console.WriteLine("--- Guess a word ---");
                string userInputValue = Console.ReadLine();
                if(userInputValue == wordToGuess)
                {
                    Console.WriteLine("you win.");
                    break;
                }
                if(userInputValue.Length != 5)
                {
                    Console.WriteLine("Must be 5 characters");
                    continue;
                }
                if (!wordList.Contains(userInputValue))
                {
                    Console.WriteLine("Not in WordList");
                    continue;
                }
                string outputClue = "";
                for(int i = 0; i<5; i++)
                {
                    if(wordToGuess[i] == userInputValue[i])
                    {
                        outputClue += wordToGuess[i].ToString().ToUpper();
                        continue;
                    }
                    else if(wordToGuess.ToCharArray().Contains(userInputValue[i])){
                        outputClue += userInputValue[i].ToString().ToLower();
                        continue;
                    }
                    else
                    {
                        outputClue += "-";
                        continue;
                    }
                }
                Console.WriteLine(outputClue);
                Console.WriteLine($"Clues left: {remainingTries}");
                remainingTries--;
                if (remainingTries == 0)
                {
                    Console.WriteLine("You Loose");
                }
            }
            Console.ReadLine();
        }
    }
}
