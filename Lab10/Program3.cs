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

