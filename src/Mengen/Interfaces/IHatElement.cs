namespace src.Mengen.Interfaces
{
    public interface IHatElement<TElement> where TElement : IEquatable<TElement>
    {
        public bool HatElement(TElement element);
    }
}
