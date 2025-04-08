using System;

class Calculator {
    static void Main() {
        try {
            // Accept user input
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Perform operations
            int sum = num1 + num2;
            int difference = num1 - num2;
            int product = num1 * num2;

            double quotient;
            try {
                // Handle division by zero
                quotient = (double)num1 / num2;
            } catch (DivideByZeroException) {
                quotient = double.NaN;
            }

            // Display results
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {(double.IsNaN(quotient) ? "Undefined (division by zero)" : quotient.ToString())}");

            // Check if sum is even or odd
            Console.WriteLine(sum % 2 == 0 ? "Sum is Even" : "Sum is Odd");

        } catch (FormatException) {
            Console.WriteLine("Invalid input. Please enter numeric values.");
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        } finally {
            Console.WriteLine("Program execution completed.");
        }
    }
}

