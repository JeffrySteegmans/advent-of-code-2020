namespace adventOfCode.Domain.Interfaces.Validation
{
    public interface IFieldValidator<T> : IValidator<T>
    {
        public string FieldName { get; }
    }
}
