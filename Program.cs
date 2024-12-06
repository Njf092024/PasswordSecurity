namespace PasswordSecurity;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();

        HashingExample hashingExample = new HashingExample();

        Console.WriteLine("Enter your username");
        string? mockUser = Console.ReadLine();

        Console.WriteLine("Enter your password");
        string? mockPassword = Console.ReadLine();
        Console.Clear();


        string hashed = hashingExample.ComputeSHA256Hash(mockPassword ?? string.Empty);

        users.Add(new User { Username = mockUser, HashedPassword = hashed });

        SaveToJSON(users, "user.json");

        Console.WriteLine($"Hello {mockUser}. Your password is: {hashed}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        
    }

    static void SaveToJSON(List<User> users, string filePath)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true});
        File.WriteAllText(filePath, json);
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

    public class User
    {
        public string? Username { get; set; }
        public string? HashedPassword { get; set; }
    }

