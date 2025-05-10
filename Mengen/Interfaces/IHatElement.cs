namespace Mengen.Interfaces
{
    public interface IHatElement<E> where E : IEquatable<E>
    {
        public bool HatElement(E element);
    }
}
