namespace Mengen.Interfaces
{
    public interface IElementMitIndex<T> where T : IEquatable<T>
    {
        public T GetElementMitIndex(int index);
    }
}
