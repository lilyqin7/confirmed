# GitHub Repo Finder

A two-part application that fetches a GitHub user's top repositories and displays them in a React UI.

## What I Built

- **Part A:** A C#/.NET console app that accepts a GitHub username, fetches their public repositories via the GitHub API, and outputs the top 5 by star count to the console and a `repos.json` file.
- **Part B:** A React (Vite) interface that reads `repos.json` and displays the repositories in a clean UI with search and sort functionality.

## How to Run

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
