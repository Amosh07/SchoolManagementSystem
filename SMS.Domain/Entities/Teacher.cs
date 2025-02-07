using SMS.Domain.Common.Base;

namespace SMS.Domain.Entities
{
    public class Teacher : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Number { get; set; }

        public string? Email { get; set; }
    }
}
