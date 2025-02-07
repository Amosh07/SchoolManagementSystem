using SMS.Domain.Common.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Domain.Entities
{
    public class Result : BaseEntity<Guid>
    {
        public string Grade { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(Exam))]
        public virtual ICollection<Student>? Student { get; set; }

        public virtual Exam? Exam { get; set; }
    }
}
