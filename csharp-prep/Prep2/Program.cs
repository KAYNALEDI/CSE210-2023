using System;

class Program 
{
    static void Main(string[] args)
    {
        // Core Requirements

        Console.WriteLine("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter;

        while (grade > 100) {
            Console.WriteLine("Grade cannot exceed 100");            
            // if (grade > 100)
            
                Console.WriteLine("Enter your grade percentage: ");
                grade = int.Parse(Console.ReadLine());            
        }
            if (grade >= 90) {
            letter = "A";
        }
        else if (grade >= 80) {
            letter = "B";
        }
        else if (grade >= 70) {
            letter = "C";
        }
        else if (grade >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }
        
        

        Console.WriteLine("Your letter grade is: " + letter);

        if (grade >= 70) {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else{
            Console.WriteLine ("Better Luck next time!");
        }

        //Stretch
         string sign;

        if (letter == "A" && grade % 10 >= 7) {
            sign = "+";
        }
        else if ((letter == "B" || letter == "C" || letter == "D") && grade % 10 >= 7) {
            sign = "+";
        }
        else if (grade % 10 < 3 && letter != "F") {
            sign = "-";
        }
        else {
            sign = "";
        }

        if (letter == "A" && grade == 100) {
            letter = "A+";
        }
        else if (letter == "F" && grade % 10 == 0) {
            letter = "F";
        }
        else if (sign == "+") {
            letter += sign;
        }
        else if (sign == "-") {
            letter += sign;
        }
        Console.WriteLine("Your final grade is: " + letter);
        
    }
}

        