using System;

class Program 
{

    static void Main(string[] args){
       Random random = new Random();
        int randomNumber = random.Next(1,30);
        int guessCount = 0;

        Console.WriteLine("I'm thinking of a number less than or equal to 30. Can you guess it?");

        while (true)
        {

         Console.Write("What is the lucky number? ");
        int guess = Convert.ToInt32(Console.ReadLine());
        guessCount++;

        //  Console.Write("What is your guess? ");
        // int guess = Convert.ToInt32(Console.ReadLine());
        // guessCount++;

        if (guess < randomNumber) {
            Console.WriteLine("Higher");
        } else if (guess > randomNumber) {
            Console.WriteLine("Lower");
        } else {
            Console.WriteLine("You got it!", guessCount);
            break;
        }
    }
    Console.Write("Play again? (y/n) ");
    string roundTwo = Console.ReadLine();

    // while (roundTwo.ToLower() != "y" && roundTwo.ToLower() ! = "n")
    // {
        // Console.Write("Not sure what you mean. Would you like to play again? (y/n) ");
        // roundTwo = Console.ReadLine();
    // }

    // if (roundTwo.ToLower() == "y")
    {

    }
}}


