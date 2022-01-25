using System.ComponentModel.DataAnnotations;

namespace HR.Department.Core.Entities
{
    public class TypePosition : BaseEntity
    {
        [Required]
        public string Name { get; private set; }
        public TypePosition(string name) => Name = name;
        public TypePosition() { }

    }
}
