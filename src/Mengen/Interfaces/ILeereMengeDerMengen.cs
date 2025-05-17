namespace src.Mengen.Interfaces
{
    public interface ILeereMengeDerMengen<T> where T : IEquatable<T>
    {
        public Elemente<T> LeereMengeDerMengen { get; }
    }
}
