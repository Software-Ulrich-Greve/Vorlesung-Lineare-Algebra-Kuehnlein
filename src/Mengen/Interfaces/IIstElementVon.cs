namespace src.Mengen.Interfaces
{
    public interface IIstElementVon<E> where E : IEquatable<E>
    {
        public bool IstElementVon(IMenge<E> menge);
    }
}
