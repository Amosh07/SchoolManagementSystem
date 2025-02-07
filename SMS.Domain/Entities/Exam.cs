using SMS.Domain.Common.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Domain.Entities
{
    public class Exam : BaseEntity<Guid>
    {
        public string ExamName { get; set; }

        [ForeignKey(nameof(Subject))]
        public Guid? SubjectId { get; set; }

        [ForeignKey(nameof(Class))]

        public Guid? ClassId { get; set; }
        public virtual ICollection<Subject>? Subject { get; set; }

        public virtual ICollection<Class>? Class { get; set; }
    }
}
