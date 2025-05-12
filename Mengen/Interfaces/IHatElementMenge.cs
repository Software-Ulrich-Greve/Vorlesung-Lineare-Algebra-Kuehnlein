namespace Mengen.Interfaces
{
    public interface IHatElementMenge<M> where M : IEquatable<M>
    {
        public bool HatElementMenge(M menge);
    }
}
