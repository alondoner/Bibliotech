# Bibliotech

##  Description
Bibliotech is a full‑stack Library Management System built with:
1) ASP.NET Core 8 (REST API)
2) Entity Framework Core (SQLite)
3) xUnit (unit tests)
4) React + TypeScript (SPA frontend)

##  Solution Architecture

```Bash
Bibliotech/
│
├── Bibliotech.Api/               → ASP.NET Core Web API
│   ├── Controllers/
│   └── Program.cs
│
├── Bibliotech.Domain/            → Entities, Repositories, Services
│   ├── Entities/
│   ├── Repositories/
│   └── Services/
│
├── Bibliotech.Infrastructure/    → EF Core DbContext + Repository impl.
│   ├── Data/
│   └── Repositories/
│
├── Bibliotech.Tests/             → xUnit test project
│   ├── LoanServiceTests.cs
│   ├── BookServiceTests.cs
│   ├── MemberProfileTests.cs
│   ├── PenaltyTests.cs
│   └── TestHelpers/
│
└── bibliotech-spa/               → React + TypeScript SPA
    ├── src/
    │   ├── api/
    │   ├── pages/
    │   ├── components/
    │   └── App.tsx
```

##  How To Run
API
```Bash
dotnet run --project Bibliotech.Api
```

React SPA
```Bash
cd bibliotech-spa
npm start
```

