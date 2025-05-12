namespace Mengen.Interfaces
{
    public interface IIstElementMengeVon<E> where E : IEquatable<E>
    {
        public bool IstElementMengeVon(AbstractMengeDerMengen<E> menge);
    }
}
