namespace src.Mengen.Interfaces
{
    public interface IHatElementMenge<T> where T : IEquatable<T>
    {
        public bool HatElement(IMenge<T> menge);
    }
}
