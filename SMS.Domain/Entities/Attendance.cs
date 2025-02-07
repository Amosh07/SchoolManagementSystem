using SMS.Domain.Common.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Domain.Entities
{
    public class Attendance : BaseEntity<Guid>
    {
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Student))]
        public Guid? StudentId { get; set; }

        [ForeignKey(nameof(Teacher))]
        public Guid? TeacherId { get; set; }

        [ForeignKey(nameof(Classes))]
        public Guid? ClassId { get; set; }
        public virtual ICollection<Student>? Student { get; set; }
        
        public virtual Teacher? Teacher { get; set; }

        public virtual ICollection<Class>? Classes { get; set; }
    }
}
