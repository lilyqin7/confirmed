using System;
using System.Net.Http;
using System.Text.Json;
using System.IO;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Enter a GitHub username: ");
        string username = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username.");
            return;
        }
    }
}