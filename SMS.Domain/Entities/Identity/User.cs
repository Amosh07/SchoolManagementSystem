using Microsoft.AspNetCore.Identity;
using SMS.Domain.Common.Enum;

namespace SMS.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public GenderType Gender { get; set; }

        public string? Address { get; set; }

        public string? ImageURL { get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; }

        public virtual ICollection<Teacher> Teacher { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
