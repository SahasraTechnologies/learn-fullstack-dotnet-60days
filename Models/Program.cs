

using Microsoft.Data.SqlClient;

namespace Models
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                var student = new Student
                {
                    RollNumber = "R100",
                    FirstName = "Arjun",
                    LastName = "Kumar",
                    DOB = new DateTime(2000, 5, 10),
                    Gender = "Male",
                    Email = "arjun@test.com",
                    Phone = "9876543210",
                    IsActive = true,
                    UserId = 1,
                    CreatedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = 1
                };

                string sql = @"
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
                (
                    @RollNumber,
                    @FirstName,
                    @LastName,
                    @DOB,
                    @Gender,
                    @Email,
                    @Phone,
                    @IsActive,
                    @UserId,
                    @CreatedAtUtc,
                    @CreatedByUserId
                );";

                int rowsAffected = connection.Execute(sql, student);

                Console.WriteLine($"Inserted Rows: {rowsAffected}");
            }

            Console.ReadLine();
        }
    }
}
