# 🧰 Development Tools Guide

> Tools required to learn and build applications using ASP.NET Core Web API, SQL Server, and React.

---

## 🗄️ Database Tools

### 1. Microsoft SQL Server (Database Engine)

**What it is:**
- Core database system that stores and manages data

**Used for:**
- Creating databases
- Managing tables, schemas, and relationships
- Writing and executing queries
- Running stored procedures
- Handling transactions and security

**Example:**
- Stores your application data like Users, Orders, CMS Content, etc.

---

### 2. SQL Server Management Studio (SSMS)

**What it is:**
- Official GUI tool to manage SQL Server

**Used for:**
- Connecting to SQL Server
- Creating and modifying tables
- Writing and executing SQL queries
- Creating stored procedures
- Viewing and editing data
- Backup and restore databases
- Managing users and permissions

**Key Features:**
- Object Explorer (browse databases and tables)
- Query Editor (write SQL scripts)
- Debugging and performance tools

---

### 3. Azure Data Studio (Deprecated)

**What it was:**
- Lightweight database tool for SQL Server and Azure

**Current Status:**
- ❌ Retired (No longer updated or supported)

**Recommendation:**
- Use **VS Code + MSSQL Extension** instead

---

## 💻 Backend Development (.NET)

### Visual Studio

**What it is:**
- Full-featured IDE for building .NET applications

**Used for:**
- Creating ASP.NET Core Web APIs
- Writing and managing code
- Debugging applications
- Running and testing APIs
- Publishing applications

---

### .NET SDK

**What it is:**
- Runtime and tools required to build and run .NET applications

---

### API Testing Tools

- Swagger (built-in API UI)
- Postman (external testing tool)

---

## ⚛️ Frontend Development (React)

### Node.js

**What it is:**
- JavaScript runtime required to run React apps

---

### Package Managers

- npm (default)
- yarn (optional)
- pnpm (optional)

---

### Build Tools

- Vite (Recommended)
- Create React App (optional)

---

### Browser

- Google Chrome (for development and debugging)

---

## 🔁 Version Control

### Git

- Track code changes
- Manage versions

### GitHub

- Host repositories
- Collaborate with teams

---

## 🎨 UI & Design Tools

- Figma (UI/UX design)
- Bootstrap (CSS framework)
- Tailwind CSS (modern styling)

---

## ⚙️ Development Utilities

- Chrome DevTools (Network + Console debugging)
- Environment Variables (.env files)

---

## ☁️ Deployment & Hosting (Optional)

- IIS (Windows hosting)
- AWS (Cloud hosting)
- Azure (Cloud platform)

---

## 🧠 Learning Resources

- Microsoft Learn (official .NET documentation)
- MDN Web Docs (frontend reference)

---

## 🚀 Recommended Stack

### Backend
- ASP.NET Core Web API
- Dapper (with Stored Procedures)
- JWT Authentication

### Database
- SQL Server (schema-based multi-tenant)

### Frontend
- React + Vite
- Context API

---

## 💡 Notes

- Prefer Stored Procedures for business logic
- Keep controllers thin
- Follow consistent project structure
- Focus on real-world projects

---

## ⭐ Tip

> Tools are important, but real learning comes from building real applications.

Start with:
- CRUD APIs
- Admin dashboards
- Multi-tenant SaaS systems
