namespace adventOfCode.Domain.Interfaces
{
    public interface IParser<in Tin, out Tout>
    {
        Tout Parse(Tin value);
    }
}
