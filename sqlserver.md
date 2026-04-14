# 🗄️ SQL Server Basic Concepts Notes

---

## 🖥️ Database Server

**Definition:**
- A Database Server is a system that hosts and runs the database engine.

---

## 🗃️ Database

**Definition:**
- A Database is a collection of structured data stored inside the server.

---

## 📁 Schema

**Definition:**
- A Schema is a logical container inside a database used to group related objects.

---

## 📊 Table

**Definition:**
- A Table stores data in rows and columns.

---

## 🧱 Columns

**Definition:**
- Columns define the structure of a table.

---

## 🔢 Data Types

| Data Type     | Description                     |
|--------------|--------------------------------|
| int          | Integer numbers                |
| nvarchar(n)  | Unicode text                   |
| date         | Date only                      |
| datetime2    | Date and time                  |
| bit          | Boolean (0 / 1)                |
| timestamp    | Row version tracking           |

---

## 🔑 Identity Column

**Definition:**
- Auto-increment column

**Example:**


---

## 🧾 CREATE TABLE Example

```sql
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
    [RowVersion] TIMESTAMP NOT NULL
);

### INSERT INTO [sahasra].[Student]
### (
    RollNumber,
    FirstName,
    LastName,
    DOB,
    Gender,
    Email,
    Phone,
    IsActive,
    CreatedAtUtc
### )
VALUES
### (
    'R001',
    'Arjun',
    'Kumar',
    '2000-01-01',
    'Male',
    'arjun@example.com',
    '9876543210',
    1,
    GETUTCDATE()
### );

### SELECT * FROM [sahasra].[Student];

### UPDATE [sahasra].[Student]
SET
    Email = 'newemail@example.com',
    UpdatedAtUtc = GETUTCDATE()
WHERE StudentId = 1;

### DELETE FROM [sahasra].[Student]
WHERE StudentId = 1;

### UPDATE [sahasra].[Student]
SET
    IsActive = 0
WHERE StudentId = 1;


### 🧠 Table Column Explanation
StudentId → Primary Key (Auto Increment)
RollNumber → Unique student identifier
FirstName, LastName → Name
DOB → Date of birth
Gender → Gender
Email, Phone → Contact info
IsActive → Active status
UserId → Linked user
CreatedAtUtc, UpdatedAtUtc → Audit timestamps
CreatedByUserId, UpdatedByUserId → Audit users
RowVersion → Concurrency tracking

⭐ Summary
CREATE → Create table
INSERT → Add data
SELECT → Read data
UPDATE → Modify data
DELETE → Remove data
