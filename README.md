# Auth ASP.NET Core MVC (MongoDB + Tailwind CSS)

A lean, server-side rendered (SSR) user authentication application built with **ASP.NET Core 10.0 MVC**, **MongoDB**, **Tailwind CSS**, and custom cookie-based session management. 

Designed without default boilerplate to demonstrate clean architecture, custom user registration workflows, and containerized deployment.

---

## Tech Stack & Architecture

* **Framework:** ASP.NET Core 10.0 MVC (Server-Side Rendered Razor Views)
* **Database:** MongoDB (via official `MongoDB.Driver`)
* **Styling:** Tailwind CSS (CDN-based direct integration)
* **Authentication:** Custom Cookie-based Authentication
* **Security:** Password hashing with `BCrypt.Net-Next`
* **Containerization:** Docker (Multi-stage build)
* **Hosting:** Render Web Service

---

## Features

* **Custom Cookie Auth:** Full sign-up, login, and logout lifecycle using ASP.NET Core claims and security cookies.
* **User Entity Schema:** Extended profile fields including `Name`, `Age`, `Email`, and hashed password data stored in MongoDB.
* **Streamlined UI:** Lightweight custom Razor views running with direct inline layouts (`Layout = null`) styled with Tailwind CSS.
* **Production Ready:** Pre-configured Dockerfile targeting .NET 10.0 preview container environments.

---

## Project Structure

```text
├── Controllers/
│   ├── LoginController.cs
│   ├── ProfileController.cs
│   └── RegisterController.cs
├── Models/
│   ├── RegisterViewModel.cs
│   └── User.cs
├── Views/
│   ├── Login/
│   │   └── Index.cshtml
│   ├── Profile/
│   │   └── Index.cshtml
│   └── Register/
│       └── Index.cshtml
├── .gitignore
├── Dockerfile
├── Program.cs
├── README.md
└── dotnet.csproj
