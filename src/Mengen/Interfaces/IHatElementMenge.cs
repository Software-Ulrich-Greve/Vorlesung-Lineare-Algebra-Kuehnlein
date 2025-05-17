namespace src.Mengen.Interfaces
{
    public interface IHatElementMenge<T> where T : IEquatable<T>
    {
        public bool HatElement(Interfaces.IMenge<T> menge);
    }
}
