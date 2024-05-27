using System;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string? inputStr = Console.ReadLine();

            if (string.IsNullOrEmpty(inputStr) || inputStr.Length > 2)
            {
                Console.WriteLine("올바른 입력이 아님");
                continue;
            }

            char input = inputStr[0];

            //char input = (char)Console.Read();

            Console.WriteLine($"input : {input}");

            if (input >= 'A' && input <= 'Z')
                Console.WriteLine($"output : {ToLower(input)}");
            else if (input >= 'a' && input <= 'z')
                Console.WriteLine($"output : {ToUpper(input)}");
            else
                Console.WriteLine("영문자가 아님");

            Console.WriteLine();
        }
    }

    // 대 -> 소
    static char ToLower(char upperCase)
    {
        return (char)(upperCase + 32);
    }

    // 소 -> 대
    static char ToUpper(char lowerCase)
    {
        return (char)(lowerCase - 32);
    }
}