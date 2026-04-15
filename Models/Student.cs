

namespace Models
{
    public class Student 
    {
        public int StudentId { get; set; }
        public string RollNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
