import { useEffect, useState } from "react";

export default function App() {
  const [repos, setRepos] = useState([]);
  const [search, setSearch] = useState("");
  const [sortBy, setSortBy] = useState("stars");

  useEffect(() => {
    fetch("/repos.json")
      .then((res) => res.json())
      .then((data) => setRepos(data));
  }, []);

  const filtered = repos
    .filter((r) =>
      r.Name.toLowerCase().includes(search.toLowerCase())
    )
    .sort((a, b) => sortBy === "stars" ? b.Stars - a.Stars : b.LastUpdated.localeCompare(a.LastUpdated));

  return (
    <div style={{ maxWidth: 800, margin: "0 auto", padding: 24 }}>
      <h1>GitHub Repositories</h1>

      {/* Interactive features */}
      <input
        placeholder="Search repos..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        style={{ marginRight: 12, padding: 8 }}
      />
      <select value={sortBy} onChange={(e) => setSortBy(e.target.value)} style={{ padding: 8 }}>
        <option value="stars">Sort by Stars</option>
        <option value="updated">Sort by Last Updated</option>
      </select>

      {/* Repo cards */}
      {filtered.map((repo) => (
        <div key={repo.Name} style={{ border: "1px solid #ddd", borderRadius: 8, padding: 16, margin: "12px 0" }}>
          <h2><a href={repo.Url} target="_blank" rel="noreferrer">{repo.Name}</a></h2>
          <p>{repo.Description}</p>
          <p>⭐ {repo.Stars} &nbsp;|&nbsp; 💻 {repo.Language} &nbsp;|&nbsp; 🕒 {new Date(repo.LastUpdated).toLocaleDateString()}</p>
        </div>
      ))}
    </div>
  );
}
