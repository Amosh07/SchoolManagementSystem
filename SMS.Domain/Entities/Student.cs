using SMS.Domain.Common.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Domain.Entities
{
    public class Student : BaseEntity<Guid>
    {
        public string Name { get; set; } 

        public string Address { get; set; } 

        public string Number { get; set; }

        [ForeignKey(nameof(Class))]
        public Guid? ClassId { get; set; }

        public virtual Class? Class { get; set; }
    }
}
