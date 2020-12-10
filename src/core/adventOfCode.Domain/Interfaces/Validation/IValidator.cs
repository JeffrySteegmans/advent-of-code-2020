namespace adventOfCode.Domain.Interfaces.Validation
{
    public interface IValidator<T>
    {
        public bool IsValid(T obj);
    }
}
