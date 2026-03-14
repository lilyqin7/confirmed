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
        Console.WriteLine($"Fetching repos for: {username}...");

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username.");
            return;
        }

        var service = new GitHubService();
        var repos = await service.GetTopReposAsync(username);

        if (repos == null || repos.Count == 0)
        {
            Console.WriteLine("No repositories found.");
            return;
        }

        foreach (var repo in repos)
            Console.WriteLine(repo.ToString());
        string json = JsonSerializer.Serialize(repos, new JsonSerializerOptions { WriteIndented = true });
        string outputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "github-ui", "public", "repos.json");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
        File.WriteAllText(outputPath, json);
        Console.WriteLine($"\nData written to {Path.GetFullPath(outputPath)}");

    }
}