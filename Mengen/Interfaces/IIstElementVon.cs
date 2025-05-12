namespace Mengen.Interfaces
{
    public interface IIstElementVon<E> where E : IEquatable<E>
    {
        public bool IstElementVon(AbstractMengeBase<E> menge);
    }
}
