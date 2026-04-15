# 📘 Day 1 - SQL Server & SSMS Basics

## 🧠 What is SSMS?

**SQL Server Management Studio (SSMS)** is a tool provided by Microsoft to:

- Connect to SQL Server databases
- Write and execute SQL queries
- Create and manage databases, tables, and data
- Perform backup, restore, and security operations

---

## 🔌 How to Connect to a Database

### Steps:

1. Open **SSMS**
2. Click **Connect → Database Engine**
3. Enter details:
   - **Server Name**: (e.g., localhost or server IP)
   - **Authentication**:
     - Windows Authentication OR
     - SQL Server Authentication
   - Username & Password (if SQL Auth)
4. Click **Connect**

---

## 🏗️ Create Schema (if not exists)

```sql
CREATE SCHEMA sahasra;
GO

CREATE TABLE [sahasra].[Student](
    [StudentId] INT IDENTITY(1,1) NOT NULL,
    [RollNumber] NVARCHAR(30) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [DOB] DATE NULL,
    [Gender] NVARCHAR(20) NULL,
    [Email] NVARCHAR(256) NULL,
    [Phone] NVARCHAR(30) NULL,
    [IsActive] BIT NOT NULL,
    [UserId] INT NULL,
    [CreatedAtUtc] DATETIME2(0) NOT NULL,
    [UpdatedAtUtc] DATETIME2(0) NULL,
    [CreatedByUserId] INT NULL,
    [UpdatedByUserId] INT NULL,
    [RowVersion] ROWVERSION NOT NULL
);
GO
INSERT INTO [sahasra].[Student]
(
    RollNumber,
    FirstName,
    LastName,
    DOB,
    Gender,
    Email,
    Phone,
    IsActive,
    UserId,
    CreatedAtUtc,
    CreatedByUserId
)
VALUES
('R001', 'AJ', 'Kumar', '2000-05-10', 'Male', 'arjun@example.com', '9876543210', 1, 1, GETUTCDATE(), 1),
('R002', 'Sita', 'Devi', '2001-08-15', 'Female', 'sita@example.com', '9123456780', 1, 1, GETUTCDATE(), 1),
('R003', 'Chiru', 'Konidela', '1999-12-20', 'Male', 'chiru@example.com', '9988776655', 1, 1, GETUTCDATE(), 1);
GO

-- Get all students
SELECT * FROM [sahasra].[Student];

-- Get only active students
SELECT * FROM [sahasra].[Student]
WHERE IsActive = 1;

-- Search by Roll Number
SELECT * FROM [sahasra].[Student]
WHERE RollNumber = 'R001';

-- Update student email
UPDATE [sahasra].[Student]
SET Email = 'arjun.new@example.com',
    UpdatedAtUtc = GETUTCDATE(),
    UpdatedByUserId = 2
WHERE StudentId = 1;

-- Delete student permanently
DELETE FROM [sahasra].[Student]
WHERE StudentId = 3;

# Constraints, Relationships & Stored Procedures
  ## 🧠 What You Will Learn Today

- Constraints (Primary Key, Foreign Key, Unique, Default)
- Table Relationships
- Indexes (Basics)
- Stored Procedures (CRUD)
- Real-world SQL structure (as used in projects)

---

## 🔐 Constraints in SQL Server

### 1. Primary Key (PK)

- Uniquely identifies each record
- Cannot be NULL


ALTER TABLE [sahasra].[Student]
ADD CONSTRAINT PK_Student PRIMARY KEY (StudentId);

ALTER TABLE [sahasra].[Student]
ADD CONSTRAINT UQ_Student_RollNumber UNIQUE (RollNumber);

ALTER TABLE [sahasra].[Student]
ADD CONSTRAINT DF_Student_IsActive DEFAULT (1) FOR IsActive;

CREATE TABLE [sahasra].[Department](
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

  ALTER TABLE [sahasra].[Student]
ADD DepartmentId INT;

ALTER TABLE [sahasra].[Student]
ADD CONSTRAINT FK_Student_Department
FOREIGN KEY (DepartmentId)
REFERENCES [sahasra].[Department](DepartmentId);

INSERT INTO [sahasra].[Department] (DepartmentName)
VALUES ('Computer Science'), ('Commerce'), ('Arts');

SELECT 
    s.StudentId,
    s.FirstName,
    s.LastName,
    d.DepartmentName
FROM [sahasra].[Student] s
LEFT JOIN [sahasra].[Department] d
    ON s.DepartmentId = d.DepartmentId;

⚙️ Stored Procedures (SP)

👉 In real projects, we DO NOT write raw queries in API
👉 We use Stored Procedures + Dapper

  ⚡ Index (Performance)
Improves query speed
  CREATE INDEX IX_Student_RollNumber
ON [sahasra].[Student](RollNumber);

📌 1. SELECT Stored Procedure
CREATE PROCEDURE [sahasra].[Student_Select]
(
    @StudentId INT = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM [sahasra].[Student]
    WHERE (@StudentId IS NULL OR StudentId = @StudentId);
END;
GO
📌 2. INSERT Stored Procedure
CREATE PROCEDURE [sahasra].[Student_Create]
(
    @RollNumber NVARCHAR(30),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @CreatedByUserId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [sahasra].[Student]
    (
        RollNumber,
        FirstName,
        LastName,
        IsActive,
        CreatedAtUtc,
        CreatedByUserId
    )
    VALUES
    (
        @RollNumber,
        @FirstName,
        @LastName,
        1,
        GETUTCDATE(),
        @CreatedByUserId
    );
END;
GO
📌 3. UPDATE Stored Procedure
CREATE PROCEDURE [sahasra].[Student_Update]
(
    @StudentId INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @UpdatedByUserId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [sahasra].[Student]
    SET 
        FirstName = @FirstName,
        LastName = @LastName,
        UpdatedAtUtc = GETUTCDATE(),
        UpdatedByUserId = @UpdatedByUserId
    WHERE StudentId = @StudentId;
END;
GO
📌 4. DELETE (Soft Delete Preferred)
CREATE PROCEDURE [sahasra].[Student_Delete]
(
    @StudentId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [sahasra].[Student]
    SET 
        IsActive = 0,
        UpdatedAtUtc = GETUTCDATE()
    WHERE StudentId = @StudentId;
END;
GO
🧪 Execute Stored Procedures
-- Select all
EXEC [sahasra].[Student_Select];

-- Select by Id
EXEC [sahasra].[Student_Select] @StudentId = 1;

-- Insert
EXEC [sahasra].[Student_Create]
    @RollNumber = 'R004',
    @FirstName = 'Kiran',
    @LastName = 'Reddy',
    @CreatedByUserId = 1;

-- Update
EXEC [sahasra].[Student_Update]
    @StudentId = 1,
    @FirstName = 'Arjun Updated',
    @LastName = 'Kumar',
    @UpdatedByUserId = 2;

-- Delete (Soft)
EXEC [sahasra].[Student_Delete]
    @StudentId = 2;

SELECT [DISTINCT] column1, column2, ...
FROM table_name
[JOIN table2 ON condition]
[WHERE condition]
[GROUP BY column1, column2, ...]
[HAVING condition]
[ORDER BY column1 ASC|DESC]
[OFFSET n ROWS FETCH NEXT m ROWS ONLY];

```sql


# 📘 SQL SELECT - Short Notes

- **SELECT** → Choose columns to display  
- **DISTINCT** → Remove duplicate rows  
- **FROM** → Specify table name  
- **JOIN** → Combine data from multiple tables  
- **WHERE** → Filter rows before grouping  
- **GROUP BY** → Group rows (used with COUNT, SUM, AVG, etc.)  
- **HAVING** → Filter grouped data (after GROUP BY)  
- **ORDER BY** → Sort results (ASC / DESC)  
- **OFFSET FETCH** → Pagination (skip & limit rows)

---

## 🧠 Execution Order

FROM → JOIN → WHERE → GROUP BY → HAVING → SELECT → ORDER BY → OFFSET FETCH

# 📘 SQL CRUD - Short Notes (Concept Only)

---

## ➕ INSERT

- **INSERT INTO** → Specifies the table  
- **Columns** → Defines which fields to insert data into  
- **VALUES** → Provides the data to be inserted  
- Used to **add new records** into a table  

---

## ✏️ UPDATE

- **UPDATE** → Specifies the table to modify  
- **SET** → Defines columns and new values  
- **WHERE** → Filters which rows to update  
- Used to **modify existing records**  

---

## ❌ DELETE

- **DELETE FROM** → Specifies the table  
- **WHERE** → Filters which rows to delete  
- Used to **remove records permanently**  

---

## ⚠️ Soft Delete

- Instead of deleting data, mark it as inactive  
- Use flags like **IsActive / IsDeleted**  
- Helps in **data recovery and auditing**  

---

## 🧠 Important Notes

- ❗ **WHERE is mandatory** for UPDATE & DELETE  
- ❗ Without WHERE → affects all rows  
- ✅ Prefer **Soft Delete in production systems**  
- ✅ Maintain **audit fields** (Created, Updated)  
- ✅ Use **UTC time for consistency**  

---

## 🔄 Operation Purpose

- INSERT → Add new data  
- UPDATE → Modify existing data  
- DELETE → Remove data  
- Soft Delete → Hide data without removing
