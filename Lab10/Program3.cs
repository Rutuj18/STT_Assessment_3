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

using System;
class Student {
    // Properties
    public string Name { get; set; }
    public int ID { get; set; }
    public double Marks { get; set; }

    // Constructor
    public Student(string name, int id, double marks) {
        Name = name;
        ID = id;
        Marks = marks;
    }

    // Method to determine grade
    public string GetGrade() {
        if (Marks >= 90) return "A";
        else if (Marks >= 75) return "B";
        else if (Marks >= 60) return "C";
        else if (Marks >= 50) return "D";
        else return "F";
    }

    // Method to display student details
    public void DisplayStudentDetails() {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"ID: {ID}");
        Console.WriteLine($"Marks: {Marks}");
        Console.WriteLine($"Grade: {GetGrade()}");
    }

    public static void Main() {
        // Creating a Student object
        Console.WriteLine("Enter Student Details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Marks: ");
        double marks = Convert.ToDouble(Console.ReadLine());

        Student student1 = new Student(name, id, marks);
        Console.WriteLine("\nStudent Details:");
        student1.DisplayStudentDetails();

        Console.WriteLine("\nCreating an IITGN Student...\n");

        // Creating an IITGN student
        Console.Write("Enter Hostel Name: ");
        string hostelName = Console.ReadLine();
        StudentIITGN student2 = new StudentIITGN(name, id, marks, hostelName);
        Console.WriteLine("\nIITGN Student Details:");
        student2.DisplayStudentDetails();
    }
}

// Subclass StudentIITGN
class StudentIITGN : Student {
    public string Hostel_Name_IITGN { get; set; }

    // Constructor for IITGN Student
    public StudentIITGN(string name, int id, double marks, string hostelName) 
        : base(name, id, marks) {
        Hostel_Name_IITGN = hostelName;
    }

    // Overriding display method to include hostel info
    public new void DisplayStudentDetails() {
        base.DisplayStudentDetails();
        Console.WriteLine($"Hostel: {Hostel_Name_IITGN}");
    }
}

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

