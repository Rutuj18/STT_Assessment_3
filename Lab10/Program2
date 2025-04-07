using System;
class LoopFunctions {
    // Function to calculate factorial
    static int Factorial(int n) {
        int result = 1;
        for (int i = 1; i <= n; i++) {
            result *= i;
        }
        return result;
    }

    static void Main() {
        // For loop to print numbers from 1 to 10
        Console.WriteLine("Numbers from 1 to 10:");
        for (int i = 1; i <= 10; i++) {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // While loop to continuously ask for input until "exit" is entered
        string input;
        while (true) {
            Console.Write("Enter a number to calculate factorial (or type 'exit' to stop): ");
            input = Console.ReadLine();
            
            if (input.ToLower() == "exit") {
                break;
            }
            if (int.TryParse(input, out int num) && num >= 0) {
                Console.WriteLine($"Factorial of {num} is: {Factorial(num)}");
            } else {
                Console.WriteLine("Invalid input. Please enter a non-negative integer.");
            }
        }
    }
}
