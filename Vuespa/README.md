# Vue SPA Template

This template configures a simple Web API (C#) with a PostgreSQL database and Vue SPA frontend.

## Components/Tech used

- C#
- TypeScript
- .NET
- [smtp4dev](https://github.com/rnwood/smtp4dev)
- PostgreSQL
- EntityFramework
- Vue
- Vite
- [Pinia](https://pinia.vuejs.org/)
- [Vue Router](https://router.vuejs.org/)
- [Google Fonts](https://fonts.google.com/)
- [Tailwind](https://tailwindcss.com/)
- [unplugin-icons](https://github.com/unplugin/unplugin-icons)

## Getting Started

1. Open the project in VS Code
2. Open a terminal.
   1. cd to `Vuespa.Vue` and run `npm ci`.
   2. cd to the root of your project (`cd ..`) and run `docker compose up -d`. This will launch the docker containers.
   3. run `dotnet run --project Vuespa.Api`. This will launch the application and Vite.
3. To debug, hit `F5` (or `Attach to Vuespa App` in "Run and Debug") to attach to the running .NET process.

Alternatively, you can run `npm run dev` in `Vuespa.Vue` and `dotnet run` in `Vuespa.Api` directly, which makes it
a bit easier to stop and start the two components independently.

To view the exposed API in [Scalar](https://github.com/scalar/scalar), open the
[Open API Client](https://localhost:5173/scalar/v1).

## Ports

In the `Ports` panel in VS Code, you'll need the following ports forwarded:

- `4242` for VITE
- `5000` for smtp4dev
- `25432` for PostgreSQL (if you want to connect to `localhost:25432` from an SQL tool like DBeaver or DataGrip)

## Directories & Files

### Vuespa.Api

This folder contains a C# project to power the API.

This project uses `AspNetCore.Identity` APIs for managing Users.

- `Config` configuration models.
- `Services` contains the `EmailSender`

### Vuespa.Data

This folder contains a C# project to interact with the PostgreSQL database

- `Entities` contains an ApplicationUser and Role entity.
  BaseEntity.
- `Migrations` contains an initial Migration for the `ApplicationUser` entity
- `ApplicationContext` is the default database context for the application. Extends `IdentityDbContext` for
  `AspNetCore.Identity`

#### Creating a Migration

To create migrations you'll need to install `dotnet-ef`. This template includes a tool manifest that can be
restored with `dotnet tool restore` from the root directory of the project.

Then make your entity changes and run (from the root directory of your project):
`dotnet ef migrations add <migration name> --startup-project Vuespa.Api --project Vuespa.Data`

### Vuespa.Vue

- `public` for public assets.
- `src`
  - `api` simple `auth.ts` for interacting with `AspNetCore`'s Identity APIs.
  - `components` various components to simplify the forms used in the template.
  - `stores` contains a single `userStore` to provide an example of caching user information.
  - `views` all of the Views used throughout the application
