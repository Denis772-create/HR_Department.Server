namespace HR.Department.Core.Entities
{
    public class TypePosition : BaseEntity
    {
        public string Name { get; private set; }
        public TypePosition(string name) => Name = name;
    }
}
