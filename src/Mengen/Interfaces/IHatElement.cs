namespace src.Mengen.Interfaces
{
    public interface IHatElement<T> where T : IEquatable<T>
    {
        public bool HatElement(T element);
    }
}
