public class GitHubRepo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stars { get; set; }
    public string Language { get; set; }
    public string Url { get; set; }
    public DateTime LastUpdated { get; set; }

    public override string ToString() =>
        $"\n📦 {Name}\n   ⭐ {Stars} stars | 💻 {Language}\n   {Description}\n   🔗 {Url}\n   🕒 Last updated: {LastUpdated:yyyy-MM-dd}";
}
