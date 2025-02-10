using SMS.Domain.Common.Base;
using SMS.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Domain.Entities
{
    public class Teacher : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Number { get; set; }

        public string? Email { get; set; }

        [ForeignKey(nameof(Users))]
        public Guid? UserId { get; set; }

        public virtual User? Users { get; set; }
    }
}
