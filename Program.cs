namespace PasswordSecurity;

using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<user> users = new List<User>();
        
        HashingExample hashingExample = new HashingExample();

        Console.WriteLine("Enter your username");
        string? mockUser = Console.ReadLine();

        Console.WriteLine("Enter your password");
        string? mockPassword = Console.ReadLine();

        Console.WriteLine($"Hello {mockUser}.");

        string hashed = hashingExample.ComputeSHA256Hash(mockPassword ?? string.Empty);

        Console.WriteLine($"Hello {mockUser}. Your password is: {hashed}");
    }
}

public class HashingExample
{
    public string ComputeSHA256Hash(string input)
    {
        using(var sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
