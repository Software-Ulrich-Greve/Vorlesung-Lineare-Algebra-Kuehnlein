namespace src.Mengen.Interfaces
{
    public interface IPotenzMenge<M> where M : IEquatable<M>
    {
        public int KardinalitaetPotenzmenge { get; }

        public GenerischeMenge<M>? Potenzmenge();
    }
}
