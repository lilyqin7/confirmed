using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GitHubService
{
    private readonly HttpClient _client;

    public GitHubService()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("User-Agent", "Confirmed-GitHubApp");
    }

    public async Task<List<GitHubRepo>> GetTopReposAsync(string username)
    {
        string url = $"https://api.github.com/users/{username}/repos?per_page=100";
        HttpResponseMessage response = await _client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }
        var repos = await response.Content.ReadFromJsonAsync<List<GitHubApiRepo>>();
        return repos.OrderByDescending(r => r.StargazersCount).Take(5).Select(r => new GitHubRepo
        {
            Name = r.Name,
            Description = r.Description ?? "No descrption",
            Stars = r.StargazersCount,
            Language = r.Language ?? "Unknown",
            Url = r.HtmlUrl,
            LastUpdated = r.UpdatedAt
        })
        .ToList();
    }
}