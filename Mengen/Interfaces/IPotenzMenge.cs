namespace Mengen.Interfaces
{
    public interface IPotenzMenge<M> where M : IEquatable<M>
    {
        public AbstractMengeBase<M>? Potenzmenge { get; set; }

        public void BerechnePotenzMenge();
    }
}
