# GitHub Repo Finder

A two-part application that fetches a GitHub user's top repositories and displays them in a React UI.

## What I Built

- **Part A:** A C#/.NET console app that accepts a GitHub username, fetches their public repositories via the GitHub API, and outputs the top 5 by star count to the console and a `repos.json` file.
- **Part B:** A React (Vite) interface that reads `repos.json` and displays the repositories in a clean UI with search and sort functionality.

## How to Run

> **Important:** Run the console app (Part A) before the React app (Part B) to generate
> `repos.json`. Alternatively, rename `repos.sample.json` to `repos.json` in
> `github-ui/public/` to preview the UI without running the console app.

### Getting Started

Clone the repo:
`git clone https://github.com/YOUR_USERNAME/confirmed.git `

### Part A — Console App

1. Install [.NET SDK](https://dotnet.microsoft.com/download)
2. Navigate to the root folder: `cd confirmed`
3. Run the app: `dotnet run`
4. Enter a GitHub username when prompted. `repos.json` will be written to `github-ui/public/`.

### Part B — React UI

1. Navigate to the root folder from `confirmed`: `cd github-ui`
2. Install dependences: `npm install`
3. Run the dev server: `npm run dev`
4. Open `http://localhost:5173` in your browser

## Assumptions

- The GitHub API is accessed unauthenticated (60 req/hour limit)
- Top 5 repositories are ranked by stargazer count
- If a repo has no description or language, defaults to "No description" / "Unknown"

## Design Notes

### 1. Supporting Multiple CRM Providers

### 2. Technical Concerns for a Real Integration

-**Authentication:** Real integrations use OAuth 2.0, requiring secure token storage, refresh token handling, and scoped permissions, which are more complext than unauthenticated API calls

-**Rate limiting:** Production APIs enforce strict rate limits; I'd add retry logic with exponential backoff and respect 'Retry-After' headers

-**Data consistency:** External API schemas can change without notice, so I'd add versioning and defnsive deserialization to avoid breaking changes

-**Security:** API keys and secrets must be stored in environmental variables or a secrets manager, never hardcodced or committed to the repo

### 3. Next Steps for Production

-**Unit tests** for `GitHubService` with mocked HTTP responses

-**Dependency injection** via `IHttpClientFactory` for better testability and connection management

-**Configuration** via `appsettings.json` for base URLs, timeouts, and token management

-**Pagination** to handle users with more than 100 repositories

-**Logging** with structured logs and retry logic for failed requests

-**CI/CD pipeline** to run tets and lint on every push
