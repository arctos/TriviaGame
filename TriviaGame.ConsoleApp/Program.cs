using System;
using System.Threading.Tasks;

namespace TriviaGame.ConsoleApp
{
    class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Welcome to The Trivia Game");
            Console.WriteLine("");
            Console.WriteLine("Press <enter> to begin...");
            Console.WriteLine("");
            Console.ReadLine();

            var exit = "";
            
            do
            {
                var question = await ApiClient.GetQuestionAsync();

                // Ask question
                Console.WriteLine($"Category: {question.Category}");
                Console.WriteLine($"Difficulty: {question.Difficulty}");
                Console.WriteLine("And the question is...");
                Console.WriteLine("");
                Console.WriteLine(question.Text);
                Console.WriteLine("");

                int maxGuesses = 3;
                int guesses = 0;

                do
                {
                    // Get answer
                    Console.WriteLine("Your answer?");
                    Console.WriteLine("");
                    var answer = Console.ReadLine();
                    Console.WriteLine("");
                    guesses++;

                    // Check answer
                   if (answer == question.CorrectAnswer)
                    {
                        Console.WriteLine("Congratulations! You win!");
                        break;
                    }
                    else
                    {
                        int remainingGuesses = maxGuesses - guesses;
                        Console.WriteLine("Oh, I'm sorry... that's incorrect. You have " + remainingGuesses + " guesses remaining." );
                        if (remainingGuesses == 0)
                        {
                            Console.WriteLine(" The answer we were looking for was: ");
                            Console.WriteLine(question.CorrectAnswer);
                        }
                    }
                } while (guesses < maxGuesses);

                Console.WriteLine("");

                // Play again?
                Console.WriteLine("Thanks for playing The Trivia Game!");
                Console.WriteLine("Play again? (y/N)");
                exit = Console.ReadLine();
            }
            while (exit == "y" || exit == "Y");
        }
    }
}
