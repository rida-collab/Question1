using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Take student ID from user and extract last two digits
        Console.Write("Enter your student ID (e.g., BCS-039): ");
        string studentId = Console.ReadLine();
        string lastTwoDigits = new string(studentId.Where(char.IsDigit).Reverse().Take(2).Reverse().ToArray());
        lastTwoDigits = lastTwoDigits.Length == 2 ? lastTwoDigits : "00";

        // Take input values from user
        Console.Write("Enter value for x: ");
        string xValue = Console.ReadLine();
        Console.Write("Enter value for y: ");
        string yValue = Console.ReadLine();
        const string zValue = "4"; // Fixed value for z

        // Build the input string with modified variable name (y + last two digits)
        string input = $"x:{xValue}; y_{lastTwoDigits}:{yValue}; z:{zValue}; result: x * y_{lastTwoDigits} + z;";

        // Extract values from string
        int x = ExtractValue(input, "x");
        int y = ExtractValue(input, "y_" + lastTwoDigits);
        int z = ExtractValue(input, "z");

        // Perform calculation: x * y + z
        int result = x * y + z;

        // Display results in required format
        Console.WriteLine("\n--- Final Output ---");
        Console.WriteLine($"z = {z}");
        Console.WriteLine($"Result = {result}");
    }

    static int ExtractValue(string input, string variable)
    {
        string[] parts = input.Split(';');
        foreach (string part in parts)
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith(variable + ":"))
            {
                string valuePart = trimmed.Substring(variable.Length + 1).Trim();
                if (int.TryParse(valuePart, out int value))
                {
                    return value;
                }
            }
        }
        return 0; // Default if parsing fails
    }
}