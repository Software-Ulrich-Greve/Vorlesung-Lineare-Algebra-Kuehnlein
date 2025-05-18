namespace src.Mengen.Interfaces
{
    public interface IElementMitIndex<TElement> where TElement : IEquatable<TElement>
    {
        public TElement ElementMitIndex(int index);
    }
}
