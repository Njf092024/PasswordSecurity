﻿namespace PasswordSecurity;

class Program
{
    static void Main(string[] args)
    {
        HashingExample hashingExample = new HashingExample();
        Console.WriteLine("Enter your username");
        string? mockUser = Console.ReadLine();
        Console.WriteLine("Enter your password");
        string? mockPassword = Console.ReadLine();
        Console.WriteLine($"Hello {mockUser}.");
    }
}
