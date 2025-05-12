namespace Mengen.Interfaces
{
    public interface IHatElementMenge<T> where T : IEquatable<T>
    {
        public bool HatElement(AbstractMengeBase<T> menge);
    }
}
