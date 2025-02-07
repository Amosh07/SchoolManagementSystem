using SMS.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Domain.Common.Base
{
    public class BaseEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(CreateUser))]
        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(LastModifiedUser))]
        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        [ForeignKey(nameof(DeletedBy))]
        public Guid? DeletedBy { get; set; }
        
        public DateTime? DeletedAt { get; set; }

        public virtual User? CreateUser { get; set; }

        public virtual User? LastModifiedUser { get; set; }

        public virtual User? DeletedUser { get; set; }
    }
}
