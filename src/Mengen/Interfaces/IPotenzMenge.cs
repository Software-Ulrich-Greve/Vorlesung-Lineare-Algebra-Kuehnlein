namespace src.Mengen.Interfaces
{
    public interface IPotenzMenge<M> where M : IEquatable<M>
    {
        public Elemente<M> Potenzmenge { get; set; }

        public void BerechnePotenzMenge();
    }
}
