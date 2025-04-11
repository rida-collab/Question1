using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Take student ID from user and extract last two digits
        Console.Write("Enter your student ID (e.g., BCS-039): ");
        string studentId = Console.ReadLine();

        // Extract digits and get last two
        var digits = studentId.Where(char.IsDigit).Reverse().Take(2).Reverse().ToArray();
        string lastTwoDigits = digits.Length == 2 ? new string(digits) : "00";

        // Use first digit as x and second digit as y
        int x = digits.Length > 0 ? int.Parse(digits[0].ToString()) : 0;
        int y = digits.Length > 1 ? int.Parse(digits[1].ToString()) : 0;

        // Take input for z from user
        Console.Write("Enter value for z: ");
        int z = int.TryParse(Console.ReadLine(), out int zValue) ? zValue : 0;

        // Perform calculation: x * y + z
        int result = x * y + z;

        // Display results in required format
        Console.WriteLine("\n--- Final Output ---");
        Console.WriteLine($"x (from ID) = {x}");
        Console.WriteLine($"y (from ID) = {y}");
        Console.WriteLine($"z (user input) = {z}");
        Console.WriteLine($"Result = {result}");
    }
}