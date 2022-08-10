using System;

namespace HR.Department.Core.Entities
{
    public class PositionEmployee : BaseEntity
    {
        public Guid PositionId { get; set; }
        public virtual Position Position { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public decimal Salary { get; set; }
    }
}
