namespace src.Mengen.Interfaces
{
    public interface IIstElementVon<M> where M : IEquatable<M>
    {
        public bool IstElementVon(M? menge);
    }
}
